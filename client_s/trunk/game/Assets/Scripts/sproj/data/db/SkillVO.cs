using UnityEngine;
using System.Collections;
using System.IO;

using XingLuoTianXia.lib;

public class SkillVO : XLExcelBinBase
{
    private int _skillID;
    public int SkillID
    {
        get { return _skillID; }
    }

    private string _skillName;
    public string SkillName
    {
        get { return _skillName; }
    }

    private float _delayTime;
    public float DelayTime
    {
        get { return _delayTime; }
    }

    private float _liveTime;
    public float LiveTime
    {
        get { return _liveTime; }
    }

    private byte _colliderType;
    public byte ColliderType
    {
        get { return _colliderType; }
    }

    private float[] _boxRange;
    public float[] BoxRange
    {
        get { return _boxRange; }
    }

    private float[] _colliderRange;
    public float[] ColliderRange
    {
        get { return _colliderRange; }
    }

    private byte _skillMoveType;
    public byte SkillMoveType
    {
        get { return _skillMoveType; }
    }

    private byte _bindType;
    public byte BindType
    {
        get { return _bindType; }
    }

    private float _moveSpeed;
    public float MoveSpeed
    {
        get { return _moveSpeed; }
    }

    private float _maxMoveDistance;
    public float MaxMoveDistance
    {
        get { return _maxMoveDistance; }
    }

    private float _castHorizontalAngle;
    public float CastHorizontalAngle
    {
        get { return _castHorizontalAngle; }
    }

    private float _castVerticalAngle;
    public float CastVerticalAngle
    {
        get { return _castVerticalAngle; }
    }

    private float _gravityValue;
    public float GravityValue
    {
        get { return _gravityValue; }
    }

    private float _skillDamageApplyType;
    public float SkillDamageApplyType
    {
        get { return _skillDamageApplyType; }
    }

    private float _damageRange;
    public float DamageRange
    {
        get { return _damageRange; }
    }

    private float _damageAngle;
    public float DamageAngle
    {
        get { return _damageAngle; }
    }

    private int _damageValue;
    public int DamageValue
    {
        get { return _damageValue; }
    }

    private short _maxDamageCount;
    public short MaxDamageCount
    {
        get { return _maxDamageCount; }
    }

    private int _groupIndex;
    public int GroupIndex
    {
        get { return _groupIndex; }
    }

    private byte _isApplyDamage;
    public byte IsApplyDamage
    {
        get { return _isApplyDamage; }
    }

    private byte _isGetHit;
    public byte IsGetHit
    {
        get { return _isGetHit; }
    }

    private int _effectID;
    public int EffectID
    {
        get { return _effectID; }
    }

    private float _effectLiveTime;
    public float EffectLiveTime
    {
        get { return _effectLiveTime; }
    }

    private int _soundID;
    public int SoundID
    {
        get { return _soundID; }
    }

    private int _hitEffectID;
    public int HitEffectID
    {
        get { return _hitEffectID; }
    }

    private float _hitEffectLiveTime;
    public float HitEffectLiveTime
    {
        get { return _hitEffectLiveTime; }
    }

    private int _hitSoundID;
    public int HitSoundID
    {
        get { return _hitSoundID; }
    }

    private int _deadEffectID;
    public int DeadEffectID
    {
        get { return _deadEffectID; }
    }

    private int _deadEffectLiveTime;
    public int DeadEffectLiveTime
    {
        get { return _deadEffectLiveTime; }
    }

    private short _isListenEnd;
    public short IsListenEnd
    {
        get { return _isListenEnd; }
    }

    private int _buffID;
    public int BuffID
    {
        get { return _buffID; }
    }

    private short _skillClass;
    public short SkillClass
    {
        get { return _skillClass; }
    }

    private byte _skillType;
    public byte SkillType
    {
        get { return _skillType; }
    }

    private byte _isHasTarget;
    public byte IsHasTarget
    {
        get { return _isHasTarget; }
    }

    private byte _attackType;
    public byte AttackType
    {
        get { return _attackType; }
    }

    private float _CDTime;
    public float CDTime
    {
        get { return _CDTime; }
    }

    private short _isInvincible;
    public short IsInvincible
    {
        get { return _isInvincible; }
    }

    private float[] _areaCoverage;
    public float[] AreaCoverage
    {
        get { return _areaCoverage; }
    }

    private int _initialmagic;
    public int Initialmagic
    {
        get { return _initialmagic; }
    }

    private float _addmagic;
    public float Addmagic
    {
        get { return _addmagic; }
    }

    private int _Skilllevel;
    public int Skilllevel
    {
        get { return _Skilllevel; }
    }

    private byte _weaponHaveEffect;
    public byte WeaponHaveEffect
    {
        get { return _weaponHaveEffect; }
    }

    private int _weaponEffectId;
    public int WeaponEffectId
    {
        get { return _weaponEffectId; }
    }

    private int _weaponBindType;
    public int WeaponBindType
    {
        get { return _weaponBindType; }
    }

    private float _weaponEffectLiveTime;
    public float WeaponEffectLiveTime
    {
        get { return _weaponEffectLiveTime; }
    }

    private byte _hitBindType;
    public byte HitBindType
    {
        get { return _hitBindType; }
    }

    public SkillVO()
    {
    
    }

    public void read(BinaryReader br)
    {
        _skillID = br.ReadInt32();
        _skillName = XLStreamTools.readJavaUTF(br);
        _delayTime = XLStreamTools.readJavaFloat(br);
        _liveTime = XLStreamTools.readJavaFloat(br);
        _colliderType = br.ReadByte();
        _boxRange = XLStreamTools.readJavaFloatArray(br);
        _colliderRange = XLStreamTools.readJavaFloatArray(br);
        _skillMoveType = br.ReadByte();
        _bindType = br.ReadByte();
        _moveSpeed = XLStreamTools.readJavaFloat(br);
        _maxMoveDistance = XLStreamTools.readJavaFloat(br);
        _castHorizontalAngle = XLStreamTools.readJavaFloat(br);
        _castVerticalAngle = XLStreamTools.readJavaFloat(br);
        _gravityValue = XLStreamTools.readJavaFloat(br);
        _skillDamageApplyType = XLStreamTools.readJavaFloat(br);
        _damageRange = XLStreamTools.readJavaFloat(br);
        _damageAngle = XLStreamTools.readJavaFloat(br);
        _damageValue = br.ReadInt32();
        _maxDamageCount = br.ReadInt16();
        _groupIndex = br.ReadInt32();
        _isApplyDamage = br.ReadByte();
        _isGetHit = br.ReadByte();
        _effectID = br.ReadInt32();
        _effectLiveTime = XLStreamTools.readJavaFloat(br);
        _soundID = br.ReadInt32();
        _hitEffectID = br.ReadInt32();
        _hitEffectLiveTime = XLStreamTools.readJavaFloat(br);
        _hitSoundID = br.ReadInt32();
        _deadEffectID = br.ReadInt32();
        _deadEffectLiveTime = br.ReadInt32();
        _isListenEnd = br.ReadInt16();
        _buffID = br.ReadInt32();
        _skillClass = br.ReadInt16();
        _skillType = br.ReadByte();
        _isHasTarget = br.ReadByte();
        _attackType = br.ReadByte();
        _CDTime = XLStreamTools.readJavaFloat(br);
        _isInvincible = br.ReadInt16();
        _areaCoverage = XLStreamTools.readJavaFloatArray(br);
        _initialmagic = br.ReadInt32();
        _addmagic = XLStreamTools.readJavaFloat(br);
        _Skilllevel = br.ReadInt32();
        _weaponHaveEffect = br.ReadByte();
        _weaponEffectId = br.ReadInt32();
        _weaponBindType = br.ReadInt32();
        _weaponEffectLiveTime = XLStreamTools.readJavaFloat(br);
        _hitBindType = br.ReadByte();
    }

    public SkillVO clone()
    {
        return this.MemberwiseClone() as SkillVO;
    }
}
