using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class GuideActionNodeClickBtn : GuideActionNode
    {
        private Button _btn;
        public Button Btn
        {
            get { return _btn; }
            set
            {
                _btn = value;
            }
        }

        public GuideActionNodeClickBtn(string _name)
            : base(_name)
        {
            Btn = UIGuide.Instance.GetTransform(_name,UIMgr.Instance.uiRoot.transform).GetComponent<Button>();
        }

        protected override void Execute()
        {
            UIGuide.Instance.DrawRect((Btn.transform as RectTransform).anchoredPosition, (Btn.transform as RectTransform).sizeDelta);
            _btn.onClick.AddListener(Exit);
            if (eventName!=null)
            {
                DataEventSource.Instance.AddEventListener(eventName, OnExit);
            }
        }

        protected override void Exit()
        {
            _btn.onClick.RemoveListener(Exit);
            DataEventSource.Instance.RemoveEventListener(eventName, OnExit);
            base.Exit();
        }

        protected override void InitEvent()
        {

        }

        private string eventName;
        public void AddEvent(string _name)
        {
            eventName = _name;
            //DataEventSource.Instance.AddEventListener(eventName, OnExit);
        }

        private void OnExit(object obj = null)
        {
            Exit(); 
        }

    }
}
