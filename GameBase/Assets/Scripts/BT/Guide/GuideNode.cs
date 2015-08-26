using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game
{
    public enum GuideState
    {
        enter,
        execute,
        exit,
        none
    }
    public class GuideNode
    {
        public string name;
        private GuideState _state;
        private GuideNode _parent;
        private List<GuideNode> _listChild;
        private GuidePrecondition _preCondition;
        public GuideInput input;

        public GuidePrecondition PreCondition
        {
            get { return _preCondition; }
            set { _preCondition = value; }
        }
        public List<GuideNode> ListChild
        {
            get { if (_listChild == null) { _listChild = new List<GuideNode>(); } return _listChild; }
        }

        public GuideNode Parent
        {
            get { return _parent; }
            set { _parent = value; }
        }

        public GuideState State
        {
            get { return _state; }
            set { _state = value; }
        }
        public GuideNode(string _name)
        {
            name = _name;
        }

        protected virtual void Enter()
        {
            _state = GuideState.enter;
            GameInput.Log("guide node enter : " + name);
        }

        protected virtual void Execute()
        {
            _state = GuideState.execute;
           
        }

        protected virtual void Exit()
        {
            _state = GuideState.exit;
            if(_parent!=null)
            {
                _parent.RunNode();
            }
            else
            {
                //already root
            }
        }

        public bool DoEvaluate()
        {
            if (_preCondition == null) return true;
            return _preCondition.Evaluate(input);
        }

        public GuideState RunNode()
        {
            Enter();
            if (DoEvaluate())
            {
                this.Execute();
            }
            else
            {
                Exit();
            }
            return _state;
        }

        public void AddChild(GuideNode child)
        {
            this.ListChild.Add(child);
            child.Parent = this;
        }
    }
}
