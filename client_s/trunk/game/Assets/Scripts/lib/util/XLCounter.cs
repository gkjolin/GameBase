using UnityEngine;
using System.Collections;

namespace XingLuoTianXia.lib 
{
    /// <summary>
    /// 累加计数器
    /// @author CJC
    /// @date 2015.0610
    /// </summary>
    public class XLCounter
    {
        /// <summary>
        /// 累加计数
        /// </summary>
        private int _count = 0;

        /// <summary>
        /// 构造
        /// </summary>
        public XLCounter()
        {

        }

        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="count"></param>
        public XLCounter(int count)
        {
            setCount(count);
        }

        /// <summary>
        /// 设置count
        /// </summary>
        /// <param name="count"></param>
        public void setCount(int count)
        {
            _count = count;
        }

        /// <summary>
        /// 获取下个数
        /// </summary>
        /// <returns></returns>
        public int getNext()
        {
            int ret = _count;
            _count++;
            return ret;
        }
    }
}
