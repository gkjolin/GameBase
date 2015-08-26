using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game
{
    public class GuideActionNode:GuideNode
    {
        public GuideActionNode(string _name):base(_name)
        {
            InitEvent();
        }

        protected override void Enter()
        {

        }

        protected override void Execute()
        {

        }

        protected override void Exit()
        {
            base.Exit();
        }

        protected virtual void InitEvent()
        {

        }
    }
}
