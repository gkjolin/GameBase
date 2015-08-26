using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game
{
    public class GuideSquenceNode:GuideNode
    {
        private int _currentIndex = -1;
        public GuideSquenceNode(string _name):base(_name)
        {
            this.name = _name;
        }

        protected override void Execute()
        {
            _currentIndex++;
            if(ListChild.Count<=_currentIndex)
            {
                Exit();                
                return;
            }
            else
            {
                this.State = GuideState.execute;
                GuideNode _node = ListChild[_currentIndex];
                _node.RunNode();
            }
        }

        protected override void Exit()
        {
            base.Exit();
            UIGuide.Instance.GuideEnd();
        }

        public GuideNode GetCurrentNode()
        {
            return null;
        }
    }
}
