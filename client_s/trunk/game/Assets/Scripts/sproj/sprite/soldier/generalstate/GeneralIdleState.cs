using UnityEngine;

using XingLuoTianXia.lib;

/// <summary>
/// 通用待机状态
/// </summary>
public class GeneralIdleState : XLStateBase
{
    private GeneralSoldier _host;

    /// <summary>
    /// 待机状态构造函数
    /// </summary>
    /// <param name="host"></param>
    public GeneralIdleState(GeneralSoldier host)
        : base(host)
    {
        _host = host;
    }

    /// <summary>
    /// 初始化
    /// </summary>
    public override void init()
    {
        //运行待机动画
        _host.GetComponent<Animator>().Play("idle01");
    }

    /// <summary>
    /// 每帧的更新
    /// </summary>
    public override void update()
    {

    }
}
