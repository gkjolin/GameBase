using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Game
{
    public class DataEventSource : Singleton<DataEventSource>
    {

#region ui之间的事件通知
        //事件绑定 适用于 UI 之间的通知 ，ui 销毁时候，uibase直接移除事件监听，不用手动移除
        private Dictionary<DataEvent, List<UIBase>> _dict = new Dictionary<DataEvent, List<UIBase>>();
        /// <summary>
        /// ui event
        /// </summary>
        /// <param name="eventKey"></param>
        /// <param name="ui"></param>
        public void RegEvent(DataEvent eventKey, UIBase ui)
        {
            List<UIBase> listUi;
            if (_dict.ContainsKey(eventKey) == false)
            {
                listUi = new List<UIBase>();
                _dict.Add(eventKey, listUi);
            }
            else
            {
                listUi = _dict[eventKey];
            }
            if (listUi.Contains(ui) == false)
            {
                ui.AddEvent(eventKey);
                listUi.Add(ui);
                _dict[eventKey] = listUi;
            }

        }
        /// <summary>
        /// ui event
        /// </summary>
        /// <param name="eventKey"></param>
        /// <param name="ui"></param>
        public void UnRegEvent(DataEvent eventKey, UIBase ui)
        {
            if (_dict.ContainsKey(eventKey))
            {
                List<UIBase> listUi = _dict[eventKey];
                if (listUi.Contains(ui) == true)
                {
                    listUi.Remove(ui);
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="eventArgs"></param>
        public void FireUIEvent<T>(DataEventArgs<T> eventArgs)
        {
            DataEvent key = eventArgs.EventName;
            List<UIBase> listUi = _dict[key];
            foreach (UIBase ui in listUi)
            {
                ui.HandlerData(eventArgs);
            }
        }

#endregion

#region 适用于各种 监听，派发

        private Dictionary<string, List<Action<object>>> _dictEvent = new Dictionary<string, List<Action<object>>>();
        public void DispatcherEvent(string eventName, object _args,float durationTime = 0.0f)
        {
            GlobalData.Instance.Delay(durationTime, () => { 

                if (_dictEvent.ContainsKey(eventName))
                {
                    List<Action<object>> _list = _dictEvent[eventName];
                    for (int i = 0; i < _list.Count; i++)
                    {
                        Action<object> _action = _list[i];
                        _action(_args);
                    }
                }

            });

        }

        public void AddEventListener(string eventName, Action<object> _action)
        {
            List<Action<object>> _list;
            if (_dictEvent.ContainsKey(eventName))
            {
                _list = _dictEvent[eventName];
            }
            else
            {
                _list = new List<Action<object>>();
                _dictEvent.Add(eventName, _list);
            }
            if (!_list.Contains(_action))
                _list.Add(_action);
        }

        public void RemoveEventListener(string eventName, Action<object> _action)
        {
            if (_dictEvent.ContainsKey(eventName))
            {
                List<Action<object>> _list = _dictEvent[eventName];
                if (_list.Contains(_action))
                    _list.Remove(_action);
            }
        }
#endregion
    }
}
