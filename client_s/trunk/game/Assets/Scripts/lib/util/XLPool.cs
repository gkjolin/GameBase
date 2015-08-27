using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace XingLuoTianXia.lib 
{
    /// <summary>
    /// 对象池基类
    /// @author CJC
    /// @date 2015-0423
    /// </summary>
    public abstract class XLPool<T>
    {
        /// <summary>
        /// 空闲可用的对象
        /// </summary>
        protected Stack<T> _freeChilds = new Stack<T>();

        /// <summary>
        /// 初始化指定个数的子对象
        /// </summary>
        /// <param name="size"></param>
        public void init(int size)
        {
            for (int i = 0; i < size; i++)
            {
                T t = createChild();
                add(t);
            }
        }

        /// <summary>
        /// 获取当前已经创建好的子对象的数量
        /// </summary>
        /// <returns></returns>
        public int getFreeChildCount()
        {
            return _freeChilds.Count;
        }

        /// <summary>
        /// 获取一个子对象
        /// </summary>
        /// <returns></returns>
        public T getFreeChild()
        {
            // 先找
            if (_freeChilds.Count > 0)
            {
                return _freeChilds.Pop();
            }

            // 创建
            return createChild();
        }

        /// <summary>
        /// 添加子对象
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool add(T t)
        {
            if (t == null)
            {
                return false;
            }

            _freeChilds.Push(t);
            return true;
        }

        /// <summary>
        /// 创建对象的函数，需要继承类来实现
        /// </summary>
        /// <returns></returns>
        public abstract T createChild();
    }
}
