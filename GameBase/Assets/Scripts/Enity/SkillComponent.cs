using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
namespace Game
{
    public class SkillComponent:BaseComponent
    {
        public override void InitEvent()
        {
            Enity.Event.AddEventListener("skillId",OnSkill);
        }

        private void OnSkill()
        {

        }
    }
}
