
namespace XingLuoTianXia.lib
{
    /// <summary>
    /// 时间监听者接口
    /// </summary>
    public interface ITimeListener
    {

        /// <summary>
        /// 时间到的回调
        /// </summary>
        /// <param name="deltaTime"></param>
        void timerHandler(float deltaTime);
    }
}
    
