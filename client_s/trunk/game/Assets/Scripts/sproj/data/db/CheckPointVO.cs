using UnityEngine;
using System.Collections;
using System.IO;

using XingLuoTianXia.lib;

public class CheckPointVO : XLExcelBinBase
{
    private int _ID;
    public int ID
    {
        get { return _ID; }
    }

    private int _mapID;
    public int MapID
    {
        get { return _mapID; }
    }

    private string _mapName;
    public string MapName
    {
        get { return _mapName; }
    }

    private string _mapDescribe;
    public string MapDescribe
    {
        get { return _mapDescribe; }
    }

    private string _mapIcon;
    public string MapIcon
    {
        get { return _mapIcon; }
    }

    private int _mapIsOpen;
    public int MapIsOpen
    {
        get { return _mapIsOpen; }
    }

    private int _checkId;
    public int CheckId
    {
        get { return _checkId; }
    }

    private string _name;
    public string Name
    {
        get { return _name; }
    }

    private string _describe;
    public string Describe
    {
        get { return _describe; }
    }

    private string _icon;
    public string Icon
    {
        get { return _icon; }
    }

    private byte _isOpen;
    public byte IsOpen
    {
        get { return _isOpen; }
    }

    private int _recommend;
    public int Recommend
    {
        get { return _recommend; }
    }

    private byte _consumeType;
    public byte ConsumeType
    {
        get { return _consumeType; }
    }

    private byte _ceiling;
    public byte Ceiling
    {
        get { return _ceiling; }
    }

    private int _winConsume;
    public int WinConsume
    {
        get { return _winConsume; }
    }

    private int _failureConsume;
    public int FailureConsume
    {
        get { return _failureConsume; }
    }

    private byte _starType;
    public byte StarType
    {
        get { return _starType; }
    }

    private int _starConditions;
    public int StarConditions
    {
        get { return _starConditions; }
    }

    private byte _starType2;
    public byte StarType2
    {
        get { return _starType2; }
    }

    private int _starConditions2;
    public int StarConditions2
    {
        get { return _starConditions2; }
    }

    private byte _starType3;
    public byte StarType3
    {
        get { return _starType3; }
    }

    private int _starConditions3;
    public int StarConditions3
    {
        get { return _starConditions3; }
    }

    private byte _starMax;
    public byte StarMax
    {
        get { return _starMax; }
    }

    private int _experience;
    public int Experience
    {
        get { return _experience; }
    }

    private int _gold ;
    public int Gold 
    {
        get { return _gold ; }
    }

    private int _battleId;
    public int BattleId
    {
        get { return _battleId; }
    }

    public CheckPointVO()
    {
    
    }

    public void read(BinaryReader br)
    {
        _ID = br.ReadInt32();
        _mapID = br.ReadInt32();
        _mapName = XLStreamTools.readJavaUTF(br);
        _mapDescribe = XLStreamTools.readJavaUTF(br);
        _mapIcon = XLStreamTools.readJavaUTF(br);
        _mapIsOpen = br.ReadInt32();
        _checkId = br.ReadInt32();
        _name = XLStreamTools.readJavaUTF(br);
        _describe = XLStreamTools.readJavaUTF(br);
        _icon = XLStreamTools.readJavaUTF(br);
        _isOpen = br.ReadByte();
        _recommend = br.ReadInt32();
        _consumeType = br.ReadByte();
        _ceiling = br.ReadByte();
        _winConsume = br.ReadInt32();
        _failureConsume = br.ReadInt32();
        _starType = br.ReadByte();
        _starConditions = br.ReadInt32();
        _starType2 = br.ReadByte();
        _starConditions2 = br.ReadInt32();
        _starType3 = br.ReadByte();
        _starConditions3 = br.ReadInt32();
        _starMax = br.ReadByte();
        _experience = br.ReadInt32();
        _gold  = br.ReadInt32();
        _battleId = br.ReadInt32();
    }

    public CheckPointVO clone()
    {
        return this.MemberwiseClone() as CheckPointVO;
    }
}
