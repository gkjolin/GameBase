using UnityEngine;
using System.Collections;
using SLua;
using System.Collections.Generic;

public class TestLua : MonoBehaviour {

    LuaSvr lua;
    LuaTable self;
    void Start()
    {
        lua = new LuaSvr();
        self = (LuaTable)lua.start("building_txt");
        //self = (LuaTable)lua.luaState.getObject("data");
        //object o = lua.luaState.getFunction("GetData").call();
        Debug.Log("table " + ((LuaTable)self[1])["name"]);


        LuaFunction dataFunction = ((LuaFunction)self["GetData"]);
        LuaTable dataTable = (LuaTable)dataFunction.call();
        LuaFunction callFunction = (LuaFunction)self["CallBack"];
        lua.luaState.getFunction("CallBack").call();
        lua.luaState.getFunction("Call").call(2);
        Debug.Log("table " + ((LuaTable)dataTable[1])["use_money"] + "   is Null " + (callFunction == null));

        LuaTable table2 = (LuaTable)lua.start("building_txt1");
    }

}
