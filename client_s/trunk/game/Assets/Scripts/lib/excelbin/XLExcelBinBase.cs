using UnityEngine;
using System.Collections;

using System.IO;

namespace XingLuoTianXia.lib 
{
    /// <summary>
    /// Excel二进制数值类
    /// @author CJC
    /// @date 2015-07
    /// </summary>
    public interface XLExcelBinBase
    {
        void read(BinaryReader br);
    }
}

