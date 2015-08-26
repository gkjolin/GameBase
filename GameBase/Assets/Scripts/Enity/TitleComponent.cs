using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Game
{
    public class TitleComponent:BaseComponent
    {

        public override void Init()
        {
            GetTitle();
        }

        public override void InitEvent()
        {
            Enity.Event.AddEventListener("titleName", OnTitle);
        }

        private void OnTitle()
        {
            Transform _t = Enity.GetProperty("title") as Transform;
            SpriteRenderer sr = _t.GetComponent<SpriteRenderer>();
            string titleName = Enity.GetProperty("titleName").ToString();
            sr.sprite = Resources.Load(titleName, typeof(Sprite)) as Sprite;
        }
        private Transform GetTitle()
        {
            GameObject _go = new GameObject("title");
            _go.transform.SetParent(Enity.Transform);
            _go.transform.localPosition = new Vector3(0, 2, 0);
            _go.transform.localScale = Vector3.one;
            _go.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
            SpriteRenderer sr = _go.AddComponent<SpriteRenderer>();
            sr.sprite = Resources.Load("Js_biaotou", typeof(Sprite)) as Sprite;
            return _go.transform;
        }
    }
}
