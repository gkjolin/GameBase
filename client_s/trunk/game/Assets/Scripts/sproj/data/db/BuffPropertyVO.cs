using UnityEngine;
using System.Collections;
using System.IO;

using XingLuoTianXia.lib;

public class BuffPropertyVO : XLExcelBinBase
{
    private int _ID;
    public int ID
    {
        get { return _ID; }
    }

    private byte _property;
    public byte Property
    {
        get { return _property; }
    }

    public BuffPropertyVO()
    {
    
    }

    public void read(BinaryReader br)
    {
        _ID = br.ReadInt32();
        _property = br.ReadByte();
    }

    public BuffPropertyVO clone()
    {
        return this.MemberwiseClone() as BuffPropertyVO;
    }
}
