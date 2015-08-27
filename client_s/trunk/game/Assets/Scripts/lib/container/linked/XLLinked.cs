using UnityEngine;
using System.Collections;

namespace XingLuoTianXia.lib 
{
    /// <summary>
    /// 链表节点
    /// @author CJC
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class XLLinked<T>
    {
        /// <summary>
        /// 节点数量
        /// </summary>
        private int _count = 0;
        public int Count
        {
            get { return _count; }
        }

        /// <summary>
        /// 开始节点
        /// </summary>
        private XLLinkedNode<T> _startNode = null;
        public XLLinkedNode<T> StartNode
        {
            get { return _startNode; }
        }

        /// <summary>
        /// 末尾节点
        /// </summary>
        private XLLinkedNode<T> _endNode = null;
        public XLLinkedNode<T> EndNode
        {
            get { return _endNode; }
        }

        private XLLinkedNodePool<T> _pool = null;

        /// <summary>
        /// 构造
        /// </summary>
        public XLLinked()
        {

        }

        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="pool"></param>
        public XLLinked(XLLinkedNodePool<T> pool)
        {
            _pool = pool;
        }

        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="linked"></param>
        public XLLinked(XLLinked<T> linked)
        {
            if (linked != null && linked.Count > 0)
            {
                XLLinkedNode<T> temp = linked.StartNode;
                while (temp != null)
                {
                    add(temp);
                    temp = temp.Next;
                }
            }
        }

        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="linked"></param>
        /// <param name="pool"></param>
        public XLLinked(XLLinked<T> linked, XLLinkedNodePool<T> pool)
        {
            _pool = pool;

            if (linked != null && linked.Count > 0)
            {
                XLLinkedNode<T> last = null;
                XLLinkedNode<T> temp = linked.StartNode;
                while (temp != null)
                {
                    XLLinkedNode<T> newNode = createNode();
                    newNode.Data = temp.Data;
                    add(newNode);
                }
            }
        }

        public XLLinkedNode<T> createNode()
        {
            XLLinkedNode<T> ret = null;
            if (_pool != null)
            {
                ret = _pool.getFreeChild();
                ret.Next = null;
            }
            else
            {
                ret = new XLLinkedNode<T>();
            }
            return ret;
        }

        /// <summary>
        /// 全部清除
        /// </summary>
        public void clear()
        {
            if (_startNode == null)
            {
                return;
            }

            // 池回收
            if (_pool != null)
            {
                XLLinkedNode<T> temp = _startNode;
                while (temp != null)
                {
                    _pool.add(temp);
                    temp = temp.Next;
                }
            }

            _startNode = null;
            _endNode = null;
            _count = 0;
        }

        public bool contains(XLLinkedNode<T> node)
        {
            if (_startNode == null || node == null)
            {
                return false;
            }

            XLLinkedNode<T> temp = _startNode;
            while (temp != null)
            {
                if (temp == node)
                {
                    return true;
                }
                temp = _startNode.Next;
            }

            return false;
        }

        public bool contains(T data)
        {
            if (_startNode == null || data == null)
            {
                return false;
            }

            XLLinkedNode<T> temp = _startNode;
            while (temp != null)
            {
                if (temp.Data.Equals(data))
                {
                    return true;
                }
                temp = temp.Next;
            }

            return false;
        }

        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public XLLinkedNode<T> get(int idx)
        {
            if (_startNode == null)
            {
                return null;
            }

            // 头
            if (idx <= 0)
            {
                return _startNode;
            }

            // 尾
            if (idx >= _count)
            {
                return _endNode;
            }

            // 中段儿
            XLLinkedNode<T> temp = _startNode;
            for (int i = 1; i < _count; i++)
            {
                temp = _startNode.Next;

                if (idx == i)
                {
                    return temp;
                }
            }

            return null;
        }

        /// <summary>
        /// 删除节点
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public XLLinkedNode<T> remove(XLLinkedNode<T> node)
        {
            if (node == null || _startNode == null)
            {
                return null;
            }

            // 要删除的点是起始点
            if (_startNode == node)
            {
                // 池回收
                if (_pool != null)
                {
                    _pool.add(_startNode);
                }

                _startNode = _startNode.Next;
                _count--;
                return node;
            }

            // 要删除的点是中间点
            XLLinkedNode<T> pre = null;
            XLLinkedNode<T> temp = _startNode;
            while (temp != null)
            {
                if (temp == node)
                {
                    // 池回收
                    if (_pool != null)
                    {
                        _pool.add(temp);
                    }

                    pre.Next = temp.Next;
                    _count--;
                    return node;
                }
                pre = temp;
                temp = temp.Next;
            }

            return null;
        }

        public XLLinkedNode<T> remove(T data)
        {
            if (data == null || _startNode == null)
            {
                return null;
            }

            // 要删除的点是起始点
            if (_startNode.Data.Equals(data))
            {
                // 池回收
                if (_pool != null)
                {
                    _pool.add(_startNode);
                }

                XLLinkedNode<T> ret = _startNode;
                _startNode = _startNode.Next;
                _count--;
                return ret;
            }

            // 要删除的点是中间点
            XLLinkedNode<T> pre = null;
            XLLinkedNode<T> temp = _startNode;
            while (temp != null)
            {
                if (temp.Data.Equals(data))
                {
                    // 池回收
                    if (_pool != null)
                    {
                        _pool.add(temp);
                    }

                    XLLinkedNode<T> ret = temp;
                    pre.Next = temp.Next;
                    _count--;
                    return ret;
                }
                pre = temp;
                temp = temp.Next;
            }

            return null;
        }

        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="node"></param>
        /// <param name="idx"></param>
        /// <returns></returns>
        public XLLinkedNode<T> insert(XLLinkedNode<T> node, int idx)
        {
            if (node == null)
            {
                return null;
            }

            // 是否是空链表
            if (_startNode == null)
            {
                _startNode = node;
                _endNode = node;
                _count++;
                return node;
            }

            // 加在头上
            if (idx <= 0)
            {
                node.Next = _startNode;
                _startNode = node;
                _count++;
                return node;
            }

            // 加在末尾
            if (idx >= _count)
            {
                _endNode.Next = node;
                _endNode = node;
                _count++;
                return node;
            }

            // 加载中间
            XLLinkedNode<T> temp = _startNode;
            for (int i = 1; i < idx; i++)
            {
                temp = temp.Next;
            }
            node.Next = temp.Next;
            temp.Next = node;
            _count++;
            return node;
        }

        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="data"></param>
        /// <param name="idx"></param>
        /// <returns></returns>
        public XLLinkedNode<T> insert(T data, int idx)
        {
            if (data == null)
            {
                return null;
            }

            XLLinkedNode<T> newNode = createNode();
            newNode.Data = data;
            return insert(newNode, idx);
        }

        /// <summary>
        /// 添加在最后面
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public XLLinkedNode<T> add(XLLinkedNode<T> node)
        {
            if (node == null)
            {
                return null;
            }

            // 是否是空链表
            if (_startNode == null)
            {
                _startNode = node;
                _endNode = node;
                _count++;
                return node;
            }

            _endNode.Next = node;
            _endNode = node;
            _count++;
            return node;
        }

        /// <summary>
        /// 添加在最后面
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public XLLinkedNode<T> add(T data)
        {
            if (data == null)
            {
                return null;
            }

            XLLinkedNode<T> newNode = createNode();
            newNode.Data = data;
            return add(newNode);
        }

        /// <summary>
        /// debug显示
        /// </summary>
        public void debugShow()
        {
            if (_startNode == null)
            {
                Debug.Log("linked count is: 0");
                return;
            }

            XLLinkedNode<T> temp = _startNode;
            while (temp != null)
            {
                Debug.Log("temp:" + temp.Data);
                temp = temp.Next;
            }

            Debug.Log("---------------------");
        }
    }
}