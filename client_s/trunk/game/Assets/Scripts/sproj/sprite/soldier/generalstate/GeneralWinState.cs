using UnityEngine;

using XingLuoTianXia.lib;

/// <summary>
/// 通用胜利状态
/// </summary>
public class GeneralWinState : XLStateBase
 {
    private GeneralSoldier _host;

    /// <summary>
    /// 待机状态构造函数
    /// </summary>
    /// <param name="host"></param>
    public GeneralWinState(GeneralSoldier host)
        : base(host)
    {
        //取得士兵的动画
        _host = host;
    }

    public override void init()
    {
        iTween.Stop(_host.gameObject);
    }

    /// <summary>
    /// 每帧的更新
    /// </summary>
    public override void update()
    {
        _host.GetComponent<Animator>().Play("win01");
    }
}
