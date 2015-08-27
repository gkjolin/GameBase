using UnityEngine;
using System.Collections;

using XingLuoTianXia.lib;

/// <summary>
/// 通用攻击状态
/// </summary>
public class GeneralAttackState : XLStateBase
{
    /// <summary>
    /// 攻击目标为空事件
    /// </summary>
    public const int ATTACK_TARGET_IS_NULL = 0;

    /// <summary>
    /// 攻击目标不在攻击范围内
    /// </summary>
    public const int ATTACK_TARGET_IS_OUT = 1;


    /// <summary>
    /// 攻击CD
    /// </summary>
    private float ATKSpeed;

    /// <summary>
    /// 是否正在攻击
    /// </summary>
    public bool isAttack = false;

    /// <summary>
    /// 动画
    /// </summary>
    protected Animator animator;

    /// <summary>
    /// 宿主
    /// </summary>
    protected GeneralSoldier soldier;

    /// <summary>
    /// 攻击状态构造函数
    /// </summary>
    /// <param name="host"></param>
    public GeneralAttackState(GeneralSoldier host)
        : base(host)
    {
        //取得士兵和动画
        soldier = host;
        animator = soldier.GetComponent<Animator>();
    }

    /// <summary>
    /// 初始化
    /// </summary>
    public override void init()
    {
        ATKSpeed = soldier._data.Interval;
        isAttack = true;
    }

    /// <summary>
    /// 每帧的更新
    /// </summary>
    public override void update()
    {
        //先决条件
        if (soldier == null || soldier._data == null)
        {
            return;
        }

        //如果攻击目标为空，返回事件
        if (soldier._data.AttackTarget == null)
        {
            soldier.notifyEvent(this, ATTACK_TARGET_IS_NULL, null);
            return;
        }

        //如果目标在攻击范围外，返回事件
        //soldier._data.AttckDistance = 3f; // TODO
        if (Vector3.Distance(soldier.transform.position, soldier._data.AttackTarget.transform.position) > soldier._data.AttckDistance)
        {
            soldier.notifyEvent(this, ATTACK_TARGET_IS_OUT, null);
            return;
        }

        //攻击
        if (isAttack)
        {
            //CD减少
            ATKSpeed--;

            //如果攻击CD为0，开始1次攻击
            if (ATKSpeed <= 0)
            {
                //停止攻击
                isAttack = false;

                //面向敌人
                soldier.gameObject.transform.LookAt(soldier._data.AttackTarget.gameObject.transform);

                //播放攻击动作
                animator.Play("attack01");
            }
            else
            {
                //播放待机动作
                animator.Play("idle03");
            }
        }
    }
}
