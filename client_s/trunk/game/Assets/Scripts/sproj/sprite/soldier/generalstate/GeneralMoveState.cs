using UnityEngine;

using XingLuoTianXia.lib;

/// <summary>
/// 通用靠近目标状态
/// </summary>
public class GeneralMoveState : XLStateBase
{
    /// <summary>
    /// 靠近执行完毕事件
    /// </summary>
    public const int MOVE_COMPLETE_EVENT = 0;

    /// <summary>
    /// 动画
    /// </summary>
    Animator animator;

    /// <summary>
    /// 宿主
    /// </summary>
    private GeneralSoldier _host;


    /// <summary>
    /// 待机状态构造函数
    /// </summary>
    /// <param name="host"></param>
    public GeneralMoveState(GeneralSoldier host)
        : base(host)
    {
        _host = host;
    }

    /// <summary>
    /// 每帧的更新
    /// </summary>
    public override void update()
    {
        if (_host == null)
        {
            return;
        }

        //播放移动动作
        _host.GetComponent<Animator>().Play("run01");

        //面向敌人
        _host.gameObject.transform.LookAt(_host._data.AttackTarget.gameObject.transform);

        //向目标靠近,靠近速度是自身的移动速度
        _host.gameObject.transform.Translate(Vector3.forward * Time.deltaTime * _host._data.MoveSpeed);

        //如果进入攻击范围，靠近行为结束
        if (Vector3.Distance(_host.transform.position, _host._data.AttackTarget.transform.position) <= _host._data.AttckDistance)
        {
            //发靠近行为结束消息
            notifyEvent(MOVE_COMPLETE_EVENT);
        }

    }
}
