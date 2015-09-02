using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_CSAPI : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			CSAPI o;
			o=new CSAPI();
			pushValue(l,o);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Log_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			CSAPI.Log(a1);
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int DispatcherEvent_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			System.Object a2;
			checkType(l,2,out a2);
			System.Single a3;
			checkType(l,3,out a3);
			CSAPI.DispatcherEvent(a1,a2,a3);
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int AddEventListener_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			System.Action<System.Object> a2;
			LuaDelegation.checkDelegate(l,2,out a2);
			CSAPI.AddEventListener(a1,a2);
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int CallBack_s(IntPtr l) {
		try {
			System.Action a1;
			LuaDelegation.checkDelegate(l,1,out a1);
			CSAPI.CallBack(a1);
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"CSAPI");
		addMember(l,Log_s);
		addMember(l,DispatcherEvent_s);
		addMember(l,AddEventListener_s);
		addMember(l,CallBack_s);
		createTypeMetatable(l,constructor, typeof(CSAPI));
	}
}
