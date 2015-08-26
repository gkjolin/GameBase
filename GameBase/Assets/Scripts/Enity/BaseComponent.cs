using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game
{
    public class BaseComponent
    {
        private Enity _enity;

        public Enity Enity
        {
            get { return _enity; }
            set
            {
                _enity = value;
                if (_enity != null)
                {
                    Init();
                    InitEvent();
                }
                
            }
        }

        public virtual void Init() { }

        public virtual void InitEvent() { }

        public virtual void RemoveEvent() {_enity = null;}

        public virtual void Update() { }

    }
}
