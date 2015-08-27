using UnityEngine;

using XingLuoTianXia.lib;

/// <summary>
/// 通用死亡状态
/// </summary>
public class GeneralDeadState : XLStateBase
{
    /// <summary>
    /// 死亡行为执行完毕事件
    /// </summary>
    public const int DEAD_COMPLETE_EVENT = 0;


    /// <summary>
    /// 死亡动画持续时间
    /// </summary>
    private int _deadDelay;

    /// <summary>
    /// 宿主
    /// </summary>
    private GeneralSoldier _host;


    /// <summary>
    /// 待机状态构造函数
    /// </summary>
    /// <param name="host"></param>
    public GeneralDeadState(GeneralSoldier host)
        : base(host)
    {
        _host = host;

        //初始化
        init();
    }

    /// <summary>
    /// 初始化
    /// </summary>
    public override void init()
    {
        if (_host == null)
        {
            return;
        }

        if (_host._data == null)
        {
            return;
        }

        //取得死亡延时
        _deadDelay = _host._data.DeadDelay;
    }


    /// <summary>
    /// 每帧的更新
    /// </summary>
    public override void update()
    {
        //如果死亡
        if (_deadDelay <= 0)
        {
            _host.notifyEvent(this, DEAD_COMPLETE_EVENT, null);
            return;
        }

        //计时
        _deadDelay--;

        //播放死亡动画
        _host.GetComponent<Animator>().Play("die01");
    }
}
