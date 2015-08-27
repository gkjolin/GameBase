using System.Collections.Generic;

namespace XingLuoTianXia.lib 
{
    /// <summary>
    /// 观察者接口
    /// </summary>
    public interface IObserver
    {


        /// <summary>
        /// 观察者关心的消息列表
        /// </summary>
        /// <returns></returns>
        IList<string> listNotificationInterests();


        /// <summary>
        /// 接收关心的消息的方法
        /// </summary>
        /// <param name="notification"></param>
        void handleNotification(XLNotification notification);

    }

}
