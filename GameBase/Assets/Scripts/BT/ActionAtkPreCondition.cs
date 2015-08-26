using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game
{
    public class ActionAtkPreCondition:PreCondition
    {
        public override bool Evaluate(BInput _input=null)
        {
            TargetInput input = _input as TargetInput;
            bool b = input.Target.GetProperty("name") == "hero";
            return b;
        }
    }
}
