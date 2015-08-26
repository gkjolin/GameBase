using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Game
{
    public class PatrolComponent : BaseComponent
    {
        public override void Init()
        {

        }

        public override void InitEvent()
        {
            Enity.Event.AddEventListener("patrolTarget", OnPatrol);
            Enity.Event.AddEventListener("patrol", OnPatrol);
            Enity.Event.AddEventListener("actinStateEnd", OnActionStateEnd);
            Enity.Event.AddEventListener("isLock", OnIsLock);
        }

        private bool _isLock;
        private void OnIsLock()
        {
            _isLock = (bool)Enity.GetProperty("isLock");
        }

        private void OnActionStateEnd()
        {
            AnimatorStateInfo state = (AnimatorStateInfo)Enity.GetProperty("actinStateEnd");
            Debug.Log("------2 action state end " + AnimatorManager.Instance.HashToString(state.shortNameHash));
        }

        private void OnPatrol()
        {
            _target = Enity.GetProperty("patrolTarget") as Enity;  
        }
        private Enity _target;
        public override void Update()
        {
            if (_target != null && _isLock == false)
            {
                float distance = Vector3.Distance(Enity.Transform.position, _target.Transform.position);
                if (distance < 10)
                {
                    Enity.SetProperty("actionName", "run01");
                    Enity.Transform.LookAt(_target.Transform);
                    Enity.Transform.Translate(Vector3.forward * Time.deltaTime * 1);
                    if (distance < 1.0f)
                    {
                        Enity.SetProperty("actionName", "attack01");
                    }
                }
            }
        }

        public override void RemoveEvent()
        {

        }
    }
}
