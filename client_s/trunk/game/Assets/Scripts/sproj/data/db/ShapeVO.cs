using UnityEngine;
using System.Collections;
using System.IO;

using XingLuoTianXia.lib;

public class ShapeVO : XLExcelBinBase
{
    private int _ID;
    public int ID
    {
        get { return _ID; }
    }

    private int[] _shapeArray;
    public int[] ShapeArray
    {
        get { return _shapeArray; }
    }

    public ShapeVO()
    {
    
    }

    public void read(BinaryReader br)
    {
        _ID = br.ReadInt32();
        _shapeArray = XLStreamTools.readJavaInt32Array(br);
    }

    public ShapeVO clone()
    {
        return this.MemberwiseClone() as ShapeVO;
    }
}
