using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class UIEventListener : EventTrigger
{
    public delegate void VoidDelegate(PointerEventData data);
    public VoidDelegate OnClick;
    public VoidDelegate OnMouseDown;
    public VoidDelegate OnMouseUp;
    public VoidDelegate OnMouseEnter;
    private static UIEventListener _instance;

    public static UIEventListener Instance
    {
        get { if (_instance == null) { _instance = new UIEventListener(); } return _instance; }
    }

    public UIEventListener GetUIEventListener(GameObject go)
    {
        UIEventListener uievent = go.GetComponent<UIEventListener>();
        if (uievent == null)
        {
            uievent = go.AddComponent<UIEventListener>();
        }
        return uievent;
    }

    
    public override void OnPointerEnter(PointerEventData eventData)
    {
        if (OnMouseEnter != null)
        {
            OnMouseEnter(eventData);
        }
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        if (OnClick != null)
        {
            OnClick(eventData);
        }
    }

    public VoidDelegate OnDragBegin;
    public override void OnBeginDrag(PointerEventData eventData)
    {
        if(OnDragBegin!=null)
        {
            OnDragBegin(eventData);
        }
    }

    public VoidDelegate OnDragIng;
    public override void OnDrag(PointerEventData eventData)
    {
        if(OnDragIng!=null)
        {
            OnDragIng(eventData);
        }
    }


    public VoidDelegate OnDragEnd;
    public override void OnEndDrag(PointerEventData eventData)
    {
        if(OnDragEnd!=null)
        {
            OnDragEnd(eventData);
        }
    }

    public VoidDelegate OnDragInit;
    public override void OnInitializePotentialDrag(PointerEventData eventData)
    {
        if(OnDragInit!=null)
        {
            OnDragInit(eventData);
        }
    }

    /*public  void OnPointerClick(PointerEventData data)
    {
        if (OnClick != null)
        {
            OnClick(data);
        }
    }*/

    public void OnPointerUp(PointerEventData eventData)
    {
        if (OnMouseUp != null) OnMouseUp(eventData);//OnMouseUp.Invoke(eventData);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (OnMouseDown != null) OnMouseDown(eventData);//OnMouseDown.in
    }

}

