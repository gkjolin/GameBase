using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game
{
    public class EnityData
    {
        private Dictionary<string, float> _dictActionTime = new Dictionary<string, float>();

        public Dictionary<string, float> DictActionTime
        {
            get { return _dictActionTime; } 
        }
        public void LoadActionConfig()
        {
            GameInput.DebugLog("load action config");
        }

        public EnityData()
        {
            _dictActionTime.Add("effectNode",0.3f);
        }

    }
}
