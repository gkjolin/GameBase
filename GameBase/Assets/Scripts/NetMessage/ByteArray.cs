using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Game
{
    public class ByteArray
    {
        MemoryStream ms = new MemoryStream();

        BinaryWriter bw;
        BinaryReader br;


        public void Close()
        {
            bw.Close();
            br.Close();
            ms.Close();
        }

        public ByteArray(byte[] buff)
        {
            ms = new MemoryStream(buff);
            bw = new BinaryWriter(ms);
            br = new BinaryReader(ms);
        }

        public int Position
        {
            get { return (int)ms.Position; }
        }

        public int Length
        {
            get { return (int)ms.Length; }
        }

        public bool Readnable
        {
            get { return ms.Length > ms.Position; }
        }

        public ByteArray()
        {
            bw = new BinaryWriter(ms);
            br = new BinaryReader(ms);
        }

        public void write(int value)
        {
            bw.Write(value);
        }
        public void write(byte value)
        {
            bw.Write(value);
        }
        public void write(bool value)
        {
            bw.Write(value);
        }
        public void write(string value)
        {
            bw.Write(value);
        }
        public void write(byte[] value)
        {
            bw.Write(value);
        }

        public void write(double value)
        {
            bw.Write(value);
        }
        public void write(float value)
        {
            bw.Write(value);
        }
        public void write(long value)
        {
            bw.Write(value);
        }


        public int readInt()
        {
            return br.ReadInt32();
        }
        public byte readByte()
        {
            return br.ReadByte();
        }
        public bool readBool()
        {
            return br.ReadBoolean();
        }
        public string readString()
        {
            return br.ReadString();
        }
        public byte[] readBytes(int length)
        {
            return br.ReadBytes(length);
        }

        public double readDouble()
        {
            return br.ReadDouble();
        }
        public float readFloat()
        {
            return br.ReadSingle();
        }
        public long readLong()
        {
            return br.ReadInt64();
        }

        public void reposition()
        {
            ms.Position = 0;
        }

        public byte[] getBuff()
        {
            byte[] result = new byte[ms.Length];
            Buffer.BlockCopy(ms.GetBuffer(), 0, result, 0, (int)ms.Length);
            return result;
        }
    }



    public class SerializeUtil
    {
        public static byte[] encode(object value)
        {
            MemoryStream ms = new MemoryStream();
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(ms, value);
            byte[] result = new byte[ms.Length];
            Buffer.BlockCopy(ms.GetBuffer(), 0, result, 0, (int)ms.Length);
            return result;
        }

        public static object decoder(byte[] value)
        {
            MemoryStream ms = new MemoryStream(value);
            BinaryFormatter bf = new BinaryFormatter();
            return bf.Deserialize(ms);
        }
    }

}
