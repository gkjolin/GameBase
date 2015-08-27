using UnityEngine;
using System.Collections;

public class Gaylen : GeneralSoldier
{

    /// <summary>
    /// 初始化
    /// </summary>
    public override void spriteInit()
    {
        //调用父类初始化方法
        base.spriteInit();

        //实例化所需状态
        IdleState = new GeneralIdleState(this);
        MoveState = new GeneralMoveState(this);
        AttackState = new GeneralAttackState(this);
        HurtState = new GeneralHurtState(this);
        DeadState = new GeneralDeadState(this);
        WinState = new GeneralWinState(this);

        //取得角色动作
        _animator = GetComponent<Animator>();
    }

    ///// <summary>
    ///// 角色动作
    ///// </summary>
    //public Animator animator;


    ///// <summary>
    ///// 状态列表
    ///// </summary>
    //private GeneralIdleState _idleState;    //待机状态
    //private GeneralFindState _findState;    //锁敌状态
    //private GeneralMoveState _moveState;    //靠近状态
    //public GeneralAttackState _attackState; //攻击状态
    //private GeneralHurtState _hurtState;    //受击状态
    //private GeneralDeadState _deadState;    //死亡状态
    //private GeneralWinState _winState;      //胜利状态

    //public void Awake()
    //{
    //    //数据
    //    data = new IronSoldierData();

    //    //实例化所需状态
    //    _idleState = new GeneralIdleState(this);
    //    _findState = new GeneralFindState(this);
    //    _moveState = new GeneralMoveState(this);
    //    _attackState = new GeneralAttackState(this);
    //    _hurtState = new GeneralHurtState(this);
    //    _deadState = new GeneralDeadState(this);
    //    _winState = new GeneralWinState(this);

    //    //取得角色动作
    //    animator = GetComponent<Animator>();
    //}


    //// Use this for initialization
    //void Start()
    //{
    //}


    ///// <summary>
    ///// 更新状态
    ///// </summary>
    //new void Update()
    //{
    //    base.Update();
    //}


    ///// <summary>
    ///// 调度逻辑
    ///// </summary>
    ///// <returns></returns>
    //public override bool logic()
    //{
    //    if (_currentState == null)
    //    {
    //        setState(_idleState);
    //    }
    //    return false;
    //}


    ///// <summary>
    ///// 事件通知（来自于状态）
    ///// </summary>
    ///// <param name="sender"></param>
    ///// <param name="eventId"></param>
    ///// <param name="eventData"></param>
    //public override bool notifyEvent(XLStateBase sender, int eventId, Object eventData)
    //{
    //    //待机状态
    //    if (sender == _idleState)
    //    {

    //        return true;
    //    }


    //    //锁敌状态
    //    if (sender == _findState)
    //    {
    //        //锁敌成功
    //        if (eventId == GeneralFindState.FINDED_EVENT)
    //        {
    //            //如果敌人在攻击范围内
    //            if (Vector3.Distance(gameObject.transform.position, data.AttackTarget.transform.position) < data.Range)
    //            {
    //                //变为攻击状态
    //                setState(_attackState);
    //            }
    //            else
    //            {
    //                //如果敌人不在攻击范围内，变为靠近状态
    //                setState(_moveState);
    //            }
    //        }

    //        //敌人全部死亡
    //        if (eventId == GeneralFindState.ENEMY_IS_NULL)
    //        {
    //            //由战场管理器统一播放胜利动作
    //            setState(_winState);
    //        }

    //        return true;
    //    }


    //    //移动状态
    //    if (sender == _moveState)
    //    {
    //        //进入攻击范围
    //        if (eventId == GeneralMoveState.MOVE_COMPLETE_EVENT)
    //        {
    //            //进入攻击状态
    //            setState(_attackState);
    //        }
    //        return true;
    //    }


    //    //攻击状态
    //    if (sender == _attackState)
    //    {
    //        //攻击目标为空
    //        if (eventId == GeneralAttackState.ATTACK_TARGET_IS_NULL)
    //        {
    //            //进入锁敌状态
    //            setState(_findState);
    //        }

    //        //攻击目标不在攻击范围内
    //        if (eventId == GeneralAttackState.ATTACK_TARGET_IS_OUT)
    //        {
    //            //进入锁敌状态
    //            setState(_findState);
    //        }
    //        return true;
    //    }


    //    ////死亡状态发来的消息
    //    if (sender == _deadState)
    //    {
    //        //死亡动作播放完毕
    //        if (eventId == GeneralDeadState.DEAD_COMPLETE_EVENT)
    //        {
    //            //GameObject.Destroy(this.gameObject);
    //            return true;
    //        }
    //        return true;
    //    }

    //    return false;
    //}


    ///// <summary>
    ///// 被攻击————————以后需要改成根据敌人的攻击类型和级别进行伤害判定
    ///// </summary>
    ///// <param name="atk"></param>
    ///// <returns></returns>
    //public override bool hurt(int atk)
    //{
    //    //减血
    //    data.HP -= atk;

    //    //是否死亡
    //    if (data.HP <= 0)
    //    {
    //        //进入死亡状态
    //        setState(_deadState);
    //    }
    //    else
    //    {
    //        //进入受击状态
    //        //setState(_hurtState);
    //    }

    //    //返回
    //    return data.HP <= 0;
    //}


    /// <summary>
    /// 动画回调
    /// </summary>
    public void animationCall(int type)
    {
        //Debug.Log(gameObject.name + _data.Country + "士兵动画回调" + type);

        //根据返回的类别进行处理
        switch (type)
        {
            case GeneralSoldier.HIT_THE_POINT_CALL_BACK:    //进入打击点

                _data.SkillMgr.play(2001);

                //对方掉血
                bool isDead = SpriteMgr.getInstance().hit(this);

                //目标是否死亡
                if (isDead)
                {
                    //将自己目标置空
                    _data.AttackTarget = null;
                }
                break;

            case GeneralSoldier.HIT_THE_END_CALL_BACK:     //本次攻击结束
                AttackState.init();
                break;

            case GeneralSoldier.DEAD_OVER_CALL_BACK:       //死亡动画播放完毕
                string debugName = this.name;
                GameObject.Destroy(this.gameObject);  //销毁
                break;

            case GeneralSoldier.HURT_OVER_CALL_BACK:       //受攻击动画播放完毕
                //进入锁敌状态
                setState(_walkState);
                break;
        }
    }
}
