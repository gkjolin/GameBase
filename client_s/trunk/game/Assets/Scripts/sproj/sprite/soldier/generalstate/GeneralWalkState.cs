using UnityEngine;
using System.Collections;

using XingLuoTianXia.lib;

/// <summary>
/// 行走的状态
/// @author CJC
/// @date 2015-08
/// </summary>
public class GeneralWalkState : XLStateBase
{
    /// <summary>
    /// 事件通知-转到进攻
    /// </summary>
    public static readonly int EVENT_CHANGE_TO_ATTACK = SpriteMgr.getInstance().EventID;

    /// <summary>
    /// 每过这么多帧就检测一下移动的距离
    /// </summary>
    private static readonly int CHECK_MOVE_FRAME_COUNT = 100;

    /// <summary>
    /// 避让的总帧数
    /// </summary>
    private static readonly int DODGE_FRAME_COUNT_MAX = 120;

    /// <summary>
    /// 目标精灵
    /// </summary>
    private XLSpriteBase _target;
    public XLSpriteBase Target
    {
        get { return _target; }
    }

    /// <summary>
    /// 目标的坐标
    /// </summary>
    private Vector3 _targetPostion;

    /// <summary>
    /// 宿主
    /// </summary>
    private GeneralSoldier _host;

    /// <summary>
    /// 寻路代理器
    /// </summary>
    private NavMeshAgent _navmeshAgent;

    /// <summary>
    /// 避让开始坐标
    /// </summary>
    private Vector3 _dodgeStartPosition;
    private int _oldPositionCount = 0;
    
    /// <summary>
    /// 避让计数器
    /// </summary>
    private int _dodgeFrameCount;

    /// <summary>
    /// 躲避距离
    /// </summary>
    private float _dodgeDistance = 8.0f;

    /// <summary>
    /// 避让目标点
    /// </summary>
    private Vector3 _dodgeTargetPosition;

    /// <summary>
    /// 攻击状态构造函数
    /// </summary>
    /// <param name="host"></param>
    public GeneralWalkState(GeneralSoldier host)
        : base(host)
    {
        //取得士兵和动画
        _host = host;
        _navmeshAgent = _host.GetComponent<NavMeshAgent>();
    }

    /// <summary>
    /// 初始化
    /// </summary>
    public override void init()
    {
        _target = null;

        //播放移动动作
        _host.GetComponent<Animator>().Play("run01");

        _host.walkStop();

        _host.walkEnable();
    }

    /// <summary>
    /// 逻辑更新
    /// </summary>
    public override void update() 
    {
        if(_target == null) // 是否没有目标
        {
            _host.walkStop();

            _target = SpriteMgr.getInstance().getCloselyMatchSprite(_host, null);
            if(_target != null)
            {
                _targetPostion = new Vector3(_target.transform.position.x, _target.transform.position.y, _target.transform.position.z);

                _oldPositionCount = 0;
                _dodgeStartPosition = new Vector3(_host.transform.position.x, _host.transform.position.y, _host.transform.position.z);

                //设置寻路的目标点  
                _navmeshAgent.SetDestination(_targetPostion);

                // 如果带转向就过于愣了，所以注视掉  
                // _host.transform.LookAt(new Vector3(_targetPostion.x, _host.transform.position.y, _targetPostion.z));
            }
            return;        
        }

        // 没在避让
        if (_dodgeFrameCount == 0)
        {
            _oldPositionCount++;
            if (_oldPositionCount > CHECK_MOVE_FRAME_COUNT) // 数帧检测移动量
            {
                float moveDistance = Vector3.Distance(_host.transform.position, _dodgeStartPosition);
                if(moveDistance<3.0f) // 移动量太小
                {
                    // 一半概率向左
                    if (Random.value<0.5f)
                    {
                        _dodgeTargetPosition = _host.DodgeLeftPostion;
                    }
                    else // 一半概率向右
                    {
                        _dodgeTargetPosition = _host.DodgeRightPostion;
                    }
                    _navmeshAgent.SetDestination(_dodgeTargetPosition);

                    //转向  
                    _host.transform.LookAt(new Vector3(_dodgeTargetPosition.x, _host.transform.position.y, _dodgeTargetPosition.z));

                    _dodgeFrameCount = DODGE_FRAME_COUNT_MAX;
                }

                _oldPositionCount = 0;
                _dodgeStartPosition = new Vector3(_host.transform.position.x, _host.transform.position.y, _host.transform.position.z);
            }
        }
        else // 避让中 
        {
            _dodgeFrameCount--;
            if (_dodgeFrameCount == 0)
            {
                _target = null;
                return;
            }

            float dis = Vector3.Distance(_host.transform.position, _dodgeTargetPosition);
            if (dis<0.2)
            {
                _target = null;
                return;
            }
            return;
        }

        // 判断目标距离<攻击距离的时候，就可以结束了
        float hostToTargetDistance = Vector3.Distance(_host.transform.position, _targetPostion);
        _host._data.AttckDistance = 4f;
        if (hostToTargetDistance <= _host._data.AttckDistance)
        {
            _host.walkStop();

            notifyEvent(EVENT_CHANGE_TO_ATTACK, _target);
            return;
        }
    }
}
