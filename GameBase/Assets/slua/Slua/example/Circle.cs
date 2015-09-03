using UnityEngine;
using System.Collections;
using SLua;

public class Circle : MonoBehaviour {


	LuaSvr svr;
	LuaTable self;
	LuaFunction update;
    LuaFunction test;
    LuaFunction test2;
	void Start () {
		svr = new LuaSvr();
		self=(LuaTable)svr.start("circle/circle");
		update = (LuaFunction)self["update"];
        test = (LuaFunction)self["test"];
        /*test2 = (LuaFunction)self["test2"];
        test2.call(9,8);*/
        object o = test.call(self,1,2);
        Debug.Log("0000000000000" + o);

	}
	
	void Update () {
		update.call(self);
	}
}
