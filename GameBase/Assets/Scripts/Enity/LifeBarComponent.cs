using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Game
{
    public class LifeBarComponent:BaseComponent
    {
        private RectTransform barTransfrom;
        private UILifeBar2 _uilifeBar;
        public string key;
        public override void Init()
        {
            LoadLifeBar();
        }
        public override void InitEvent()
        {
            Enity.Event.AddEventListener("hp", OnHp);
        }

        private void OnHp()
        {
            float hp = (float)Enity.GetProperty("hp");
            float maxHp = (float)Enity.GetProperty("maxHp");
            _uilifeBar.SetBarLength(hp,maxHp);
        }

        private void LoadLifeBar()
        {
            GameObject _go = ResourceManager.Instance.LoadNewPrefab("UILifeBar2",UIMgr.Instance.GetLayer(UIMgr.Layer.layer2));
            _go.name = "UILifeBar_" + Enity.GetProperty("name");
            barTransfrom = _go.transform as RectTransform;
            _uilifeBar = barTransfrom.GetComponent<UILifeBar2>();
            if(_uilifeBar == null)
            {
                _uilifeBar = barTransfrom.gameObject.AddComponent<UILifeBar2>();
            }
            _uilifeBar._camera = Enity.GetProperty("camera") as Camera;
            _uilifeBar._actor = Enity.Transform;
        }
    }
}
