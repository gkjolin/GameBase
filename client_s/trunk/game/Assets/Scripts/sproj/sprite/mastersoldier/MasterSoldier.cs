using UnityEngine;
using System.Collections;

public class MasterSoldier : GeneralSoldier {

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

    /// <summary>
    /// 动画回调
    /// </summary>
    public void animationCall(int type)
    {
        if (_data.Country == Defaults.Country.Me)
        {
            //Debug.Log(_data.Country + "士兵动画回调" + type);
        }

        //根据返回的类别进行处理
        switch (type)
        {
            case GeneralSoldier.HIT_THE_POINT_CALL_BACK:    //进入打击点

                //_data.SkillMgr.setSkills(this);
                //_data.SkillMgr.play(_data.Skills[0]);
             //   _data.SkillMgr.play(1005);

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
                GameObject.Destroy(this.gameObject);  //销毁
                break;

            case GeneralSoldier.HURT_OVER_CALL_BACK:       //受攻击动画播放完毕
                //进入锁敌状态
                setState(_walkState);
                break;
        }
    }
}
