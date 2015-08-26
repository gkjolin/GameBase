using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game
{
    public class DialogComponent:BaseComponent
    {
        public override void InitEvent()
        {
            Enity.Event.AddEventListener("dialogId", OnDialog);
        }

        private void OnDialog()
        {
            int dialogId = (int)Enity.GetProperty("dialogId");
        }
    }
}
