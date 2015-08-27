using UnityEngine;
using System.Collections;
using System.IO;

using XingLuoTianXia.lib;

public class SoldiersCollocationVO : XLExcelBinBase
{
    private int _ID;
    public int ID
    {
        get { return _ID; }
    }

    private int[] _soldiers;
    public int[] Soldiers
    {
        get { return _soldiers; }
    }

    public SoldiersCollocationVO()
    {
    
    }

    public void read(BinaryReader br)
    {
        _ID = br.ReadInt32();
        _soldiers = XLStreamTools.readJavaInt32Array(br);
    }

    public SoldiersCollocationVO clone()
    {
        return this.MemberwiseClone() as SoldiersCollocationVO;
    }
}
