using UnityEngine;

using XingLuoTianXia.lib;

/// <summary>
/// 通用受击状态
/// </summary>
public class GeneralHurtState : XLStateBase
{
    /// <summary>
    /// 动画
    /// </summary>
    protected Animator animator;

    /// <summary>
    /// 宿主
    /// </summary>
    protected GeneralSoldier soldier;

    /// <summary>
    /// 是否正在播动画
    /// </summary>
    public bool isPlaying = false;






    /// <summary>
    /// 攻击状态构造函数
    /// </summary>
    /// <param name="host"></param>
    public GeneralHurtState(GeneralSoldier host)
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
        isPlaying = false;
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

        //如果没播放动画
        if (!isPlaying)
        {
            //开始播动画
            isPlaying = true;
            animator.Play("hit01");
        }
    }
}
