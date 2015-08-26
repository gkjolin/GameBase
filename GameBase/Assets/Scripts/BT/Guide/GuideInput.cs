using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game
{
    public class GuideInput
    {
        private static GuideInput _instance;

        public static GuideInput Instance
        {
            get { if (_instance == null) { _instance = new GuideInput(); } return GuideInput._instance; }
        }
    }
}
