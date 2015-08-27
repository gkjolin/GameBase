using System;
namespace Game
{
    public interface INetMessageReader
    {
        void DidReadData(byte[] data, int size);
        void Reset();
    }
}

