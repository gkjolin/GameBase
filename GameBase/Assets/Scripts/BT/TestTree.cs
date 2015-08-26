using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game
{
    public class TestTree
    {
        private ActionAtk _actionAtk;
        //private SelectorNode _selectorNode;
        //private SequenceNode _selectorNode;
        private ParallelNode _selectorNode;

        public TestTree()
        {
            Init();
        }
        private void Init()
        {
            //_selectorNode = new SelectorNode();
            //_selectorNode = new SequenceNode();
            _selectorNode = new ParallelNode();
            ParallelNode _subParallel = new ParallelNode();

            _actionAtk = new ActionAtk();
            _actionAtk.SetPreCondition(new ActionAtkPreCondition());
            _selectorNode.AddChild(new ActionIdle());
            _selectorNode.AddChild(_actionAtk);

            TargetInput _input = new TargetInput();
            _input.Target = GlobalData.hero.MyEnity;
            _input.state = 1;
            _selectorNode.RunNode(_input);
            GameInput.Instance.OnUpdate += _selectorNode.Update;
        }

    }
}
