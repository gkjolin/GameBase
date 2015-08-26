using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Game
{
    public class MouseInteractiveComponent : BaseComponent
    {
        public override void Init()
        {
            CapsuleCollider collider = Enity.Transform.gameObject.AddComponent<CapsuleCollider>();
            collider.height = 10;
            Enity.Transform.gameObject.AddComponent<MouseClick>().OnClick += OnClick;
        }

        public override void InitEvent()
        {
        }


        public override void RemoveEvent()
        {
            Enity.Transform.gameObject.GetComponent<MouseClick>().OnClick -= OnClick;
            base.RemoveEvent();
        }
        private void OnClick()
        {
            Debug.Log("enith add mouse interactive");
            //GameObject.Destroy(Enity.Transform.gameObject.GetComponent<MouseClick>());
            //Enity.RemoveComponent("mouseInteractiveComponent");
        }

    }
}
