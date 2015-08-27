
using System.Collections.Generic;

/// <summary>
/// 己方数据
/// @author MXL
/// @date 2015-06
/// </summary>
public class RoleAttributeAgent
{
    private RoleAttributeVO _role;

    /// <summary>
    ///  设置对应的数据
    /// </summary>
    /// <param name="id"></param>
    public virtual void setData(int id)
    {
        IList<RoleAttributeVO> list = DataMgr.getInstance().RoleattrBute;

        for (int i = 0; i < list.Count; i++)
        {
            if (list[i].ID == id)
            {
                _role = list[i];
            }
        }
    }

    /// <summary>
    /// ID
    /// </summary>
    /// <returns></returns>
    public virtual int getID()
    {
        return _role.ID;
    }

    /// <summary>
    /// 角色ID
    /// </summary>
    /// <returns></returns>
    public virtual int getRoleID()
    {
        return _role.RoleId;
    }

    /// <summary>
    ///  职业名称
    /// </summary>
    /// <returns></returns>
    public virtual string getRoleName()
    {
        return _role.RoleName;
    }

    /// <summary>
    /// 世界观名称
    /// </summary>
    /// <returns></returns>
    public virtual string getWorldName()
    {
        return _role.WorldName;
    }


    /// <summary>
    /// 角色类型
    /// </summary>
    /// <returns></returns>
    public virtual int getRoleType()
    {
        return _role.RoleType;
    }

    /// <summary>
    /// 模板ID
    /// </summary>
    /// <returns></returns>
    public virtual int getModel()
    {
        return _role.Model;
    }

    /// <summary>
    /// 获取佣兵/怪物的ID
    /// </summary>
    /// <returns></returns>
    public virtual int getMercenary()
    {
        return _role.MercenaryID;
    }

    /// <summary>
    /// 携带佣兵数
    /// </summary>
    /// <returns></returns>
    public virtual int getCarrayMosterNumber()
    {
        return _role.CarryMosterNumber;
    }

    /// <summary>
    /// 角色品阶
    /// </summary>
    /// <returns></returns>
    public virtual int getRoleProduct()
    {
        return _role.RoleProduct;
    }

    /// <summary>
    /// 品阶参数
    /// </summary>
    /// <returns></returns>
    public virtual int getProductParam()
    {
        return _role.ProductParam;
    }

    /// <summary>
    /// 生命值
    /// </summary>
    /// <returns></returns>
    public virtual int getHP()
    {
        return _role.HP;
    }


    /// <summary>
    /// 生命值成长
    /// </summary>
    /// <returns></returns>
    public virtual float getHPGrowth()
    {
        return _role.HPGrowth;
    }


    /// <summary>
    /// 物理强度
    /// </summary>
    /// <returns></returns>
    public virtual int getPhysicalStrength()
    {
        return _role.PhysicalStrength;
    }


    /// <summary>
    /// 物理强度成长
    /// </summary>
    /// <returns></returns>
    public virtual float getPhysicalGrowth()
    {
        return _role.PhysicalGrowth;
    }


    /// <summary>
    /// 物理普攻系数
    /// </summary>
    /// <returns></returns>
    public virtual float getPhysicalNormal()
    {
        return _role.PhysicalNormal;
    }


    /// <summary>
    /// 初始法术强度
    /// </summary>
    /// <returns></returns>
    public virtual int getSpellIntensity()
    {
        return _role.SpellIntensity;
    }


    /// <summary>
    /// 法术强度成长
    /// </summary>
    /// <returns></returns>
    public virtual float getSpellGrowth()
    {
        return _role.SpellGrowth;
    }


    /// <summary>
    /// 法术普攻系数
    /// </summary>
    /// <returns></returns>
    public virtual float getSpellOrdinary()
    {
        return _role.SpellOrdinary;
    }


    /// <summary>
    /// 暴击常数
    /// </summary>
    /// <returns></returns>
    public virtual int getCrit()
    {
        return _role.Crit;
    }


    /// <summary>
    /// 暴击系数
    /// </summary>
    /// <returns></returns>
    public virtual float getCritCoefficient()
    {
        return _role.CritCoefficient;
    }


    /// <summary>
    /// 暴伤常数
    /// </summary>
    /// <returns></returns>
    public virtual int getViolence()
    {
        return _role.Violence;
    }


    /// <summary>
    /// 暴伤系数
    /// </summary>
    /// <returns></returns>
    public virtual float getViolenceCoefficient()
    {
        return _role.ViolenceCoefficient;
    }


    /// <summary>
    /// 初始物理防御
    /// </summary>
    /// <returns></returns>
    public virtual int getPhysicalDefense()
    {
        return _role.PhysicalDefense;
    }


    /// <summary>
    /// 物理防御成长
    /// </summary>
    /// <returns></returns>
    public virtual float getDefGrowth()
    {
        return _role.DefGrowth;
    }


    /// <summary>
    /// 物免常数
    /// </summary>
    /// <returns></returns>
    public virtual int getPhysical()
    {
        return _role.Physical;
    }


    /// <summary>
    /// 物免系数
    /// </summary>
    /// <returns></returns>
    public virtual float getThings()
    {
        return _role.Things;
    }


    /// <summary>
    /// 初始法术防御
    /// </summary>
    /// <returns></returns>
    public virtual int getSpellDefense()
    {
        return _role.SpellDefense;
    }


    /// <summary>
    /// 法术防御成长
    /// </summary>
    /// <returns></returns>
    public virtual float getSdefGrowth()
    {
        return _role.SdefGrowth;
    }


    /// <summary>
    /// 法免常数
    /// </summary>
    /// <returns></returns>
    public virtual int getSpell()
    {
        return _role.Spell;
    }

    /// <summary>
    /// 法免系数
    /// </summary>
    /// <returns></returns>
    public virtual float getSpellCoefficient()
    {
        return _role.SpellCoefficient;
    }

    /// <summary>
    /// 闪避常数
    /// </summary>
    /// <returns></returns>
    public virtual int getDodge()
    {
        return _role.Dodge;
    }


    /// <summary>
    /// 闪避系数
    /// </summary>
    /// <returns></returns>
    public virtual float getDodgeCoefficient()
    {
        return _role.DodgeCoefficient;
    }

    /// <summary>
    /// 普通攻击 间隔
    /// </summary>
    /// <returns></returns>
    public virtual float getInterval()
    {
        return _role.Interval;
    }


    /// <summary>
    /// 基础移动速度
    /// </summary>
    /// <returns></returns>
    public virtual float getSpeed()
    {
        return _role.MoveSpeed;
    }


    /// <summary>
    /// 攻击距离
    /// </summary>
    /// <returns></returns>
    public virtual float getAttackDistance()
    {
        return _role.AttackDistance;
    }


    /// <summary>
    /// 技能列表
    /// </summary>
    /// <returns></returns>
    public virtual int[] getSkills()
    {
        return _role.Skill;
    }


    /// <summary>
    /// 初始蓝量
    /// </summary>
    /// <returns></returns>
    public virtual int getInitialMP()
    {
        return _role.InitialMP;
    }


    /// <summary>
    /// 蓝量成长
    /// </summary>
    /// <returns></returns>
    public float getMpGrowth()
    {
        return _role.MpGrowth;
    }

    /// <summary>
    /// 是否上阵
    /// </summary>
    /// <returns></returns>
    public int getIsBattle()
    {
        return _role.IsBattle;
    }
}