using System;
namespace SLua {
	[LuaBinder(3)]
	public class BindCustom {
		public static void Bind(IntPtr l) {
			Lua_CallCS.reg(l);
			Lua_CSAPI.reg(l);
			Lua_Custom.reg(l);
			Lua_Deleg.reg(l);
			Lua_foostruct.reg(l);
			Lua_SLuaTest.reg(l);
			Lua_System_Collections_Generic_List_1_int.reg(l);
			Lua_XXList.reg(l);
			Lua_HelloWorld.reg(l);
			Lua_System_Collections_Generic_Dictionary_2_int_string.reg(l);
			Lua_System_String.reg(l);
		}
	}
}
