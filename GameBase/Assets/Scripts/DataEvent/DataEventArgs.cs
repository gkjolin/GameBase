
using System;
using System.Collections.Generic;
using System.Linq;

namespace Game
{
    public class DataEventArgs<T>
    {
        private DataEvent _eventName;
        private T _data;//改为 泛型 T 

        public DataEventArgs(DataEvent eventName, T _t)
        {
            _eventName = eventName;
            _data = _t;
        }



        public T Data
        {
            get { return _data; }
        }

        public DataEvent EventName
        {
            get { return _eventName; }
        }
    }
}
