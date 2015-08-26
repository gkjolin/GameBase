using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game
{
    public class TargetInput:BInput
    {
        private Enity _target;

        public int state = 2;

        public Enity Target
        {
            get { return _target; }
            set { _target = value; }
        }

        public Enity owner;
    }
}
