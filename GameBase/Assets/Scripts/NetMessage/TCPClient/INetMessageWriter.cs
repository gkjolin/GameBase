using System;
using System.IO;
namespace Game
{
    public interface INetMessageWriter
    {
        byte[] MakeStream( MemoryStream data);
        void Reset();
    }
}

