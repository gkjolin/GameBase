using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Game;
public class MouseClick:MonoBehaviour
{
    public Enity Owner;
    public event Action OnClick;
    private void OnMouseDown()
    {
        if(OnClick!=null)
        {
            OnClick();
        }
    }
}
