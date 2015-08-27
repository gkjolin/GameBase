using UnityEngine;
using System.Collections;
using System.IO;

using XingLuoTianXia.lib;

public class BuffsVO : XLExcelBinBase
{
    private int _buffID;
    public int BuffID
    {
        get { return _buffID; }
    }

    private string _buffName;
    public string BuffName
    {
        get { return _buffName; }
    }

    private byte _isBuff;
    public byte IsBuff
    {
        get { return _isBuff; }
    }

    private byte _buffType;
    public byte BuffType
    {
        get { return _buffType; }
    }

    private int _priority;
    public int Priority
    {
        get { return _priority; }
    }

    private string _iconPath;
    public string IconPath
    {
        get { return _iconPath; }
    }

    private float _liveTime;
    public float LiveTime
    {
        get { return _liveTime; }
    }

    private float _intervalTime;
    public float IntervalTime
    {
        get { return _intervalTime; }
    }

    private int _propertiesID;
    public int PropertiesID
    {
        get { return _propertiesID; }
    }

    private float _values;
    public float Values
    {
        get { return _values; }
    }

    private int _effectID;
    public int EffectID
    {
        get { return _effectID; }
    }

    private byte _bindType;
    public byte BindType
    {
        get { return _bindType; }
    }

    private float _effectLiveTime;
    public float EffectLiveTime
    {
        get { return _effectLiveTime; }
    }

    public BuffsVO()
    {
    
    }

    public void read(BinaryReader br)
    {
        _buffID = br.ReadInt32();
        _buffName = XLStreamTools.readJavaUTF(br);
        _isBuff = br.ReadByte();
        _buffType = br.ReadByte();
        _priority = br.ReadInt32();
        _iconPath = XLStreamTools.readJavaUTF(br);
        _liveTime = XLStreamTools.readJavaFloat(br);
        _intervalTime = XLStreamTools.readJavaFloat(br);
        _propertiesID = br.ReadInt32();
        _values = XLStreamTools.readJavaFloat(br);
        _effectID = br.ReadInt32();
        _bindType = br.ReadByte();
        _effectLiveTime = XLStreamTools.readJavaFloat(br);
    }

    public BuffsVO clone()
    {
        return this.MemberwiseClone() as BuffsVO;
    }
}
