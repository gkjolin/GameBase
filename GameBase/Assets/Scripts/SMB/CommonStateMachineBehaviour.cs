using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Game;
class CommonStateMachineBehaviour : StateMachineBehaviour
{
    private Enity _enity;
    private EnityData _enityData;
    private bool _isEnd;
    private bool _isLock;

    public bool IsLock
    {
        set
        {
            _isLock = value;
            _enity.SetProperty("isLock", _isLock);
        }
    }
    public override void OnStateEnter(UnityEngine.Animator animator, UnityEngine.AnimatorStateInfo stateInfo, int layerIndex)
    {
        //DataEventSource.Instance.DispatcherEvent("onStateEnter", stateInfo);
        _enity = animator.transform.GetComponentInParent<EnityBind>().Owner;
        _enityData = _enity.GetProperty("enityData") as EnityData;
        _isEnd = false;
        _isLock = AnimatorManager.Instance.IsLock(stateInfo.shortNameHash);
        if (_isLock)
        {
            IsLock = _isLock;
        }
    }

    public override void OnStateUpdate(UnityEngine.Animator animator, UnityEngine.AnimatorStateInfo stateInfo, int layerIndex)
    {
        //DataEventSource.Instance.DispatcherEvent("onStateExit", stateInfo);
        if (stateInfo.normalizedTime >= 0.95f)
        {
            if (!_isEnd)
            {
                _isEnd = true;
                _enity.SetProperty("actinStateEnd", stateInfo);
                animator.Play("idle01");
            }
        }
    }

    public override void OnStateExit(UnityEngine.Animator animator, UnityEngine.AnimatorStateInfo stateInfo, int layerIndex)
    {
        //_enity.SetProperty("actinStateExit", stateInfo);
        if (_isLock == true)
        {
            IsLock = false;
        }
    }
}

