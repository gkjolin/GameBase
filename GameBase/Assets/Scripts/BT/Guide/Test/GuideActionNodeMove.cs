using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Game
{
    public class GuideActionNodeMove:GuideNode
    {

        public RectTransform _target;
        public GuideActionNodeMove(string name):base(name)
        {
            _target = UIGuide.Instance.GetTransform(name, UIMgr.Instance.uiRoot.transform) as RectTransform;
        }

        protected override void Execute()
        {
            GuideInputMove _input = input as GuideInputMove;
            UIGuide.Instance.ArrowFly(_input.position, _input.size,Exit);
        }

        protected override void Exit()
        {
            base.Exit();
        }

    }
}
