using UnityEngine;
using System.Collections;
using System.IO;

using XingLuoTianXia.lib;

public class BattleVO : XLExcelBinBase
{
    private int _ID;
    public int ID
    {
        get { return _ID; }
    }

    private float[] _onePos;
    public float[] OnePos
    {
        get { return _onePos; }
    }

    private int[] _oneStruct;
    public int[] OneStruct
    {
        get { return _oneStruct; }
    }

    private float[] _twoPos;
    public float[] TwoPos
    {
        get { return _twoPos; }
    }

    private int[] _twoStruct;
    public int[] TwoStruct
    {
        get { return _twoStruct; }
    }

    private int[] _formationID;
    public int[] FormationID
    {
        get { return _formationID; }
    }

    private float[] _oneSelfPos;
    public float[] OneSelfPos
    {
        get { return _oneSelfPos; }
    }

    private float[] _oneSelfCollection ;
    public float[] OneSelfCollection 
    {
        get { return _oneSelfCollection ; }
    }

    private float[] _oneSelfTwoPos;
    public float[] OneSelfTwoPos
    {
        get { return _oneSelfTwoPos; }
    }

    public BattleVO()
    {
    
    }

    public void read(BinaryReader br)
    {
        _ID = br.ReadInt32();
        _onePos = XLStreamTools.readJavaFloatArray(br);
        _oneStruct = XLStreamTools.readJavaInt32Array(br);
        _twoPos = XLStreamTools.readJavaFloatArray(br);
        _twoStruct = XLStreamTools.readJavaInt32Array(br);
        _formationID = XLStreamTools.readJavaInt32Array(br);
        _oneSelfPos = XLStreamTools.readJavaFloatArray(br);
        _oneSelfCollection  = XLStreamTools.readJavaFloatArray(br);
        _oneSelfTwoPos = XLStreamTools.readJavaFloatArray(br);
    }

    public BattleVO clone()
    {
        return this.MemberwiseClone() as BattleVO;
    }
}
