/*
 * 网络协议包
 * 通过Protobuf-net反序列化
 */
using ProtoBuf;
using System;
using System.IO;

namespace Game
{
    public class CNetRecvMsg
    {
        public string  m_strMsgName;                    //协议名
        public MemoryStream m_DataMsg;          //数据流

        /// <summary>
        /// 反序列化数据流到指定的协议
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T DeSerializeProtocol<T>()
        {
            this.m_DataMsg.Position = 0L;
            return Serializer.Deserialize<T>(this.m_DataMsg);
        }
    }
}
