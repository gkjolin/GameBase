using System;
using System.Collections;


namespace Game
{
    internal class CNetStreamBuffer
    {
        private const int m_nMaxStreamCount = 2;
        private ArrayList m_streamList = new ArrayList();
        private int m_nActivedStreamPosition;
        public CNetStreamBuffer()
        {
            for (int i = 0; i < 2; i++)
            {
                this.m_streamList.Add(new MemoryStreamEx());
            }
        }
        public MemoryStreamEx GetActivedStream()
        {
            return (MemoryStreamEx)this.m_streamList[this.m_nActivedStreamPosition];
        }
        public MemoryStreamEx MoveStream(int index)
        {
            //1. 得到正在使用的MemoryStreamEx
            MemoryStreamEx memoryStreamEx = (MemoryStreamEx)this.m_streamList[this.m_nActivedStreamPosition];
            if (index > 0)
            {
                //2. index为将要移动的stream的开始位置，也就是网络接收到的stream解析完一个完整消息后的位置，把剩余的stream移动出来
                if ((long)index < memoryStreamEx.Length)
                {
                    //3. 把当前使用的MemoryStreamEx位置索引更新
                    this.m_nActivedStreamPosition = (this.m_nActivedStreamPosition + 1) % 2;
                    MemoryStreamEx memoryStreamEx2 = (MemoryStreamEx)this.m_streamList[this.m_nActivedStreamPosition];
                    memoryStreamEx2.Clear();
                    //4. 把剩余未解析的stream拷贝到memoryStreamEx2里去。
                    memoryStreamEx2.Write(memoryStreamEx.GetBuffer(), index, (int)(memoryStreamEx.Length - (long)index));
                    memoryStreamEx.Clear();
                    return memoryStreamEx2;
                }
                memoryStreamEx.Clear();
            }
            return memoryStreamEx;
        }
        public void Reset()
        {
            for (int i = 0; i < 2; i++)
            {
                ((MemoryStreamEx)this.m_streamList[i]).Clear();
            }
        }
    }
}
