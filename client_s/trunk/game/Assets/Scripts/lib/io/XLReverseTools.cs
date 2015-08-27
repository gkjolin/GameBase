using UnityEngine;
using System.Collections;

namespace XingLuoTianXia.lib 
{
    /// <summary>
    /// 字节反转工具
    /// @author CJC
    /// @date 2015-05
    /// </summary>
    public class XLReverseTools
    {
        /// <summary>
        /// 把一个short反序
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static short reverseShort(short data)
        {
            byte d0 = (byte)(data & 0x000000FF);
            byte d1 = (byte)(data >> 8 & 0x000000FF);
            short ret = (short)((d0 << 8) + d1);
            return ret;
        }

        /// <summary>
        /// 把一个32位的int反序
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static int reverseInt32(int data)
        {
            byte d0 = (byte)(data & 0x000000FF);
            byte d1 = (byte)(data >> 8 & 0x000000FF);
            byte d2 = (byte)(data >> 16 & 0x000000FF);
            byte d3 = (byte)(data >> 24 & 0x000000FF);
            int ret = (d0 << 24) + (d1 << 16) + (d2 << 8) + d3;
            return ret;
        }
    }
}
