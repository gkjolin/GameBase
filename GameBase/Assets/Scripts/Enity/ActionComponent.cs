using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Game
{
    public class ActionComponent : BaseComponent
    {
        private int currentStateHashName;

        private Animator _animator;
        public override void InitEvent()
        {
            Enity.Event.AddEventListener("moveSpeed", OnMoveSpeed);
            Enity.Event.AddEventListener("actionName", OnDoAction);
            Enity.Event.AddEventListener("actionParam", OnActionParam);
            Enity.Event.AddEventListener("normalizedTime", OnActionNormalizedTime);
            Enity.Event.AddEventListener("isLock", OnIsLock);

            //Enity.Event.AddEventListener("actinStateEnd", OnActionStateEnd);
        }
        private bool _isLock;
        private void OnIsLock()
        {
            _isLock = (bool)Enity.GetProperty("isLock");
        }
        public override void Init()
        {
            _animator = Enity.Go.GetComponentInChildren<Animator>();
        }

        private void OnActionStateEnd()
        {
            AnimatorStateInfo state = (AnimatorStateInfo)Enity.GetProperty("actinStateEnd");
            if (state.shortNameHash == AnimatorManager.atk01Hash)
            {

            }
        }

        private void OnActionNormalizedTime()
        {
            string actionTime = Enity.GetProperty("normalizedTime").ToString();
            if (actionTime == "effectNode")
            {
                Enity target = (Enity)Enity.GetProperty("patrolTarget");
                Animator animator = (Animator)target.GetProperty("animator");
                animator.Play("hit01", 0, 0);
            }
            else if (actionTime == "beAtkNode")
            {
                /*List<Enity> _listEnemy = Enity.GetProperty("enemy") as List<Enity>;
                if (_listEnemy != null)
                {
                    for (int i = 0; i < _listEnemy.Count; i++)
                    {
                        _listEnemy[i].SetProperty("actionName", "beAtk");
                    }
                }*/
            }
        }

        private void OnActionParam()
        {
            //bool _b = (bool)Enity.GetProperty("actionParam");
        }
        private void OnDoAction()
        {
            if (_isLock)
            {
            }
            else
            {
                string actionName = Enity.GetProperty("actionName").ToString();
                _animator.Play(actionName);
            }
            //if (AnimatorManager.Instance.IsSameCurrentAction(actionName)) return;
            /*return;
            if (actionName == "attack01")
            {
                Animator.SetBool("isAttack", true);
            }else
            {
                Animator.Play(actionName);
            }*/
        }
        bool isPlayBack = false;//是否重播  true: 重播

        private void OnMoveSpeed()
        {
            float speed = (float)(Enity.GetProperty("moveSpeed"));
            Animator.SetFloat("MoveSpeed", speed);
        }


        private Animator Animator
        {
            get
            {
                /*if (_animator == null)
                {
                    _animator = Enity.Go.GetComponentInChildren<Animator>();
                }*/
                return _animator;
            }
        }

    }
}
