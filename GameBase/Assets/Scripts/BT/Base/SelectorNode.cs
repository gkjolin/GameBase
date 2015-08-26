using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game
{
    public class SelectorNode : ControlNode
    {
        private int _currentIndex;
        public SelectorNode()
            : base()
        {
            this.nodeName = "selector";
        }

        protected override void Enter()
        {
            _currentIndex = 0;
            base.Enter();
        }

        protected override void Exit()
        {
            result = ResultType.Success;
        }

        public override ResultType Execute(BInput _input)
        {
            if (_currentIndex >= listChilds.Count)
            {
                GameInput.DebugLog("没有找到匹配这个条件的");
                return ResultType.Fail;
            }

            Node _node = listChilds[_currentIndex];
            if(_node.Evaluate(_input))
            {
                return result= _node.RunNode(_input);
            }else
            {
                _currentIndex++;
                Execute(_input);
            }
            result = ResultType.Running;
            return result;
        }
    }
}
