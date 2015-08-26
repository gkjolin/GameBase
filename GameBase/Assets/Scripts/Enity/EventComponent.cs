using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game
{
    public delegate void EventHandle();
    public class EventComponent : BaseComponent
    {
        //private Dictionary<string, List<Action>> _dic = new Dictionary<string, List<Action>>();
        private Dictionary<string, EventHandle> _dict = new Dictionary<string, EventHandle>();


        public void AddEventListener(string key, EventHandle handle)
        {
            if (_dict.ContainsKey(key))
            {
                Delegate[] _delegates = _dict[key].GetInvocationList();
                for (int i = 0; i < _delegates.Length; i++)
                {
                    if (_delegates[i] == handle)
                    {
                        return;
                    }
                }
                _dict[key] += handle;
            }
            else
            {
                _dict.Add(key, handle);
            }
        }

        public void RemoveEventListener(string key, EventHandle handle)
        {
            if (_dict.ContainsKey(key))
            {
                Delegate[] _delegates = _dict[key].GetInvocationList();
                for (int i = 0; i < _delegates.Length; i++)
                {
                    if (_delegates[i] == handle)
                    {
                        _dict[key] -= handle;
                        return;
                    }
                }

                if (_dict[key] == null)
                {
                    _dict.Remove(key);
                }
            }
        }

        public void DispatcherEvent(string key)
        {
            if (_dict.ContainsKey(key))
            {
                _dict[key]();
            }
        }

        /*public void DispatcherEvent(string _key)
        {
            if (_dic.ContainsKey(_key))
            {
                List<Action> _list = _dic[_key];
                for (int i = 0; i < _list.Count; i++)
                {
                    _list[0]();
                }
            }
        }

        public void AddEventListener(string _key, Action _action)
        {
            List<Action> _list;
            if (_dic.ContainsKey(_key))
            {
                _list = _dic[_key];
            }
            else
            {
                _list = new List<Action>();
                _dic.Add(_key, _list);
            }
            _list.Add(_action);
        }

        public void RemoveEventListener(string _key, Action _action)
        {
            if (_dic.ContainsKey(_key))
            {
                List<Action> _list = _dic[_key];
                if (_list.Contains(_action))
                    _list.Remove(_action);
            }
        }*/

    }
}
