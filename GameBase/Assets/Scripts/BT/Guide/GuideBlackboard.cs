using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game
{
    public class GuideBlackboard
    {
        private Enity _enity;
        private GuideNode _guideNode;
        private static GuideBlackboard _instance;

        public static GuideBlackboard Instance
        {
            get { if (_instance == null) { _instance = new GuideBlackboard(); } return GuideBlackboard._instance; }
        }

        public GuideBlackboard()
        {

        }

        private void InitEvent()
        {
            _enity.Event.AddEventListener("moveEnd", OnMoveEnd);
        }

        private void OnMoveEnd()
        {
            _guideNode.RunNode();
        }

        public Enity Enity
        {
            get { return _enity; }
            set
            {
                _enity = value;
                _guideNode = _enity.GetProperty("GuideTree") as GuideNode;
            }
        }
    }
}
