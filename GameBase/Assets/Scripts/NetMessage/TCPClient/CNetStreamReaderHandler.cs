using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using ProtoBuf;
namespace Game
{
    public class CNetStreamReaderHandler:IReaderHandleMessage
    {
        public void HandleMessage(string msgName, int data_type, MemoryStream data)
        {
            //CNetRecvMsg msg = new CNetRecvMsg();
            //msg.m_strMsgName = msgName;
            //msg.m_DataMsg = data;
            //msg.DeSerializeProtocol<>();
            ProtocolManager.Instance.ReceiveMsg(msgName, data);
        }
    }
}
