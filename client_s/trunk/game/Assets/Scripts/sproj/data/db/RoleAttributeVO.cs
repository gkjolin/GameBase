using UnityEngine;
using System.Collections;
using System.IO;

using XingLuoTianXia.lib;

public class RoleAttributeVO : XLExcelBinBase
{
    private int _ID;
    public int ID
    {
        get { return _ID; }
    }

    private int _roleId;
    public int RoleId
    {
        get { return _roleId; }
    }

    private string _roleName;
    public string RoleName
    {
        get { return _roleName; }
    }

    private string _worldName;
    public string WorldName
    {
        get { return _worldName; }
    }

    private int _roleType;
    public int RoleType
    {
        get { return _roleType; }
    }

    private int _model;
    public int Model
    {
        get { return _model; }
    }

    private int _roleProduct;
    public int RoleProduct
    {
        get { return _roleProduct; }
    }

    private int _productParam;
    public int ProductParam
    {
        get { return _productParam; }
    }

    private int _HP;
    public int HP
    {
        get { return _HP; }
    }

    private float _HPGrowth;
    public float HPGrowth
    {
        get { return _HPGrowth; }
    }

    private int _physicalStrength;
    public int PhysicalStrength
    {
        get { return _physicalStrength; }
    }

    private float _physicalGrowth;
    public float PhysicalGrowth
    {
        get { return _physicalGrowth; }
    }

    private float _physicalNormal;
    public float PhysicalNormal
    {
        get { return _physicalNormal; }
    }

    private int _spellIntensity;
    public int SpellIntensity
    {
        get { return _spellIntensity; }
    }

    private float _spellGrowth;
    public float SpellGrowth
    {
        get { return _spellGrowth; }
    }

    private float _spellOrdinary;
    public float SpellOrdinary
    {
        get { return _spellOrdinary; }
    }

    private int _crit;
    public int Crit
    {
        get { return _crit; }
    }

    private float _critCoefficient;
    public float CritCoefficient
    {
        get { return _critCoefficient; }
    }

    private int _violence;
    public int Violence
    {
        get { return _violence; }
    }

    private float _violenceCoefficient;
    public float ViolenceCoefficient
    {
        get { return _violenceCoefficient; }
    }

    private int _physicalDefense;
    public int PhysicalDefense
    {
        get { return _physicalDefense; }
    }

    private float _defGrowth;
    public float DefGrowth
    {
        get { return _defGrowth; }
    }

    private int _physical;
    public int Physical
    {
        get { return _physical; }
    }

    private float _things;
    public float Things
    {
        get { return _things; }
    }

    private int _spellDefense;
    public int SpellDefense
    {
        get { return _spellDefense; }
    }

    private float _sdefGrowth;
    public float SdefGrowth
    {
        get { return _sdefGrowth; }
    }

    private int _spell;
    public int Spell
    {
        get { return _spell; }
    }

    private float _spellCoefficient;
    public float SpellCoefficient
    {
        get { return _spellCoefficient; }
    }

    private int _dodge;
    public int Dodge
    {
        get { return _dodge; }
    }

    private float _dodgeCoefficient ;
    public float DodgeCoefficient 
    {
        get { return _dodgeCoefficient ; }
    }

    private float _interval;
    public float Interval
    {
        get { return _interval; }
    }

    private float _moveSpeed;
    public float MoveSpeed
    {
        get { return _moveSpeed; }
    }

    private float _attackDistance;
    public float AttackDistance
    {
        get { return _attackDistance; }
    }

    private int[] _skill;
    public int[] Skill
    {
        get { return _skill; }
    }

    private int _mercenaryID;
    public int MercenaryID
    {
        get { return _mercenaryID; }
    }

    private int _initialMP;
    public int InitialMP
    {
        get { return _initialMP; }
    }

    private float _mpGrowth;
    public float MpGrowth
    {
        get { return _mpGrowth; }
    }

    private int _carryMosterNumber;
    public int CarryMosterNumber
    {
        get { return _carryMosterNumber; }
    }

    private int _isBattle;
    public int IsBattle
    {
        get { return _isBattle; }
    }

    public RoleAttributeVO()
    {
    
    }

    public void read(BinaryReader br)
    {
        _ID = br.ReadInt32();
        _roleId = br.ReadInt32();
        _roleName = XLStreamTools.readJavaUTF(br);
        _worldName = XLStreamTools.readJavaUTF(br);
        _roleType = br.ReadInt32();
        _model = br.ReadInt32();
        _roleProduct = br.ReadInt32();
        _productParam = br.ReadInt32();
        _HP = br.ReadInt32();
        _HPGrowth = XLStreamTools.readJavaFloat(br);
        _physicalStrength = br.ReadInt32();
        _physicalGrowth = XLStreamTools.readJavaFloat(br);
        _physicalNormal = XLStreamTools.readJavaFloat(br);
        _spellIntensity = br.ReadInt32();
        _spellGrowth = XLStreamTools.readJavaFloat(br);
        _spellOrdinary = XLStreamTools.readJavaFloat(br);
        _crit = br.ReadInt32();
        _critCoefficient = XLStreamTools.readJavaFloat(br);
        _violence = br.ReadInt32();
        _violenceCoefficient = XLStreamTools.readJavaFloat(br);
        _physicalDefense = br.ReadInt32();
        _defGrowth = XLStreamTools.readJavaFloat(br);
        _physical = br.ReadInt32();
        _things = XLStreamTools.readJavaFloat(br);
        _spellDefense = br.ReadInt32();
        _sdefGrowth = XLStreamTools.readJavaFloat(br);
        _spell = br.ReadInt32();
        _spellCoefficient = XLStreamTools.readJavaFloat(br);
        _dodge = br.ReadInt32();
        _dodgeCoefficient  = XLStreamTools.readJavaFloat(br);
        _interval = XLStreamTools.readJavaFloat(br);
        _moveSpeed = XLStreamTools.readJavaFloat(br);
        _attackDistance = XLStreamTools.readJavaFloat(br);
        _skill = XLStreamTools.readJavaInt32Array(br);
        _mercenaryID = br.ReadInt32();
        _initialMP = br.ReadInt32();
        _mpGrowth = XLStreamTools.readJavaFloat(br);
        _carryMosterNumber = br.ReadInt32();
        _isBattle = br.ReadInt32();
    }

    public RoleAttributeVO clone()
    {
        return this.MemberwiseClone() as RoleAttributeVO;
    }
}
