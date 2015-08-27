
namespace XingLuoTianXia.lib 
{
    /// <summary>
    /// 消息体
    /// </summary>
    public class XLNotification
    {
        /// <summary>
        /// 消息ID
        /// </summary>
        private string m_name;

        /// <summary>
        /// 消息类别
        /// </summary>
        private string m_type;

        /// <summary>
        /// 消息的数据体
        /// </summary>
        private object m_body;


        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="name"></param>
        public XLNotification(string name)
            : this(name, null, null)
        { }

        public XLNotification(string name, object body)
            : this(name, body, null)
        { }

        public XLNotification(string name, object body, string type)
        {
            m_name = name;
            m_body = body;
            m_type = type;
        }

        /// <summary>
        /// 取得消息ID
        /// </summary>
        public virtual string Name
        {
            get { return m_name; }
        }

        /// <summary>
        /// 取得消息的数据体
        /// </summary>
        public virtual object Body
        {
            get
            {
                return m_body;
            }
            set
            {
                m_body = value;
            }
        }

        /// <summary>
        /// 取得消息的类别
        /// </summary>
        public virtual string Type
        {
            get
            {
                return m_type;
            }
            set
            {
                m_type = value;
            }
        }

        /// <summary>
        /// 将消息转化成字符串
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string msg = "Notification Name: " + Name;
            msg += "\nBody:" + ((Body == null) ? "null" : Body.ToString());
            msg += "\nType:" + ((Type == null) ? "null" : Type);
            return msg;
        }
    }
}
