using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game
{
    public class GuideSelectorNode : GuideNode
    {
        private int _currentIndex = -1;
        private GuideInput _input;
        private bool _isChildRun = false;

        public GuideSelectorNode(string name)
            : base(name)
        {

        }

        protected override void Execute()
        {
            if (_isChildRun) Exit();
            for (int i = 0; i < ListChild.Count; i++)
            {
                GuideNode _node = ListChild[i];
                if(_node.DoEvaluate())
                {
                    _isChildRun = true;
                    _node.RunNode();
                    return;
                }
            }
            Exit();//没有找到满足条件的，直接退出
        }

        protected override void Exit()
        {
            base.Exit();
            _isChildRun = false;
        }

    }
}
