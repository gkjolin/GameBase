
namespace XingLuoTianXia.lib 
{
    /// <summary>
    /// 时间监听组
    /// </summary>
    public class TimerListener
    {

        /// <summary>
        /// 时间监听者
        /// </summary>
        public ITimeListener listener;

        /// <summary>
        /// 时间间隔
        /// </summary>
        public float interval;

        /// <summary>
        /// 循环次数
        /// </summary>
        public int number = 0;

        /// <summary>
        /// 是否运行
        /// </summary>
        public bool isRunning = false;




        public TimerListener(ITimeListener listener_, float interval_, int number_ = 0, bool isRunning_ = false)
        {
            this.listener = listener_;
            this.interval = interval_;
            this.number = number_;
            this.isRunning = isRunning_;
        }
    }
}
