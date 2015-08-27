using System.Collections.Generic;

/// <summary>
/// 技能
/// @author MXL
/// @date 2015-07
/// </summary>
public class SkillAgent
{

    private SkillVO _skill = null;

    public SkillAgent()
    {

    }

    /// <summary>
    ///   通过id 获取对应的 静态数据
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>

    public void setData(int id)
    {
        IList<SkillVO> list = DataMgr.getInstance().Skills;

        for (int i = 0; i < list.Count; ++i)
        {
            if (list[i].SkillID == id)
            {
                _skill = list[i];
            }
        }
    }

    /// <summary>
    /// 获取当前的技能ID
    /// </summary>
    /// <returns></returns>
    public int getID()
    {
        return _skill.SkillID;
    }

    /// <summary>
    /// 获取技能名字
    /// </summary>
    /// <returns></returns>
    public string getName()
    {
        return _skill.SkillName;
    }

    /// <summary>
    /// 延迟释放的时间
    /// </summary>
    /// <returns></returns>
    public float getDelayTime()
    {
        return _skill.DelayTime;
    }


    /// <summary>
    /// 生存时间
    /// </summary>
    /// <returns></returns>
    public float getLiveTime()
    {
        return _skill.LiveTime;
    }

    /// <summary>
    /// 碰撞检测 0：不需要加碰撞检测  1：boxCollider  2： SphereCollider 
    /// 目前不用
    /// </summary>
    /// <returns></returns>
    public byte getColliderType()
    {
        return _skill.ColliderType;
    }

    /// <summary>
    /// boxRange数据
    /// </summary>
    /// <returns></returns>
    public float[] getBoxRange()
    {
        return _skill.BoxRange;
    }


    /// <summary>
    /// colliderRange 数据
    /// </summary>
    /// <returns></returns>
    public float[] getColliderRange()
    {
        return _skill.ColliderRange;
    }


    /// <summary>
    /// 移动类型
    /// </summary>
    /// <returns></returns>
    public byte getMoveType()
    {
        return _skill.SkillMoveType;
    }

    /// <summary>
    /// 绑定位置
    /// </summary>
    /// <returns></returns>
    public byte getBindType()
    {
        return _skill.BindType;
    }


    /// <summary>
    /// 移动速度
    /// </summary>
    /// <returns></returns>
    public float getMoveSpeed()
    {
        return _skill.MoveSpeed;
    }


    /// <summary>
    /// 移动最大的距离
    /// </summary>
    /// <returns></returns>
    public float getMaxMoveSpeed()
    {
        return _skill.MaxMoveDistance;
    }


    /// <summary>
    /// 水平角度
    /// </summary>
    /// <returns></returns>
    public float getCastHorizontalAngle()
    {

        return _skill.CastHorizontalAngle;
    }


    /// <summary>
    /// 垂直角度
    /// </summary>
    /// <returns></returns>
    public float getCastVertiaclAngle()
    {
        return _skill.CastVerticalAngle;
    }

    /// <summary>
    /// 重力设置（例如：抛物线轨迹）
    /// </summary>
    /// <returns></returns>
    public float getGravityValue()
    {
        return _skill.GravityValue;
    }

    /// <summary>
    /// 伤害范围
    /// </summary>
    /// <returns></returns>
    public float getDamageRange()
    {
        return _skill.DamageRange;
    }


    /// <summary>
    /// 伤害角度 （计算碰撞用）
    /// </summary>
    /// <returns></returns>
    public float getDamageAngle()
    {
        return _skill.DamageAngle;
    }


    /// <summary>
    /// 伤害值
    /// </summary>
    /// <returns></returns>
    public int getDamageValue()
    {
        return _skill.DamageValue;
    }


    /// <summary>
    /// 最大伤害个数
    /// </summary>
    /// <returns></returns>
    public short getMaxDamageCount()
    {
        return _skill.MaxDamageCount;
    }

    /// <summary>
    /// 特效ID
    /// </summary>
    /// <returns></returns>
    public int getEffectID()
    {
        return _skill.EffectID;
    }

    /// <summary>
    /// 特效生存时间
    /// </summary>
    /// <returns></returns>
    public float getEffectLiveTime()
    {
        return _skill.DeadEffectLiveTime;
    }

    /// <summary>
    /// 声音ID
    /// </summary>
    /// <returns></returns>
    public int getSoundID()
    {
        return _skill.SoundID;
    }

    /// <summary>
    /// 如果产生buff 就返回BuffID 如果没有 返回 0
    /// </summary>
    /// <returns></returns>
    public int getBuffID()
    {
        return _skill.BuffID;
    }

    /// <summary>
    /// 技能类型（程序中用的）
    /// </summary>
    /// <returns></returns>
    public short getSkillClass()
    {
        return _skill.SkillClass;
    }

    /// <summary>
    /// 技能类型 0 主动  1 被动
    /// </summary>
    /// <returns></returns>
    public byte getSkillType()
    {
        return _skill.SkillType;
    }

    /// <summary>
    /// 攻击目标
    /// </summary>
    /// <returns></returns>
    public byte getHasTarget()
    {
        return _skill.IsHasTarget;
    }

    /// <summary>
    /// 技能伤害类型 0 物理  1 魔法
    /// </summary>
    /// <returns></returns>
    public byte getAttackType()
    {
        return _skill.AttackType;
    }

    /// <summary>
    /// CD时间
    /// </summary>
    /// <returns></returns>
    public float getCDTime()
    {
        return _skill.CDTime;
    }

    /// <summary>
    /// 是否无敌 0 不无敌  1 无敌
    /// </summary>
    /// <returns></returns>
    public short getInvincible()
    {
        return _skill.IsInvincible;
    }

    /// <summary>
    /// 区域技能范围
    /// </summary>
    /// <returns></returns>
    public float[] getAreaCoverage()
    {
        return _skill.AreaCoverage;
    }

    /// <summary>
    /// 技能初始消耗魔法值
    /// </summary>
    /// <returns></returns>
    public int getInitialmagic()
    {
        return _skill.Initialmagic;
    }


    /// <summary>
    /// 技能消耗魔法成长值
    /// </summary>
    /// <returns></returns>
    public float getAddMagic()
    {
        return _skill.Addmagic;
    }

    /// <summary>
    /// 技能等级
    /// </summary>
    /// <returns></returns>
    public int getLevel()
    {
        return _skill.Skilllevel;
    }


    /// <summary>
    /// 武器是否有特效
    /// </summary>
    /// <returns></returns>
    public byte getWeponsHavaEffect()
    {
        return _skill.WeaponHaveEffect;
    }

    /// <summary>
    /// 武器特效ID
    /// </summary>
    /// <returns></returns>
    public int getWeaponsEffectId()
    {
        return _skill.WeaponEffectId;
    }

    /// <summary>
    /// 武器特效挂载点
    /// 1. Left Hand
    /// 2. Right Hand
    /// </summary>
    /// <returns></returns>
    public int getWeponBindType()
    {
        return _skill.WeaponBindType;
    }


    /// <summary>
    /// 武器特效生存时间
    /// </summary>
    public float getWeaponEffectLiveTime()
    {
        return _skill.WeaponEffectLiveTime;
    }


    /// <summary>
    /// 受击挂载点
    /// </summary>
    /// <returns></returns>
    public byte getHitBindType()
    {
        return _skill.HitBindType;
    }


    /// <summary>
    /// 需要计算的值
    /// </summary>
    public float getApplyDamage()
    {
        if (getIsApplyDamage() == 1)
        {
            /// 如果是需要计算的话 返回其计算的值
        }
        else  // 直接返回值
        {
            return 0;
        }

        return 0;
    }
    /// <summary>
    /// 是否需要计算（0: 不计算  1：计算）
    /// </summary>
    /// <returns></returns>
    private byte getIsApplyDamage()
    {
        return _skill.IsApplyDamage;
    }


}