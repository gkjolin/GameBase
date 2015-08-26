using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game
{
    public class PreCondition
    {
        public virtual bool Evaluate(BInput _input)
        {
            return true;
        }
    }
}
