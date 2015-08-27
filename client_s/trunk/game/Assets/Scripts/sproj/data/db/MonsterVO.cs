using UnityEngine;
using System.Collections;
using System.IO;

using XingLuoTianXia.lib;

public class MonsterVO : XLExcelBinBase
{
    private int _ID;
    public int ID
    {
        get { return _ID; }
    }

    private string _mosterName;
    public string MosterName
    {
        get { return _mosterName; }
    }

    private int _mosterProfessional;
    public int MosterProfessional
    {
        get { return _mosterProfessional; }
    }

    private int _havaMosterID;
    public int HavaMosterID
    {
        get { return _havaMosterID; }
    }

    private int _carryMosterNumber;
    public int CarryMosterNumber
    {
        get { return _carryMosterNumber; }
    }

    private int[] _skill;
    public int[] Skill
    {
        get { return _skill; }
    }

    private int _model;
    public int Model
    {
        get { return _model; }
    }

    private int _level;
    public int Level
    {
        get { return _level; }
    }

    private int _HP;
    public int HP
    {
        get { return _HP; }
    }

    private int _MP;
    public int MP
    {
        get { return _MP; }
    }

    private int _physicalStrength;
    public int PhysicalStrength
    {
        get { return _physicalStrength; }
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

    private float _spellOrdinary;
    public float SpellOrdinary
    {
        get { return _spellOrdinary; }
    }

    private float _critIntensity;
    public float CritIntensity
    {
        get { return _critIntensity; }
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

    private int _violenceIntensity;
    public int ViolenceIntensity
    {
        get { return _violenceIntensity; }
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

    private int _dodgeIntensity;
    public int DodgeIntensity
    {
        get { return _dodgeIntensity; }
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

    private float _bonus;
    public float Bonus
    {
        get { return _bonus; }
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

    private int _combat;
    public int Combat
    {
        get { return _combat; }
    }

    private int _drop;
    public int Drop
    {
        get { return _drop; }
    }

    public MonsterVO()
    {
    
    }

    public void read(BinaryReader br)
    {
        _ID = br.ReadInt32();
        _mosterName = XLStreamTools.readJavaUTF(br);
        _mosterProfessional = br.ReadInt32();
        _havaMosterID = br.ReadInt32();
        _carryMosterNumber = br.ReadInt32();
        _skill = XLStreamTools.readJavaInt32Array(br);
        _model = br.ReadInt32();
        _level = br.ReadInt32();
        _HP = br.ReadInt32();
        _MP = br.ReadInt32();
        _physicalStrength = br.ReadInt32();
        _physicalNormal = XLStreamTools.readJavaFloat(br);
        _spellIntensity = br.ReadInt32();
        _spellOrdinary = XLStreamTools.readJavaFloat(br);
        _critIntensity = XLStreamTools.readJavaFloat(br);
        _crit = br.ReadInt32();
        _critCoefficient = XLStreamTools.readJavaFloat(br);
        _violenceIntensity = br.ReadInt32();
        _violence = br.ReadInt32();
        _violenceCoefficient = XLStreamTools.readJavaFloat(br);
        _physicalDefense = br.ReadInt32();
        _physical = br.ReadInt32();
        _things = XLStreamTools.readJavaFloat(br);
        _spellDefense = br.ReadInt32();
        _spell = br.ReadInt32();
        _spellCoefficient = XLStreamTools.readJavaFloat(br);
        _dodgeIntensity = br.ReadInt32();
        _dodge = br.ReadInt32();
        _dodgeCoefficient  = XLStreamTools.readJavaFloat(br);
        _interval = XLStreamTools.readJavaFloat(br);
        _bonus = XLStreamTools.readJavaFloat(br);
        _moveSpeed = XLStreamTools.readJavaFloat(br);
        _attackDistance = XLStreamTools.readJavaFloat(br);
        _combat = br.ReadInt32();
        _drop = br.ReadInt32();
    }

    public MonsterVO clone()
    {
        return this.MemberwiseClone() as MonsterVO;
    }
}
