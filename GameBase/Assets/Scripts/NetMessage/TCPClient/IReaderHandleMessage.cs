using System;
using System.IO;
namespace Game
{
    public interface IReaderHandleMessage
    {
        void HandleMessage(string msgName, int data_type, MemoryStream data);
    }
}