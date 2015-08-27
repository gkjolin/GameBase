/*
 * 网络字节流的拆包解析过程
 */
using System;
using System.IO;
using System.Net;
using UnityEngine;

namespace Game
{
    public class CNetStreamReader : INetMessageReader
    {
        private IReaderHandleMessage m_HandleMessage;
        private int m_nStreamSize;
        private int m_nMsgID;
        private string m_strMsgName;
        private int m_nDataType;
        private static readonly int m_nMaxDataSize = 204800;
        private CNetStreamBuffer m_NetBuffer = new CNetStreamBuffer();
        private MemoryStreamEx m_MsgDataBody = new MemoryStreamEx();
        public IReaderHandleMessage HandleMessage
        {
            set
            {
                this.m_HandleMessage = value;
            }
        }
        void INetMessageReader.DidReadData(byte[] data, int size)
        {
            //1. 把网络收到的字节buffer放到当前正在使用的MemoryStream里。
            //MemoryStream可能里面已有数据，接着往后写入。
            MemoryStream memoryStream = this.m_NetBuffer.GetActivedStream();
            memoryStream.Write(data, 0, size);
            byte[] buffer           = memoryStream.GetBuffer();
            long lReadStreamLength  = memoryStream.Length;
            while (true)
            {
                try
                {
                    //2. 从memorystream里读取前4个字节，取到消息整体大小m_nStreamSzie
                    if (lReadStreamLength < 4L)
                    {
                        //throw new Exception("Data Not Enough");
                        //数据不足继续去接收
                        break;
                    }
                    int nTempNum        = BitConverter.ToInt32(buffer, 0);
                    this.m_nStreamSize = nTempNum;
                    //todo:定义包头格式，class PacketHeader
                    lReadStreamLength   -= sizeof(int);

                    //3. checkhead检测m_nStreamSize至少要大于0(暂时这版无包头)字节，才能组成一个完成的协议头(消息ID+m_NotUseByte，详见CNetStreamWriter)
                    if (!this.CheckHead())
                    {
                        memoryStream.SetLength(0L);
                        break;
                    }

                    //4. nMsgBodyLen = 消息体的大小(m_nStreamSize-4字节，详见CNetStreamWriter写入部分)
                    int nMsgBodyLen = this.m_nStreamSize;
                    bool flag = false;
                    this.m_MsgDataBody.Clear();
                    if (nMsgBodyLen > 0)
                    {
                        //5. 如果memorystream剩余长度大于一个消息体长度，则解出消息体内容
                        if (lReadStreamLength >= (long)nMsgBodyLen)
                        {
                            this.m_MsgDataBody.Write(buffer, (int)(memoryStream.Length - lReadStreamLength), nMsgBodyLen);
                            //6. num为memroystream剩余长度
                            lReadStreamLength -= (long)nMsgBodyLen;
                        }
                        else
                        {
                            //如果不够解出一个完整的消息包了，跳出循环，等待网络继续接收。
                            flag = true;
                        }
                    }
                    if (flag)
                    {
                        break;
                    }
                    //7. memoryStream.Length - num = 剩余stream的启示位置，MoveStream的用意就是从MemoryStream里移除一个完整的消息，返回值是剩余部分的MemoryStream
                    memoryStream = this.m_NetBuffer.MoveStream((int)(memoryStream.Length - lReadStreamLength));
                    try
                    {
                        //8. 处理已经完整解出的一个消息体
                        this.m_HandleMessage.HandleMessage(this.m_strMsgName, this.m_nDataType, this.m_MsgDataBody);
                    }
                    catch (Exception message)
                    {
                        Debug.LogWarning(message);
                    }
                    //9. 把剩余的buffer取出来，循环继续解析。直到解不出一个完整的消息为止。
                    buffer = memoryStream.GetBuffer();
                    lReadStreamLength = memoryStream.Length;
                }
                catch (Exception var_7_19F)
                {
                    Debug.Log(var_7_19F.Message);
                    break;
                }
            }
        }

        void INetMessageReader.Reset()
        {
            this.m_nStreamSize = 0;
            this.m_nMsgID = 0;
            this.m_nDataType = 0;
            this.m_NetBuffer.Reset();
            this.m_MsgDataBody.Clear();
        }
        private bool CheckHead()
        {
            //return this.m_nStreamSize >= 8 && this.m_nStreamSize <= CNetStreamReader.m_nMaxDataSize;
            return this.m_nStreamSize >= 0 && this.m_nStreamSize <= CNetStreamReader.m_nMaxDataSize;
        }
    }
}
