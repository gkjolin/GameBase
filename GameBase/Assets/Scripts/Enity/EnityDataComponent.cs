using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game
{
    public class EnityDataComponent:BaseComponent
    {
        public override void Init()
        {
            Enity.Transform.gameObject.AddComponent<EnityBind>().Owner = Enity;
        }

        public override void InitEvent()
        {

        }



        public override void RemoveEvent()
        {
            throw new NotImplementedException();
        }
    }
}
