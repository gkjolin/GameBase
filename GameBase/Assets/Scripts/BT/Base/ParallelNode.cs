using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game
{
    public class ParallelNode:Node
    {
        private int _currentIndex;
        protected override void Enter()
        {
            _currentIndex = 0;
        }

        protected override void Exit()
        {
            this.state = State.Exit;
        }

        public override ResultType Execute(BInput _input)
        {
            this.state = State.Running;
            for (int i = 0; i < listChilds.Count; i++)
            {
                Node _node = listChilds[i];
                _node.RunNode(_input);
            }
            state = State.Exit;
            return ResultType.Success;
        }

        public override void DoUpdate()
        {
            if(state == State.Running)
            {
        
            }
        }
    }
}
