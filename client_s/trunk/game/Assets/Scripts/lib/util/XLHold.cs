using UnityEngine;
using System.Collections;

namespace XingLuoTianXia.lib 
{
    /// <summary>
    /// 双值容器
    /// @author CJC
    /// @date 2015
    /// </summary>
    /// <typeparam name="L"></typeparam>
    /// <typeparam name="R"></typeparam>
    public class XLHold<L, R>
    {
        /** 左值对象 */
        private L m_left;

        /** 右值对象 */
        private R m_right;

        /**
         * 构造
         */
        public XLHold()
        {

        }

        /**
         * 构造
         * 
         * @param left
         * @param right
         */
        public XLHold(L left, R right)
        {
            m_left = left;
            m_right = right;
        }

        /**
         * 获取左值对象
         * 
         * @return L
         */
        public L getL()
        {
            return m_left;
        }

        /**
         * 设置左值对象
         * 
         * @param left
         */
        public void setL(L left)
        {
            m_left = left;
        }

        /**
         * 获取右值对象
         * 
         * @return R
         */
        public R getR()
        {
            return m_right;
        }

        /**
         * 设置右值对象
         * 
         * @param right
         */
        public void setR(R right)
        {
            m_right = right;
        }
    }
}