using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Game
{
    public enum NodeType
    {
        ControlNode,
        ActionNode
    }

    public enum ResultType
    {
        Success,
        Fail,
        Running,
        None
    }

    public enum State
    {
        Enter,
        Running,
        Exit,
        None
    }

    public class Node
    {
        private Node _parent;
        public List<Node> listChilds = new List<Node>();
        public string nodeName;
        public ResultType result;
        public State state;
        public Node()
        {
            this.nodeName = this.GetType().Name;
        }
        protected virtual void Enter()
        {
            GameInput.DebugLog("node enter : " + nodeName);
            state = State.Enter;
        }

        protected virtual void Exit()
        {
            state = State.Exit;
        }
        public virtual ResultType Execute(BInput _input)
        {
            GameInput.DebugLog("base node execute " + _input);
            state = State.Running;
            if (listChilds.Count > 0)
            {
                Node node = listChilds[0];
                node.Execute(_input);
            }
            return ResultType.None;
        }

        public ResultType RunNode(BInput _input)
        {
            this.Enter();
            return Execute(_input);
        }

        public void AddChild(Node _child)
        {
            this.listChilds.Add(_child);
            _child.Parent = this;
        }

        protected Node Parent
        {
            get { return _parent; }
            set { _parent = value; }
        }



        private PreCondition _preCondition;

        public void SetPreCondition(PreCondition _condition)
        {
            _preCondition = _condition;
        }

        public bool Evaluate(BInput _condition)
        {
            bool b = true;
            if (_preCondition != null)
            {
                b = _preCondition.Evaluate(_condition);
            }

            return b && DoEvaluate(_condition);
        }

        public virtual bool DoEvaluate(BInput _input)
        {
            return true;
        }

        public void Update()
        {
            DoUpdate();
        }

        public virtual void DoUpdate()
        {

        }
    }
}
