using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
namespace Game
{
    public class TransformComponent : BaseComponent
    {
        public override void InitEvent()
        {
            Enity.Event.AddEventListener("scale", OnScale);
            Enity.Event.AddEventListener("position", OnPosition);
            Enity.Event.AddEventListener("rotation", OnRoration);
        }

        private void OnScale()
        {
            Enity.Transform.localScale = (Vector3)Enity.GetProperty("scale");
        }

        private void OnPosition()
        {
            Vector3 _v3 = (Vector3)Enity.GetProperty("position");
            Enity.Transform.Translate(_v3);
        }

        private void OnRoration()
        {
            Vector3 _v3 = (Vector3)Enity.GetProperty("rotation");
            Model.localRotation = Quaternion.LookRotation(_v3);
        }

        private Transform _model;

        private Transform Model
        {
            get
            {
                if (_model == null)
                {
                    _model = Enity.Transform.GetChild(0);
                }
                return _model;
            }
        }

    }
}
