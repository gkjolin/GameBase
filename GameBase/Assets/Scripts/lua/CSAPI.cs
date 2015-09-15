using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using SLua;
using Game;

[CustomLuaClass]
public class CSAPI
{
    public static void Log(string s)
    {
        Debug.Log(s);
    }

    public static void DispatcherEvent(string eventName,object args,float duration = 0.0f)
    {
        DataEventSource.Instance.DispatcherEvent(eventName, args, duration);
    }

    public static void AddEventListener(string eventName,Action<object> _action)
    {
        DataEventSource.Instance.AddEventListener(eventName, _action);
    }

    public static void TestT<T>(string name)where T:MonoBehaviour
    {
        UIMgr.Instance.LoadUIPrefab<T>(name);
    }

    public static void CallBack(Action _action)
    {
        if (_action != null) { _action(); }
    }
}
