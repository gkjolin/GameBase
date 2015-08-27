using System.Collections.Generic;

namespace XingLuoTianXia.lib 
{
    /// <summary>
    /// 消息管理器
    /// </summary>
    public class XLMessageManager
    {

        /// <summary>
        /// 观察者容器
        /// </summary>
        private static Dictionary<string, IList<IObserver>> _observers = new Dictionary<string, IList<IObserver>>();


        /// <summary>
        /// 单例
        /// </summary>
        private static XLMessageManager _instance = null;


        /// <summary>
        /// 单例
        /// </summary>
        /// <returns></returns>
        public static XLMessageManager getInstance()
        {
            if (_instance == null)
            {
                _instance = new XLMessageManager();
            }
            return _instance;
        }


        /// <summary>
        /// 注册观察者
        /// </summary>
        /// <param name="observer"></param>
        public void register(IObserver observer)
        {
            IList<string> notificationList = observer.listNotificationInterests();

            for (int i = 0; i < notificationList.Count; i++)
            {
                if (!_observers.ContainsKey(notificationList[i]))
                {
                    _observers[notificationList[i]] = new List<IObserver>();
                }
                _observers[notificationList[i]].Add(observer);
            }
        }


        /// <summary>
        /// 移除观察者
        /// </summary>
        /// <param name="observer"></param>
        public void remove(IObserver observer)
        {
            //取得观察者关心的所有消息
            IList<string> notificationList = observer.listNotificationInterests();

            //遍历关心的消息，一个一个移除
            for (int i = 0; i < notificationList.Count; i++)
            {
                //消息容器是否存在
                if (_observers.ContainsKey(notificationList[i]))
                {
                    _observers[notificationList[i]].Remove(observer);

                    if (_observers[notificationList[i]].Count == 0)
                    {
                        _observers.Remove(notificationList[i]);
                    }
                }
            }
        }

        /// <summary>
        /// 发布消息
        /// </summary>
        /// <param name="notificationName"></param>
        public virtual void sendNotification(string notificationName)
        {
            send(new XLNotification(notificationName));
        }
        /// <summary>
        /// 发布消息
        /// </summary>
        /// <param name="notificationName"></param>
        /// <param name="body"></param>
        public virtual void sendNotification(string notificationName, object body)
        {
            send(new XLNotification(notificationName, body));
        }
        /// <summary>
        /// 发布消息
        /// </summary>
        /// <param name="notificationName"></param>
        /// <param name="body"></param>
        /// <param name="type"></param>
        public virtual void sendNotification(string notificationName, object body, string type)
        {
            send(new XLNotification(notificationName, body, type));
        }


        /// <summary>
        /// 派发消息
        /// </summary>
        /// <param name="notification"></param>
        private void send(XLNotification notification)
        {
            if (_observers.ContainsKey(notification.Name))
            {
                IList<IObserver> observers = _observers[notification.Name];

                for (int i = 0; i < observers.Count; i++)
                {
                    observers[i].handleNotification(notification);
                }
            }
        }
    }
}

