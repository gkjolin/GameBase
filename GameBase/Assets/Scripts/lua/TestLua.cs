using UnityEngine;
using System.Collections;
using SLua;
using System.Collections.Generic;

public class TestLua : MonoBehaviour {

    LuaSvr lua;
    LuaTable self;
    LuaFunction test2;
    LuaFunction SetTransform;
    public Transform tr;
    void Start()
    {
        lua = new LuaSvr();
        self = (LuaTable)lua.start("LuaFiles/building_txt");
        //self = (LuaTable)lua.luaState.getObject("data");
        //object o = lua.luaState.getFunction("GetData").call();
        Debug.Log("table " + ((LuaTable)self[1])["name"]);


        LuaFunction dataFunction = ((LuaFunction)self["GetData"]);
        LuaTable dataTable = (LuaTable)dataFunction.call();
        LuaFunction callFunction = (LuaFunction)self["CallBack"];
        callFunction.call(222);
        //lua.luaState.getFunction("CallBack").call();
        lua.luaState.getFunction("Call").call(2);
        Debug.Log("table " + ((LuaTable)dataTable[1])["use_money"] + "   is Null " + (callFunction == null));


        LuaTable d = (LuaTable)((LuaFunction)self["GetData1"]).call();
        Debug.Log("---------------- : " + ((LuaTable)d[1])["use_money"]);
        LuaTable table2 = (LuaTable)lua.start("LuaFiles/building_txt1");

        test2 = (LuaFunction)self["test"];
        object o = test2.call(self,9,1);
        Debug.Log("add function :"+o);

        SetTransform = (LuaFunction)self["SetTransform"];
        SetTransform.call(self, tr);
        //tr.localPosition = new Vector3(2, 2, 2);
    }

}
