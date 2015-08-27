using UnityEngine;
using System.Collections.Generic;

namespace XingLuoTianXia.lib 
{
    /// <summary>
    /// 状态基类
    /// @author CJC
    /// </summary>
    public abstract class XLStateBase
    {
        /// <summary>
        /// 宿主
        /// </summary>
        private XLStateListener _listener;

        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="host"></param>
        public XLStateBase(XLStateListener listener)
        {
            // 断言：宿主必须不能为空
            System.Diagnostics.Debug.Assert(listener != null);

            _listener = listener;
        }

        /// <summary>
        /// 初始化
        /// </summary>
        public virtual void init()
        {

        }

        /// <summary>
        /// 行为决策
        /// </summary>
        public virtual void decisionAction()
        {

        }

        /// <summary>
        /// 状态暂停
        /// </summary>
        public virtual void pause()
        {

        }

        /// <summary>
        /// 状态恢复
        /// </summary>
        public virtual void resume()
        {

        }

        /// <summary>
        /// 状态停止
        /// </summary>
        public virtual void stop()
        {

        }

        /// <summary>
        /// 逻辑更新
        /// </summary>
        public abstract void update();

        /// <summary>
        /// 事件通知，仅有唯一一个事件的
        /// </summary>
        public void notifyEvent()
        {
            notifyEvent(-1, null);
        }

        /// <summary>
        /// 事件通知，不带推送消息的
        /// </summary>
        /// <param name="eventId"></param>
        public void notifyEvent(int eventId)
        {
            notifyEvent(eventId, null);
        }

        /// <summary>
        /// 事件通知，带推送消息的
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="eventData"></param>
        public void notifyEvent(int eventId, Object eventData)
        {
            _listener.notifyEvent(this, eventId, eventData);
        }
    }

}
