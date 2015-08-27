using UnityEngine;

using XingLuoTianXia.lib;

/// <summary>
/// 通用士兵
/// </summary>
public class GeneralSoldier : XLSpriteBase, XLStateListener
{
    /// <summary>
    /// 打击点回调
    /// </summary>
    public const int HIT_THE_POINT_CALL_BACK = 0;

    /// <summary>
    /// 攻击动作播放完毕回调
    /// </summary>
    public const int HIT_THE_END_CALL_BACK = 1;

    /// <summary>
    /// 死亡动画播放完毕回调
    /// </summary>
    public const int DEAD_OVER_CALL_BACK = 2;

    /// <summary>
    /// 受攻击动画播放完毕回调
    /// </summary>
    public const int HURT_OVER_CALL_BACK = 3;

    public const int PLAY_SKILL_EFFECT = 4;

    /// <summary>
    /// 血条
    /// </summary>
    public LifeTest _lifeLine;
    public GameObject _lifeTestObj;

    /// <summary>
    /// 测试用的变量
    /// </summary>
    private bool _isDebug = false;
    public bool IsDebug
    {
        get { return _isDebug; }
        set { _isDebug = value; }
    }

    /// <summary>
    /// 角色动作
    /// </summary>
    public Animator _animator;

    /// <summary>
    /// 待机状态
    /// </summary>
    protected XLStateBase _idleState;
    public XLStateBase IdleState
    {
        set { _idleState = value; }
        get { return _idleState; }
    }

    /// <summary>
    /// 走路状态（使用navmesh来实现寻路）
    /// </summary>
    protected GeneralWalkState _walkState;
    public GeneralWalkState WalkState
    {
        set { _walkState = value; }
        get { return _walkState; }
    }

    /// <summary>
    /// 靠近状态
    /// </summary>
    protected XLStateBase _moveState;
    public XLStateBase MoveState
    {
        set { _moveState = value; }
        get { return _moveState; }
    }

    /// <summary>
    /// 攻击状态
    /// </summary>
    protected XLStateBase _attackState;
    public XLStateBase AttackState
    {
        set { _attackState = value; }
        get { return _attackState; }
    }

    /// <summary>
    /// 受击状态
    /// </summary>
    protected XLStateBase _hurtState;
    public XLStateBase HurtState
    {
        set { _hurtState = value; }
        get { return _hurtState; }
    }

    /// <summary>
    /// 死亡状态
    /// </summary>
    protected XLStateBase _deadState;
    public XLStateBase DeadState
    {
        set { _deadState = value; }
        get { return _deadState; }
    }

    /// <summary>
    /// 胜利状态
    /// </summary>
    protected XLStateBase _winState;
    public XLStateBase WinState
    {
        set { _winState = value; }
        get { return _winState; }
    }

    /// <summary>
    /// 代理器
    /// </summary>
    private NavMeshAgent _navmeshAgent;
    
    /// <summary>
    /// 为了固定人物用的定身逻辑成员变量
    /// </summary>
    private bool _isWalkEnable = true;
    private Vector3 _stopPosition;

    /// <summary>
    /// 左闪避点
    /// </summary>
    private Vector3 _dodgeLeftPostion;
    public Vector3 DodgeLeftPostion
    {
        get { return _dodgeLeftPostion; }
    }

    /// <summary>
    /// 右闪避点
    /// </summary>
    private Vector3 _dodgeRightPostion;
    public Vector3 DodgeRightPostion
    {
        get { return _dodgeRightPostion; }
    }

    /// <summary>
    /// 躲避角度
    /// </summary>
    private static readonly float DODGE_ANGLE = 90.0f;

    /// <summary>
    /// 躲避距离
    /// </summary>
    private static readonly float DODGE_DISTANCE = 8.0f;

    /// <summary>
    /// 初始化
    /// </summary>
    public override void spriteInit()
    {
        //调用父类初始化方法
        base.spriteInit();

        _navmeshAgent = GetComponent<NavMeshAgent>();

        //实例化所需状态
        IdleState = new GeneralIdleState(this);
        MoveState = new GeneralMoveState(this);
        AttackState = new GeneralAttackState(this);
        HurtState = new GeneralHurtState(this);
        DeadState = new GeneralDeadState(this);
        WinState = new GeneralWinState(this);

        _walkState = new GeneralWalkState(this);

        //取得角色动作
        _animator = GetComponent<Animator>();

#if true
        if (_lifeTestObj == null)//判断血条组件是否为空
        {
            //实例化血条组件
            _lifeTestObj = ResourceManager.getInstance().getGameObject(PanelConfig.BLOOD_BAR);

            //获取当前Canvas下第一个对象
            _lifeTestObj.transform.SetParent(GameObject.Find("Canvas").transform.GetChild(0));
            _lifeTestObj.transform.SetAsFirstSibling();
            //设置缩放比
            _lifeTestObj.transform.localScale = Vector3.one;
            _lifeTestObj.transform.localPosition = Vector3.zero;
        }
        //获取血条脚本
        _lifeLine = _lifeTestObj.GetComponent<LifeTest>();
        //获取场景主摄像机
		_lifeLine._mainCamera = Game.GameEntry.Instance.Cameras.mainCamera;
        //设置士兵
        _lifeLine.soldier = this;
#endif
    }

    /// <summary>
    /// 是否可以做为别人的目标
    /// </summary>
    /// <returns></returns>
    public override bool isCanBeTarget()
    {
        return (_data.HP > 0);
    }

    /// <summary>
    /// 设置新状态-debug-TODO
    /// </summary>
    /// <param name="newState"></param>
    /// <returns></returns>
    public override bool setState(XLStateBase newState)
    {
        walkUnable(transform.position);

        if (_currentState == DeadState)
        {
            return true;
        }

        return base.setState(newState);
    }

    /// <summary>
    /// 停止寻路的行走
    /// </summary>
    public void walkStop()
    {
        _navmeshAgent.SetDestination(transform.position);

        // _navmeshAgent.Stop(); //使用这句之后就无法再寻路了
    }

    /// <summary>
    /// 设置该精灵为不可移动状态
    /// </summary>
    /// <param name="v3"></param>
    public void walkUnable(Vector3 stopPosition)
    {
        walkStop();

        _isWalkEnable = false;
        _stopPosition = stopPosition;
    }

    /// <summary>
    /// 设置该精灵为可移动状态
    /// </summary>
    public void walkEnable() 
    {
        _isWalkEnable = true;
    }

    private bool _isGizmos = false;

    /// <summary>
    /// 闪避目标点的更新 
    /// </summary>
    void dodgeTargetPostionUpdate()
    {
        if (!isCurrentState(_walkState)) 
        {
            _isGizmos = false;
            return;
        }

        if(_walkState.Target == null)
        {
            _isGizmos = false;
            return;
        }

        _isGizmos = true;

#if false
        Vector3 srcPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        Vector3 dstPos = new Vector3(_walkState.Target.transform.position.x, transform.position.y, _walkState.Target.transform.position.z);
        float angle = Vector3.Angle(srcPos, dstPos);
        // Debug.Log("angle:" + angle);
#endif

        // 设置寻路的目标点  
#if true
        float leay = transform.localEulerAngles.y;
#else
        // 这个角度是连接两个精灵的角度，从源精灵指向目标精灵，用这个就怕路都是堵死的
        float leay = angle/Mathf.PI * 180; 
#endif
        float x = transform.position.x;
        float z = transform.position.z;

        // 从身体向左的目标点
        float lRadian = (leay + DODGE_ANGLE) / 180.0f * Mathf.PI;
        float lx = Mathf.Sin(lRadian) * DODGE_DISTANCE + x;
        float ly = Mathf.Cos(lRadian) * DODGE_DISTANCE + z;
        _dodgeLeftPostion = new Vector3(lx, transform.position.y, ly);

        // 从身体向右的目标点
        float rRadian = (leay - DODGE_ANGLE) / 180.0f * Mathf.PI;
        float rx = Mathf.Sin(rRadian) * DODGE_DISTANCE + x;
        float ry = Mathf.Cos(rRadian) * DODGE_DISTANCE + z;
        _dodgeRightPostion = new Vector3(rx, transform.position.y, ry);
    }

    /// <summary>
    /// 调度逻辑
    /// </summary>
    /// <returns></returns>
    public override bool frameLogic()
    {
        dodgeTargetPostionUpdate();

        // 定身逻辑（防止被挤开）
        if (!_isWalkEnable)
        {
            transform.position = _stopPosition;
        }

        if (_currentState == null)
        {
            setState(_idleState);
        }

        return false;
    }

    /// <summary>
    /// 事件通知（来自于状态）
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="eventId"></param>
    /// <param name="eventData"></param>
    public bool notifyEvent(XLStateBase sender, int eventId, Object eventData)
    {
        // 行走状态
        if (sender == _walkState)
        {
            if (eventId == GeneralWalkState.EVENT_CHANGE_TO_ATTACK)
            {
                _data.AttackTarget = _walkState.Target;
                setState(AttackState);
                return true;
            }
            return true;
        }

        //攻击状态
        if (sender == AttackState)
        {
            //攻击目标为空或攻击目标不在攻击范围内
            if (eventId == GeneralAttackState.ATTACK_TARGET_IS_NULL || eventId == GeneralAttackState.ATTACK_TARGET_IS_OUT)
            {
                //如果是敌方
                if (_data.Country == Defaults.Country.Enemy)
                {
                    //己方还有士兵，进入锁敌
                    if (SpriteMgr.getInstance().SelfSoldiers.Count > 0)
                    {
                        //进入锁敌状态
                        setState(_walkState);
                    }
                }
                else
                {
                    //如果是己方，敌方还有士兵，进入锁敌
                    if (SpriteMgr.getInstance().EnemySoldiers.Count > 0)
                    {
                        //进入锁敌状态
                        setState(_walkState);
                    }
                }
            }

            return true;
        }

        return false;
    }


    /// <summary>
    /// 被攻击————————以后需要改成根据敌人的攻击类型和级别进行伤害判定
    /// </summary>
    /// <param name="atk"></param>
    /// <returns></returns>
    public bool hurt(int atk)
    {
        //如果已死，返回
        if (_currentState == DeadState)
        {
            return true;
        }

        //减血
        _data.HP -= atk;

        //血条
        _lifeLine.OnHit(atk);

#if false
        //飘伤害
        GameObject lifeTextObj = ResourceManager.getInstance().getGameObject("DmgText");
        LifeText lifeText = lifeTextObj.GetComponent<LifeText>();
        if (lifeText != null)
        {
            lifeText.setText(this, atk.ToString());
        }
#endif

#if true
        // 飘血特效
        GameObject effect = ResourceManager.getInstance().getGameObject("Hit_TongYong_001_big");
        effect.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y + 0.5f , this.gameObject.transform.position.z);
        effect.transform.SetParent(this.gameObject.transform);
#endif

        //是否死亡
        if (_data.HP <= 0)
        {
            walkStop();

            GameObject.Destroy(_lifeTestObj);

            //进入死亡状态
            setState(DeadState);
        }
#if false
        else
        {
            //进入受击状态
            setState(_hurtState);
        }
#endif

        //返回
        return _data.HP <= 0;
    }

    /// <summary>
    /// 动画回调
    /// </summary>
    public void animationCall(int type)
    {
        //Debug.Log(gameObject.name + _data.Country + "士兵动画回调" + type);

        //根据返回的类别进行处理
        if (type == GeneralSoldier.HIT_THE_POINT_CALL_BACK) //进入打击点
        {
            //对方掉血
            bool isDead = SpriteMgr.getInstance().hit(this);

            //目标是否死亡
            if (isDead)
            {
                //将自己目标置空
                _data.AttackTarget = null;
            }
            return;
        }

        //本次攻击结束
        if(type == GeneralSoldier.HIT_THE_END_CALL_BACK) 
        {
            AttackState.init();
            return;
        }

        //死亡动画播放完毕
        if(type == GeneralSoldier.DEAD_OVER_CALL_BACK)
        {
            string debugName = this.name;
            GameObject.Destroy(this.gameObject);       //销毁
            return;
        }

        //受攻击动画播放完毕
        if (type == GeneralSoldier.HURT_OVER_CALL_BACK)
        {
            //进入锁敌状态
            setState(_walkState);
            return;
        }
    }

    /// <summary>
    /// 标记闪避目标点的
    /// </summary>
    void OnDrawGizmos()
    {
        if (!_isGizmos)
        {
            return;
        }

#if true
        Debug.DrawLine(transform.position, _dodgeLeftPostion, Color.blue);
        Debug.DrawLine(transform.position, _dodgeRightPostion, Color.blue);
#endif
    }
}
