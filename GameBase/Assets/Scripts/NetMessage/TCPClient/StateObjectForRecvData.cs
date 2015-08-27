using System;
using System.Net.Sockets;

namespace Game
{
    internal class StateObjectForRecvData
    {
        public const int        BufferSize = 4096;
        public Socket           workSocket;
        public byte[]           buffer = new byte[4096];
    }
}
