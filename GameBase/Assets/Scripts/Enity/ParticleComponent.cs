using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Game
{
    public class ParticleComponent:BaseComponent
    {
        public override void Init()
        {
        }

        public override void InitEvent()
        {
            Enity.Event.AddEventListener("effectId", OnEffect);
        }

        private void OnEffect()
        {
            LoadParticle();
        }

        private void LoadParticle()
        {
            GameObject _go = ResourceManager.Instance.LoadNewPrefab("",Enity.Transform);
            _go.AddComponent<TestParticle>();
        }
    }
}
