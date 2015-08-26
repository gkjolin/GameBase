using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game
{
    public class ActionIdle : ActionNode
    {
  
        public override bool DoEvaluate(BInput _input)
        {
            TargetInput _i = _input as TargetInput;
            return _i.state == 1;
        }

        public override ResultType Execute(BInput _input)
        {
            GameInput.DebugLog("do action idle");
            state = State.Exit;
            return ResultType.Success;
        }
    }
}
