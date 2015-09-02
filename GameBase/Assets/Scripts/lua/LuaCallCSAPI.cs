using UnityEngine;
using System.Collections;
using SLua;
using Game;
public class LuaCallCSAPI : MonoBehaviour {

    private LuaSvr svr;
    private LuaTable self;
    private static LuaCallCSAPI _instance;

    public static LuaCallCSAPI Instance
    {
        get { return LuaCallCSAPI._instance; }
    }
    void Awake()
    {
        _instance = this;
        svr = new LuaSvr();
        self = (LuaTable)svr.start("LuaFiles/LuaCallCsAPI");
        self["event"] = DataEventSource.Instance;
        self["name"] = "API";
    }

	void Start () {
        DataEventSource.Instance.AddEventListener("luaCallCS", callBack);
        //DataEventSource.Instance.DispatcherEvent("luaCallCS", 1);
	}

    private void callBack(object obj)
    {
        Debug.Log("lua call cs success  " + obj);
    }

    public LuaTable CSAPI
    {
        get { return self; }
    }
}
