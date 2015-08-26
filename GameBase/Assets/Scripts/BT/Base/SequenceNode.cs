using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game
{
    public class SequenceNode:ControlNode
    {

        private int _currentIndex;
        protected override void Enter()
        {
            _currentIndex = 0;
            base.Enter();
        }

        protected override void Exit()
        {
            state = State.Exit;
        }

        private BInput _input;
        public override ResultType Execute(BInput _input)
        {
            state = State.Running;
            if (_currentIndex > listChilds.Count) return ResultType.Fail;
            Node _node = listChilds[_currentIndex];
            this._input = _input;
            return _node.RunNode(_input);
        }

        public override void DoUpdate()
        {
            if(state == State.Running)
            {
                Node _node;
                _node = listChilds[_currentIndex];
                if(_node.state == State.Exit)
                { 
                    _currentIndex++;
                    if (_currentIndex == listChilds.Count)
                    {
                        state = State.Exit;
                        GameInput.DebugLog("sequence end");
                        return;
                    }
                    listChilds[_currentIndex].RunNode(_input);
                }

            }
        }
        
    }
}
