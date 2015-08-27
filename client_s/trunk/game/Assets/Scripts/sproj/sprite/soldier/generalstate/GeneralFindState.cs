using UnityEngine;
using System.Collections.Generic;

using XingLuoTianXia.lib;

/// <summary>
/// 通用寻敌状态
/// </summary>
public class GeneralFindState : XLStateBase
{
    /// <summary>
    /// 找到攻击目标事件
    /// </summary>
    public const int FINDED_EVENT = 0;

    /// <summary>
    /// 敌人全部死亡事件
    /// </summary>
    public const int ENEMY_IS_NULL = 1;

    /// <summary>
    /// 宿主
    /// </summary>
    private GeneralSoldier _host;

    /// <summary>
    /// 动画
    /// </summary>
    protected Animator animator;

    /// <summary>
    /// 待机状态构造函数
    /// </summary>
    /// <param name="host"></param>
    public GeneralFindState(GeneralSoldier host)
        : base(host)
    {
        _host = host;
    }


    /// <summary>
    /// 每帧的更新
    /// </summary>
    public override void update()
    {
        //先决条件
        if (!_host || _host._data == null)
        {
            return;
        }

        _host._data.AttackTarget = SpriteMgr.getInstance().getCloselyMatchSprite(_host, null);

        //对手全部被消灭，返回
        if (_host._data.AttackTarget == null)
        {
            notifyEvent(ENEMY_IS_NULL);
            return;
        }
        else  //发锁敌完毕消息
        {
            notifyEvent(FINDED_EVENT);
        }
    }
}
