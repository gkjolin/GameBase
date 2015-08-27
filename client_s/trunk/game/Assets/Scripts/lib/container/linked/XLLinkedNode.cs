using UnityEngine;
using System.Collections;

namespace XingLuoTianXia.lib 
{
    /// <summary>
    /// 链表节点
    /// @author CJC
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class XLLinkedNode<T>
    {
        /// <summary>
        /// 链表数据
        /// </summary>
        private T _data;
        public T Data
        {
            get { return _data; }
            set { _data = value; }
        }

        /// <summary>
        /// 下一个节点
        /// </summary>
        private XLLinkedNode<T> _next;
        public XLLinkedNode<T> Next
        {
            get { return _next; }
            set { _next = value; }
        }

        /// <summary>
        /// 构造
        /// </summary>
        public XLLinkedNode()
        {

        }

        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="data"></param>
        public XLLinkedNode(T data)
        {
            _data = data;
        }
    }
}