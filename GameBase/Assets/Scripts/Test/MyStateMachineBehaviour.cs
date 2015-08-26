using UnityEngine;
using System.Collections;
using Game;
using System.Collections.Generic;
public class MyStateMachineBehaviour : StateMachineBehaviour
{
    private Enity _enity;
    private EnityData _enityData;

    private bool _isLock;
    public bool IsLock
    {
        set
        {
            _isLock = value;
            _enity.SetProperty("isLock", _isLock);
        }
    }
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        /*AnimatorClipInfo[] _arrClipInfos = animator.GetCurrentAnimatorClipInfo(layerIndex);
        AnimatorClipInfo c = _arrClipInfos[0];
        slipName = c.clip.name;*/
        //Debug.Log("animator.name : " + animator.name + "   c.clip.name  " + c.clip.name + "   stateInfo.length :" + stateInfo.length +  "  nameHash " + (Animator.StringToHash(c.clip.name) == stateInfo.shortNameHash));
        //if (stateInfo.length > 0)
        //{
        /*AnimationClip _clip = new AnimationClip();
        AnimationEvent _event = new AnimationEvent();
        _event.functionName = "OnClipEvent";
        _event.intParameter = 1;
        _event.time = 0.6f;
        _clip.AddEvent(_event);*/

        /*MyStateMachineBehaviour  myState = animator.GetBehaviour<MyStateMachineBehaviour>();
        Debug.Log("-----------------------" + myState._name);*/
        //}
        _enity = animator.transform.GetComponentInParent<EnityBind>().Owner;
        _enityData = _enity.GetProperty("enityData") as EnityData;  
        _enity.SetProperty("onStateEnter",stateInfo);
        DataEventSource.Instance.DispatcherEvent("onStateEnter", stateInfo);
        _isEnd = false;
        _isLock = AnimatorManager.Instance.IsLock(stateInfo.shortNameHash);
        if (_isLock)
        {
            IsLock = _isLock;
        }
        GameInput.Log(" state enter >>>>>>>>>>>>>>>>>>>>>>>>>  " + AnimatorManager.Instance.HashToString(stateInfo.shortNameHash));
    }

    private List<string> _listNode = new List<string>();
    private bool _isEnd;
    float transitionTime = 0;
    public override void OnStateUpdate(UnityEngine.Animator animator, UnityEngine.AnimatorStateInfo stateInfo, int layerIndex)
    {
        foreach (KeyValuePair<string, float> t in _enityData.DictActionTime)
        {
            if (stateInfo.normalizedTime > t.Value)
            {
                if (_listNode.Contains(t.Key) == false)
                {
                    _listNode.Add(t.Key);
                    _enity.SetProperty("normalizedTime", t.Key);
                }
            }
        }

        if (stateInfo.normalizedTime >= 0.95f + transitionTime)
        {
            if (!_isEnd)
            {
                //GameInput.Log("state to the end " + stateInfo.normalizedTime);
                _isEnd = true;
                animator.SetBool("isAttack", false);
                animator.Play("idle01");
                _enity.SetProperty("actinStateEnd", stateInfo);
            }
        }


        /* if (stateInfo.normalizedTime > 0.3f)//播放特效时间节点
         {
             if (!_listNode.Contains("effectNode"))
             {
                 _enity.SetProperty("normalizedTime", "effectNode");
                 _listNode.Add("effectNode");
             }
         }
         if (stateInfo.normalizedTime > 0.6f)//播放受击动作时间节点
         {
             if (!_listNode.Contains("beAtkNode"))
             {
                 _enity.SetProperty("normalizedTime", "beAtkNode");
                 _listNode.Add("beAtkNode");
             }
         }*/
    }

    public override void OnStateExit(UnityEngine.Animator animator, UnityEngine.AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("on state exit");
        _enity.SetProperty("onStateExit", stateInfo);
        _listNode.Clear();
        if (_isLock == true)
        {
            IsLock = false;
        }
    }

    public override void OnStateMove(UnityEngine.Animator animator, UnityEngine.AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log(" on state move ///////////////////////////////////////////////");
    }

    public override void OnStateIK(UnityEngine.Animator animator, UnityEngine.AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Do a sine based on the State normalized time
        /*float normalizedTime = (1.0f + Mathf.Sin(Mathf.Repeat(stateInfo.normalizedTime, 1.0f) * Mathf.PI * 4)) * 0.5f;
        // lower the body
        animator.bodyPosition = animator.bodyPosition + new Vector3(0, -0.3f, 0);
        // make hands move left and right based on sine
        Vector3 leftHandPosition = animator.bodyPosition + new Vector3(-0.1f + normalizedTime * -0.2f, 0, 0.2f);
        Vector3 rightHandPosition = animator.bodyPosition + new Vector3(0.1f + normalizedTime * 0.2f, 0, 0.2f);
        // put elbow up
        Vector3 leftElbowPosition = animator.bodyPosition + new Vector3(-5, 2, 0);
        Vector3 rightElbowPosition = animator.bodyPosition + new Vector3(5, 2, 0);
        animator.SetIKPosition(AvatarIKGoal.LeftHand, leftHandPosition);
        animator.SetIKPosition(AvatarIKGoal.RightHand, rightHandPosition);
        // align knees to the hand
        animator.SetIKHintPosition(AvatarIKHint.LeftKnee, leftHandPosition);
        animator.SetIKHintPosition(AvatarIKHint.RightKnee, rightHandPosition);
        animator.SetIKHintPosition(AvatarIKHint.LeftElbow, leftElbowPosition);
        animator.SetIKHintPosition(AvatarIKHint.RightElbow, rightElbowPosition);
        // activate everything. Could be done on start
        animator.SetIKPositionWeight(AvatarIKGoal.LeftFoot, 1.0f);
        animator.SetIKRotationWeight(AvatarIKGoal.LeftFoot, 1.0f);
        animator.SetIKPositionWeight(AvatarIKGoal.RightFoot, 1.0f);
        animator.SetIKRotationWeight(AvatarIKGoal.RightFoot, 1.0f);
        animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1.0f);
        animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1.0f);
        animator.SetIKHintPositionWeight(AvatarIKHint.LeftKnee, 1.0f);
        animator.SetIKHintPositionWeight(AvatarIKHint.RightKnee, 1.0f);
        animator.SetIKHintPositionWeight(AvatarIKHint.RightElbow, 1.0f);
        animator.SetIKHintPositionWeight(AvatarIKHint.LeftElbow, 1.0f);*/
    }

    public override void OnStateMachineEnter(UnityEngine.Animator animator, int stateMachinePathHash)
    {

    }

    public override void OnStateMachineExit(UnityEngine.Animator animator, int stateMachinePathHash)
    {

    }

}
