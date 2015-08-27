using UnityEngine;
using System.Collections;

using System.IO;
using System.Text;
using System;

namespace XingLuoTianXia.lib
{
    /// <summary>
    /// 流工具
    /// @author CJC
    /// @date 2015-05
    /// </summary>
    public class XLStreamTools
    {
        /// <summary>
        /// 读取一个java存的utf字符串
        /// </summary>
        /// <param name="br"></param>
        /// <returns></returns>
        public static string readJavaUTF(BinaryReader br)
        {
            short count = br.ReadInt16();
            count = XLReverseTools.reverseShort(count);

            byte[] data = br.ReadBytes(count);
            string str = Encoding.UTF8.GetString(data, 0, data.Length);
            return str;
        }

        public static float readJavaFloat(BinaryReader br)
        {
            string floatStr = readJavaUTF(br);
            float f = Convert.ToSingle(floatStr);
            return f;
        }

        /*
        public static float readJavaFloat(BinaryReader br)
        {
            byte[] data = br.ReadBytes(4);
            float ret = BitConverter.ToSingle(data, 0);//应为a在b中其实字节为0，故第二个参数
            return ret;
        }
        */

        /// <summary>
        /// 读取byte数组
        /// </summary>
        /// <param name="br"></param>
        /// <returns></returns>
        public static byte[] readJavaByteArray(BinaryReader br)
        {
            short count = br.ReadInt16();
            count = XLReverseTools.reverseShort(count);

            byte[] data = br.ReadBytes(count);
            return data;
        }

        /// <summary>
        /// 读取short数组
        /// </summary>
        /// <param name="br"></param>
        /// <returns></returns>
        public static short[] readJavaShortArray(BinaryReader br)
        {
            short count = br.ReadInt16();
            count = XLReverseTools.reverseShort(count);

            short[] data = new short[count];
            for (int i = 0; i < count; i++)
            {
                data[i] = br.ReadInt16();
            }
            return data;
        }

        /// <summary>
        /// 读取int32数组
        /// </summary>
        /// <param name="br"></param>
        /// <returns></returns>
        public static int[] readJavaInt32Array(BinaryReader br)
        {
            short count = br.ReadInt16();
            count = XLReverseTools.reverseShort(count);

            int[] data = new int[count];
            for (int i = 0; i < count; i++)
            {
                data[i] = br.ReadInt32();
            }
            return data;
        }

        /// <summary>
        /// 读取float数组
        /// </summary>
        /// <param name="br"></param>
        /// <returns></returns>
        public static float[] readJavaFloatArray(BinaryReader br)
        {
            short count = br.ReadInt16();
            count = XLReverseTools.reverseShort(count);

            float[] data = new float[count];
            for (int i = 0; i < count; i++)
            {
                data[i] = readJavaFloat(br);
            }
            return data;
        }

        /// <summary>
        /// 读取string数组
        /// </summary>
        /// <param name="br"></param>
        /// <returns></returns>
        public static string[] readJavaStringArray(BinaryReader br)
        {
            short count = br.ReadInt16();
            count = XLReverseTools.reverseShort(count);

            string[] data = new string[count];
            for (int i = 0; i < count; i++)
            {
                data[i] = readJavaUTF(br);
            }
            return data;
        }
    }
}
