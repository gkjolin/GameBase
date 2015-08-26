using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
namespace Game
{
    public class ActionPatrol:ActionNode
    {

        protected override void Enter()
        {
            throw new NotImplementedException();
        }

        protected override void Exit()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// </summary>
        /// <param name="_input"></param>
        /// <returns></returns>
        public override ResultType Execute(BInput _input)
        {
            TargetInput input = (TargetInput)_input;
            input.owner.Transform.LookAt(input.Target.Transform);
            return ResultType.Success;
        }

        public override bool DoEvaluate(BInput _input)
        {
            TargetInput input = (TargetInput)_input;
            float distance = Vector3.Distance(input.owner.Transform.position, input.Target.Transform.position);
            return distance<10.0f; 
        }

        public override void DoUpdate()
        {

        }
    }
}
