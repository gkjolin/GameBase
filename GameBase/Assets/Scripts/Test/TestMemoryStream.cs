using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Game
{
    public class TestMemoryStream
    {
        public TestMemoryStream()
        {

        }

        public static void TestWrite()
        {
            TestByteArrayWrite(); return;
            TestByteArray();
            return;

            MemoryStream ms = new MemoryStream();
            /*byte _b = Convert.ToByte(1);
            ms.WriteByte(_b);*/
            byte[] _byte = Encoding.UTF8.GetBytes("helloworld");
            /*for (int i = 0; i < _byte.Length; i++)
            {
                _byte[i] = Convert.ToByte(i);
            }*/
            ms.Write(_byte, 0, _byte.Length);
            GameInput.Log("ms length : ");
            GameInput.Log("ms getBuffer: " + Encoding.UTF8.GetString(ms.GetBuffer()));
        }

        public static void TestByteArray()
        {
            ByteArray ba = new ByteArray();
            ba.write("hello");
            ba.write("world");
            ba.write(1);
            //ba.reposition();
            //GameInput.Log("  length :" + ba.Length + " read " + ba.readString() + " read 2 " + ba.readString() + "  read 3 " + ba.readInt());
            ByteArray ba2 = new ByteArray(ba.getBuff());
            GameInput.Log(" current position :" + ba2.Position + " current value " + ba2.readString());
            GameInput.Log(" current position :" + ba2.Position + " current value " + ba2.readString());
            GameInput.Log(" current position :" + ba2.Position + " current value " + ba2.readInt());
            //GameInput.Log(" 2 length :" + ba2.Length + " read " + ba2.readString() + " read 2 " + ba2.readString() + "  read 3 " + ba2.readInt());

            Login login = new Login();
            login.name = "123";
            login.passwork = "456";
            byte[] _objBytes = SerializeUtil.encode(login);
            Login login2 = (Login)SerializeUtil.decoder(_objBytes);
            GameInput.Log("name :" + login2.name + " password " + login2.passwork);
        }

        public static void TestByteArrayWrite()
        {
            ByteArray ba = new ByteArray();
            ba.write(5);
            ByteArray ba2 = new ByteArray();
            ba2.write(ba.getBuff());
        }
    }

    [Serializable]
    public class Login
    {
        public string name;
        public string passwork;
    }
}

