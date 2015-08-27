using UnityEngine;
using System.Collections;

namespace XingLuoTianXia.lib 
{
    /// <summary>
    /// 链表节点池
    /// @author CJC
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class XLLinkedNodePool<X> : XLPool<XLLinkedNode<X>>
    {
        /// <summary>
        /// 创建对象的函数，需要继承类来实现
        /// </summary>
        /// <returns></returns>
        public override XLLinkedNode<X> createChild()
        {
            return new XLLinkedNode<X>();
        }
    }
}

