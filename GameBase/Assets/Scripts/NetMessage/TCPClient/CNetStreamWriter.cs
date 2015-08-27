/*
 * 构建网络发送协议包
 */
using System;
using System.IO;
using System.Net;
namespace Game
{
    public class CNetStreamWriter : INetMessageWriter
    {
        private MemoryStreamEx          m_Buffer = new MemoryStreamEx();
        private byte[]                  m_NotUseByte   = new byte[4];
        private byte                    mCounter;//包序,暂时未用

        byte[] INetMessageWriter.MakeStream(MemoryStream data)
        {
            //组建网络消息buff
            this.m_Buffer.Clear();

            int nMsgLen = ((data == null) ? 0 : ((int)data.Length));
            byte[] bytes_msg = BitConverter.GetBytes(nMsgLen);

            this.m_Buffer.Write(bytes_msg, 0, bytes_msg.Length);

            if (data != null)
            {
                this.m_Buffer.Write(data.GetBuffer(), 0, (int)data.Length);
            }
            return this.m_Buffer.ToArray();
        }
        void INetMessageWriter.Reset()
        {
            this.m_Buffer.Clear();
            this.mCounter = 0;
        }
    }
}
