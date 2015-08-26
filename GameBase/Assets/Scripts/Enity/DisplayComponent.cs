using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
namespace Game
{
    public class DisplayComponent:BaseComponent
    {
        public override void Init()
        {
            GetParent();
           // GetCamera();
        }

        public override void InitEvent()
        {
       
        }

        
        private void Show(Transform parent)
        {
            this.Enity.Transform.SetParent(parent);
            this.Enity.Transform.localPosition = Vector3.zero;
            this.Enity.Transform.localScale = Vector3.one;
        }

        private Transform GetParent()
        {
            Transform _t = GameObject.Find("Hero").transform;
            Show(_t);
            return _t;
        }

     /*   private Transform GetCamera()
        {
            Transform _t = GameObject.Find("Hero/Camera").transform;
            _t.SetParent(Enity.Transform);
            Enity.AddProperty("camera", _t.GetComponent<Camera>());
            return _t;
        }
*/

    }
}
