using UnityEngine;
using System.Collections;
using System.IO;

using XingLuoTianXia.lib;

public class BuffRuleV0 : XLExcelBinBase
{
    private int _ID;
    public int ID
    {
        get { return _ID; }
    }

    private byte _priority;
    public byte Priority
    {
        get { return _priority; }
    }

    public BuffRuleV0()
    {
    
    }

    public void read(BinaryReader br)
    {
        _ID = br.ReadInt32();
        _priority = br.ReadByte();
    }

    public BuffRuleV0 clone()
    {
        return this.MemberwiseClone() as BuffRuleV0;
    }
}
