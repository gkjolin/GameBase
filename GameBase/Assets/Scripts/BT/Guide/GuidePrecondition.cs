using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game
{
    public class GuidePrecondition
    {
        public virtual bool Evaluate(GuideInput _input = null)
        {
            if (_input != null)
            {

            }
            return true;
        }
    }
}
