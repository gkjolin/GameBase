﻿using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_UI_Selectable : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int IsInteractable(IntPtr l) {
		try {
			UnityEngine.UI.Selectable self=(UnityEngine.UI.Selectable)checkSelf(l);
			var ret=self.IsInteractable();
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int FindSelectable(IntPtr l) {
		try {
			UnityEngine.UI.Selectable self=(UnityEngine.UI.Selectable)checkSelf(l);
			UnityEngine.Vector3 a1;
			checkType(l,2,out a1);
			var ret=self.FindSelectable(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int FindSelectableOnLeft(IntPtr l) {
		try {
			UnityEngine.UI.Selectable self=(UnityEngine.UI.Selectable)checkSelf(l);
			var ret=self.FindSelectableOnLeft();
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int FindSelectableOnRight(IntPtr l) {
		try {
			UnityEngine.UI.Selectable self=(UnityEngine.UI.Selectable)checkSelf(l);
			var ret=self.FindSelectableOnRight();
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int FindSelectableOnUp(IntPtr l) {
		try {
			UnityEngine.UI.Selectable self=(UnityEngine.UI.Selectable)checkSelf(l);
			var ret=self.FindSelectableOnUp();
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int FindSelectableOnDown(IntPtr l) {
		try {
			UnityEngine.UI.Selectable self=(UnityEngine.UI.Selectable)checkSelf(l);
			var ret=self.FindSelectableOnDown();
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int OnMove(IntPtr l) {
		try {
			UnityEngine.UI.Selectable self=(UnityEngine.UI.Selectable)checkSelf(l);
			UnityEngine.EventSystems.AxisEventData a1;
			checkType(l,2,out a1);
			self.OnMove(a1);
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int OnPointerDown(IntPtr l) {
		try {
			UnityEngine.UI.Selectable self=(UnityEngine.UI.Selectable)checkSelf(l);
			UnityEngine.EventSystems.PointerEventData a1;
			checkType(l,2,out a1);
			self.OnPointerDown(a1);
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int OnPointerUp(IntPtr l) {
		try {
			UnityEngine.UI.Selectable self=(UnityEngine.UI.Selectable)checkSelf(l);
			UnityEngine.EventSystems.PointerEventData a1;
			checkType(l,2,out a1);
			self.OnPointerUp(a1);
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int OnPointerEnter(IntPtr l) {
		try {
			UnityEngine.UI.Selectable self=(UnityEngine.UI.Selectable)checkSelf(l);
			UnityEngine.EventSystems.PointerEventData a1;
			checkType(l,2,out a1);
			self.OnPointerEnter(a1);
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int OnPointerExit(IntPtr l) {
		try {
			UnityEngine.UI.Selectable self=(UnityEngine.UI.Selectable)checkSelf(l);
			UnityEngine.EventSystems.PointerEventData a1;
			checkType(l,2,out a1);
			self.OnPointerExit(a1);
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int OnSelect(IntPtr l) {
		try {
			UnityEngine.UI.Selectable self=(UnityEngine.UI.Selectable)checkSelf(l);
			UnityEngine.EventSystems.BaseEventData a1;
			checkType(l,2,out a1);
			self.OnSelect(a1);
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int OnDeselect(IntPtr l) {
		try {
			UnityEngine.UI.Selectable self=(UnityEngine.UI.Selectable)checkSelf(l);
			UnityEngine.EventSystems.BaseEventData a1;
			checkType(l,2,out a1);
			self.OnDeselect(a1);
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Select(IntPtr l) {
		try {
			UnityEngine.UI.Selectable self=(UnityEngine.UI.Selectable)checkSelf(l);
			self.Select();
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_allSelectables(IntPtr l) {
		try {
			pushValue(l,UnityEngine.UI.Selectable.allSelectables);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_navigation(IntPtr l) {
		try {
			UnityEngine.UI.Selectable self=(UnityEngine.UI.Selectable)checkSelf(l);
			pushValue(l,self.navigation);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_navigation(IntPtr l) {
		try {
			UnityEngine.UI.Selectable self=(UnityEngine.UI.Selectable)checkSelf(l);
			UnityEngine.UI.Navigation v;
			checkType(l,2,out v);
			self.navigation=v;
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_transition(IntPtr l) {
		try {
			UnityEngine.UI.Selectable self=(UnityEngine.UI.Selectable)checkSelf(l);
			pushEnum(l,(int)self.transition);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_transition(IntPtr l) {
		try {
			UnityEngine.UI.Selectable self=(UnityEngine.UI.Selectable)checkSelf(l);
			UnityEngine.UI.Selectable.Transition v;
			checkEnum(l,2,out v);
			self.transition=v;
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_colors(IntPtr l) {
		try {
			UnityEngine.UI.Selectable self=(UnityEngine.UI.Selectable)checkSelf(l);
			pushValue(l,self.colors);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_colors(IntPtr l) {
		try {
			UnityEngine.UI.Selectable self=(UnityEngine.UI.Selectable)checkSelf(l);
			UnityEngine.UI.ColorBlock v;
			checkType(l,2,out v);
			self.colors=v;
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_spriteState(IntPtr l) {
		try {
			UnityEngine.UI.Selectable self=(UnityEngine.UI.Selectable)checkSelf(l);
			pushValue(l,self.spriteState);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_spriteState(IntPtr l) {
		try {
			UnityEngine.UI.Selectable self=(UnityEngine.UI.Selectable)checkSelf(l);
			UnityEngine.UI.SpriteState v;
			checkType(l,2,out v);
			self.spriteState=v;
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_animationTriggers(IntPtr l) {
		try {
			UnityEngine.UI.Selectable self=(UnityEngine.UI.Selectable)checkSelf(l);
			pushValue(l,self.animationTriggers);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_animationTriggers(IntPtr l) {
		try {
			UnityEngine.UI.Selectable self=(UnityEngine.UI.Selectable)checkSelf(l);
			UnityEngine.UI.AnimationTriggers v;
			checkType(l,2,out v);
			self.animationTriggers=v;
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_targetGraphic(IntPtr l) {
		try {
			UnityEngine.UI.Selectable self=(UnityEngine.UI.Selectable)checkSelf(l);
			pushValue(l,self.targetGraphic);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_targetGraphic(IntPtr l) {
		try {
			UnityEngine.UI.Selectable self=(UnityEngine.UI.Selectable)checkSelf(l);
			UnityEngine.UI.Graphic v;
			checkType(l,2,out v);
			self.targetGraphic=v;
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_interactable(IntPtr l) {
		try {
			UnityEngine.UI.Selectable self=(UnityEngine.UI.Selectable)checkSelf(l);
			pushValue(l,self.interactable);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_interactable(IntPtr l) {
		try {
			UnityEngine.UI.Selectable self=(UnityEngine.UI.Selectable)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.interactable=v;
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_image(IntPtr l) {
		try {
			UnityEngine.UI.Selectable self=(UnityEngine.UI.Selectable)checkSelf(l);
			pushValue(l,self.image);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_image(IntPtr l) {
		try {
			UnityEngine.UI.Selectable self=(UnityEngine.UI.Selectable)checkSelf(l);
			UnityEngine.UI.Image v;
			checkType(l,2,out v);
			self.image=v;
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_animator(IntPtr l) {
		try {
			UnityEngine.UI.Selectable self=(UnityEngine.UI.Selectable)checkSelf(l);
			pushValue(l,self.animator);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.Selectable");
		addMember(l,IsInteractable);
		addMember(l,FindSelectable);
		addMember(l,FindSelectableOnLeft);
		addMember(l,FindSelectableOnRight);
		addMember(l,FindSelectableOnUp);
		addMember(l,FindSelectableOnDown);
		addMember(l,OnMove);
		addMember(l,OnPointerDown);
		addMember(l,OnPointerUp);
		addMember(l,OnPointerEnter);
		addMember(l,OnPointerExit);
		addMember(l,OnSelect);
		addMember(l,OnDeselect);
		addMember(l,Select);
		addMember(l,"allSelectables",get_allSelectables,null,false);
		addMember(l,"navigation",get_navigation,set_navigation,true);
		addMember(l,"transition",get_transition,set_transition,true);
		addMember(l,"colors",get_colors,set_colors,true);
		addMember(l,"spriteState",get_spriteState,set_spriteState,true);
		addMember(l,"animationTriggers",get_animationTriggers,set_animationTriggers,true);
		addMember(l,"targetGraphic",get_targetGraphic,set_targetGraphic,true);
		addMember(l,"interactable",get_interactable,set_interactable,true);
		addMember(l,"image",get_image,set_image,true);
		addMember(l,"animator",get_animator,null,true);
		createTypeMetatable(l,null, typeof(UnityEngine.UI.Selectable),typeof(UnityEngine.EventSystems.UIBehaviour));
	}
}
