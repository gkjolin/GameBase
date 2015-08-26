using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game
{
    public enum GameNodeName
    {

    }

    public class TestGameNode
    {
        private Dictionary<GameNodeName, GuideNode> _dictNodes = new Dictionary<GameNodeName, GuideNode>();
        private GuideNode _current;
        public GuideNode Current
        {
            get { return _current; }
            set { _current = value; }
        }

        private static TestGameNode _instance;

        public static TestGameNode Instance
        {
            get { if (_instance == null) { _instance = new TestGameNode(); } return TestGameNode._instance; }
        }

        public void AddNode(GuideNode _node, GameNodeName _nodeName)
        {
            if (_dictNodes.ContainsKey(_nodeName)) return;
            _dictNodes.Add(_nodeName, _node);
        }

        public void MakeTransition(GameNodeName _nodeName, GuidePrecondition _condition,GuideInput _input)
        {
            GuideNode _node = _dictNodes[_nodeName];
            _node.input = _input;
            _node.PreCondition = _condition;
            _node.RunNode();
            Current = _node;
        }

    }
}
