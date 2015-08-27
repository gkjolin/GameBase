using System;
using System.IO;

namespace Game
{
    public class MemoryStreamEx : MemoryStream
    {
        public void Clear()
        {
            this.SetLength(0L);
        }
    }
}

