using UnityEngine;
using System.Collections;

namespace XingLuoTianXia.lib 
{
    public interface XLStateListener
    {
        /// <summary>
        /// 来自于状态的事件通知
        /// </summary>
        /// <param name="sender"></param> 事件发起者
        /// <param name="eventId"></param> 事件ID
        /// <param name="eventData"></param> 事件推送的数据
        bool notifyEvent(XLStateBase sender, int eventId, Object eventData);
    }
}
