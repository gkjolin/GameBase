using UnityEngine;
using System.Collections;

using System.Collections.Generic;

/// <summary>
/// 铁甲兵
/// </summary>
public class AxeSoldier : GeneralSoldier
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
    //public GeneralIdleState idleState;//待机状态
    ////public FindEnemyState _findState;//锁敌状态
    //private GeneralMoveState _moveState;//靠近状态
    //public GeneralAttackState attackState;//攻击状态
    //private GeneralHurtState _hurtState;//受击状态
    //private GeneralDeadState _deadState;//死亡状态
    //public GeneralWinState winState;//胜利状态

    //public override void spriteInit()
    //{
    //    base.spriteInit();

    //    //数据
    //    data = new AxeSoldierData();

    //    //实例化所需状态
    //    idleState = new GeneralIdleState(this);
    //    //_findState = _findEnemyState; //new GeneralFindState(this);
    //    _moveState = new GeneralMoveState(this);
    //    attackState = new GeneralAttackState(this);
    //    _hurtState = new GeneralHurtState(this);
    //    _deadState = new GeneralDeadState(this);
    //    winState = new GeneralWinState(this);

    //    //取得角色动作
    //    animator = GetComponent<Animator>();
    //}

    //// Use this for initialization
    //void Start()
    //{
    //}

    ///// <summary>
    ///// 是否可以做为别人的目标
    ///// </summary>
    ///// <returns></returns>
    //public override bool isCanBeTarget()
    //{
    //    return (data.HP > 0);
    //}

    ///// <summary>
    ///// 调度逻辑
    ///// </summary>
    ///// <returns></returns>
    //public override bool logic()
    //{
    //    if (data.Country == Defaults.Country.Me)
    //        if (data.Country == Defaults.Country.Me)
    //        {
    //            int a = 0;
    //        }
    //        else
    //        {
    //            int a = 0;
    //        }

    //    if (base.logic())
    //    {
    //        return true;
    //    }

    //    if (_currentState == null)
    //    {
    //        setState(idleState);
    //    }

    //    return false;
    //}

    ///// <summary>
    ///// TODO 这是为了测试用的，切换两种寻路方式
    ///// </summary>
    //public void setFindState()
    //{
    //    setState(_findEnemyState);
    //    //setState(_findState);
    //}

    ///// <summary>
    ///// 事件通知（来自于状态）
    ///// </summary>
    ///// <param name="sender"></param>
    ///// <param name="eventId"></param>
    ///// <param name="eventData"></param>
    //public override bool notifyEvent(XLStateBase sender, int eventId, Object eventData)
    //{
    //    if (sender == _findEnemyState && eventId == FindEnemyState.EVENT_FAIL)
    //    {
    //        //由战场管理器统一播放胜利动作
    //        setState(winState);
    //    }

    //    if (base.notifyEvent(sender, eventId, eventData))
    //    {
    //        return true;
    //    }

    //    //待机状态
    //    if (sender == idleState)
    //    {
    //        return true;
    //    }

    //    //锁敌状态
    //    //if (sender == findState)
    //    //{
    //    //    //锁敌成功
    //    //    if (eventId == GeneralFindState.FINDED_EVENT)
    //    //    {
    //    //        //如果敌人在攻击范围内
    //    //        if (Vector3.Distance(gameObject.transform.position, data.AttackTarget.transform.position) < data.Range)
    //    //        {
    //    //            //变为攻击状态
    //    //            setState(attackState);
    //    //        }
    //    //        else
    //    //        {
    //    //            //如果敌人不在攻击范围内，变为靠近状态
    //    //            setState(_moveState);
    //    //        }
    //    //    }

    //    //    //敌人全部死亡
    //    //    if (eventId == GeneralFindState.ENEMY_IS_NULL)
    //    //    {
    //    //        //由战场管理器统一播放胜利动作
    //    //        setState(winState);
    //    //    }

    //    //    return true;
    //    //}

    //    // 追敌
    //    if (sender == _walkToEnemyState)
    //    {
    //        if (eventId == WalkToEnemyState.EVENT_SUCCESS)
    //        {
    //            _animator.Play("idle01");

    //            //设置攻击目标
    //            if (data.AttackTarget == null && this.Target != null)
    //            {
    //                data.AttackTarget = this.Target;
    //                setState(attackState);
    //            }
    //            else if (this.Target == null)
    //            {
    //                setState(_findEnemyState);
    //            }
    //            return true;
    //        }

    //        if (eventId == WalkToEnemyState.EVENT_BLOCK || eventId == WalkToEnemyState.EVENT_FAIL)
    //        {
    //            setState(_findEnemyState);
    //            return true;
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
    //            setState(attackState);
    //        }
    //        return true;
    //    }


    //    //攻击状态
    //    if (sender == attackState)
    //    {
    //        //攻击目标为空或攻击目标不在攻击范围内
    //        if (eventId == GeneralAttackState.ATTACK_TARGET_IS_NULL || eventId == GeneralAttackState.ATTACK_TARGET_IS_OUT)
    //        {
    //            //如果是敌方
    //            if (data.Country == Defaults.Country.Enemy)
    //            {
    //                //己方还有士兵，进入锁敌
    //                if (SpriteMgr.getInstance().SelfSoldiers.Count > 0)
    //                {
    //                    //进入锁敌状态
    //                    setState(_findEnemyState);
    //                }
    //            }
    //            else
    //            {
    //                //如果是己方，敌方还有士兵，进入锁敌
    //                if (SpriteMgr.getInstance().EnemySoldiers.Count > 0)
    //                {
    //                    //进入锁敌状态
    //                    setState(_findEnemyState);
    //                }
    //            }
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


    ///// <summary>
    ///// 动画回调
    ///// </summary>
    //public override void animationCall(int type)
    //{
    //    //Debug.Log("type==" + type);
    //    //根据返回的类别进行处理
    //    switch (type)
    //    {
    //        case GeneralSoldier.HIT_THE_POINT_CALL_BACK:    //进入打击点

    //            //对方掉血
    //            bool isDead = SpriteMgr.getInstance().hit(this);

    //            //目标是否死亡
    //            if (isDead)
    //            {
    //                //将自己目标置空
    //                data.AttackTarget = null;
    //            }
    //            break;

    //        case GeneralSoldier.HIT_THE_END_CALL_BACK:     //本次攻击结束
    //            attackState.init();
    //            break;

    //        case GeneralSoldier.DEAD_OVER_CALL_BACK:       //死亡动画播放完毕
    //            //销毁
    //            GameObject.Destroy(this.gameObject);
    //            mapUnRegist();
    //            break;

    //        case GeneralSoldier.HURT_OVER_CALL_BACK:       //受攻击动画播放完毕
    //            //进入锁敌状态
    //            setState(_findEnemyState);
    //            break;
    //    }
    //}
}