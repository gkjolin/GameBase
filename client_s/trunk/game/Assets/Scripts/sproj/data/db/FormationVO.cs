using UnityEngine;
using System.Collections;
using System.IO;

using XingLuoTianXia.lib;

public class FormationVO : XLExcelBinBase
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

    private float[] _posXArray;
    public float[] PosXArray
    {
        get { return _posXArray; }
    }

    private float[] _posYArray;
    public float[] PosYArray
    {
        get { return _posYArray; }
    }

    private float[] _posZArray;
    public float[] PosZArray
    {
        get { return _posZArray; }
    }

    public FormationVO()
    {
    
    }

    public void read(BinaryReader br)
    {
        _ID = br.ReadInt32();
        _shapeArray = XLStreamTools.readJavaInt32Array(br);
        _posXArray = XLStreamTools.readJavaFloatArray(br);
        _posYArray = XLStreamTools.readJavaFloatArray(br);
        _posZArray = XLStreamTools.readJavaFloatArray(br);
    }

    public FormationVO clone()
    {
        return this.MemberwiseClone() as FormationVO;
    }
}
