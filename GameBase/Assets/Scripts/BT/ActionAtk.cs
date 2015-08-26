using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
namespace Game
{
    public class ActionAtk:ActionNode
    {

        public override ResultType Execute(BInput _input)
        {
            TargetInput input = _input as TargetInput;
            input.Target.SetProperty("hp", 100);
            GameInput.DebugLog("do action atk");
            state = State.Exit;
            return ResultType.Success;
        }
        public override bool DoEvaluate(BInput _input)
        {
            TargetInput input = (TargetInput)_input;
            float distance = Vector3.Distance(input.owner.Transform.position, input.Target.Transform.position);
            return distance < 10.0f;
        }
        
    }
}
