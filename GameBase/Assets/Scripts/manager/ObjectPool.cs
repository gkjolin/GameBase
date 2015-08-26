using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game
{
    public class ObjectPool<T> where T : class,new()
    {
        private Stack<T> _stack = new Stack<T>();//后进先出

        public T New()
        {
            return _stack.Count == 0 ? new T() : _stack.Pop();
        }

        //缓存对象
        public void Store(T t)
        {
            _stack.Push(t);
        }
        //重置对象
        public void Reset(T t)  
        {

        }

        //当缓存对象太多时候，又用的很少的时候，控制数量，销毁掉一部分
        public void ControlNum()
        {

        }
    }
}
