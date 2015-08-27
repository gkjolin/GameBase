
using System.Collections.Generic;

/// <summary>
/// 敌方数据
/// @author MXL
/// @date 2015-06
/// </summary>
public class MonsterAgent : RoleAttributeAgent
{
    private MonsterVO _monst;

    public MonsterAgent()
        : base()
    {

    }

    /// <summary>
    /// 获取对应的数据
    /// </summary>
    /// <param name="id"></param>
    public override void setData(int id)
    {
        IList<MonsterVO> list = DataMgr.getInstance().Monster;

        for (int i = 0; i < list.Count; i++)
        {
            if (list[i].ID == id)
            {
                _monst = list[i];
            }
        }
    }

    /// <summary>
    /// sid
    /// </summary>
    /// <returns></returns>
    public override int getID()
    {
        return _monst.ID;
    }

    /// <summary>
    /// 获取队型ID
    /// </summary>
    /// <returns></returns>
    //public override int getFormationId()
    //{
    //    return _monstHead.Formation;
    //}

    /// <summary>
    /// 怪物名字
    /// </summary>
    /// <returns></returns>
    public override string getRoleName()
    {
        return _monst.MosterName;
    }


    /// <summary>
    /// 怪物职业ID
    /// </summary>
    /// <returns></returns>
    public override int getRoleID()
    {
        return _monst.MosterProfessional;
    }


    /// <summary>
    /// 拥有兵种ID
    /// </summary>
    /// <returns></returns>
    public override int getMercenary()
    {
        return _monst.HavaMosterID;
    }


    /// <summary>
    /// 获取携带佣兵数量
    /// </summary>
    /// <returns></returns>
    public override int getCarrayMosterNumber()
    {
        return _monst.CarryMosterNumber;
    }

    /// <summary>
    /// 模型
    /// </summary>
    /// <returns></returns>
    public override int getModel()
    {

        return _monst.Model;
    }

    public override int[] getSkills()
    {
        return _monst.Skill;
    }

    /// <summary>
    /// 生命值
    /// </summary>
    /// <returns></returns>
    public override int getHP()
    {
        return _monst.HP;
    }

    /// <summary>
    /// 获取蓝量
    /// </summary>
    /// <returns></returns>
    public override int getInitialMP()
    {
        return _monst.MP;
    }

    /// <summary>
    /// 物理强度
    /// </summary>
    /// <returns></returns>
    public override int getPhysicalStrength()
    {
        return _monst.PhysicalStrength;
    }

    /// <summary>
    /// 物强普攻系数
    /// </summary>
    /// <returns></returns>
    public override float getPhysicalNormal()
    {
        return _monst.PhysicalNormal;
    }

    /// <summary>
    /// 法术强度
    /// </summary>
    /// <returns></returns>
    public override int getSpellIntensity()
    {
        return _monst.SpellIntensity;
    }

    /// <summary>
    /// 法强普攻系数
    /// </summary>
    /// <returns></returns>
    public override float getSpellOrdinary()
    {
        return _monst.SpellOrdinary;
    }

    /// <summary>
    /// 暴击常数
    /// </summary>
    /// <returns></returns>
    public override int getCrit()
    {
        return _monst.Crit;
    }

    /// <summary>
    /// 暴击系数
    /// </summary>
    /// <returns></returns>
    public override float getCritCoefficient()
    {
        return _monst.CritCoefficient;
    }



    /// <summary>
    /// 暴伤常数
    /// </summary>
    /// <returns></returns>
    public override int getViolence()
    {
        return _monst.Violence;
    }


    /// <summary>
    /// 暴伤系数
    /// </summary>
    /// <returns></returns>
    public override float getViolenceCoefficient()
    {
        return _monst.ViolenceCoefficient;
    }

    /// <summary>
    /// 物理防御
    /// </summary>
    /// <returns></returns>
    public override int getPhysicalDefense()
    {
        return _monst.PhysicalDefense;
    }

    /// <summary>
    /// 物免常数
    /// </summary>
    /// <returns></returns>
    public override int getPhysical()
    {
        return _monst.Physical;
    }


    /// <summary>
    /// 物免系数
    /// </summary>
    /// <returns></returns>
    public override float getThings()
    {
        return _monst.Things;
    }

    /// <summary>
    /// 法术防御
    /// </summary>
    /// <returns></returns>
    public override int getSpellDefense()
    {
        return _monst.SpellDefense;
    }


    /// <summary>
    /// 法免常数
    /// </summary>
    /// <returns></returns>
    public override int getSpell()
    {
        return _monst.Spell;
    }


    /// <summary>
    /// 法免系数
    /// </summary>
    /// <returns></returns>
    public override float getSpellCoefficient()
    {
        return _monst.SpellCoefficient;
    }


    /// <summary>
    /// 闪避强度
    /// </summary>
    /// <returns></returns>
    public int getDodgeIntensity()
    {
        return _monst.DodgeIntensity;
    }




    /// <summary>
    /// 闪避常数
    /// </summary>
    /// <returns></returns>
    public override int getDodge()
    {
        return _monst.Dodge;
    }


    /// <summary>
    ///  闪避系数
    /// </summary>
    /// <returns></returns>
    public override float getDodgeCoefficient()
    {
        return _monst.DodgeCoefficient;
    }


    /// <summary>
    /// 攻击间隔
    /// </summary>
    /// <returns></returns>
    public override float getInterval()
    {
        return _monst.Interval;
    }

    /// <summary>
    /// 移动速度
    /// </summary>
    /// <returns></returns>
    public override float getSpeed()
    {
        return _monst.MoveSpeed;
    }


    /// <summary>
    /// 攻击距离
    /// </summary>
    /// <returns></returns>
    public override float getAttackDistance()
    {
        return _monst.AttackDistance;
    }


    /// <summary>
    /// 战斗力
    /// </summary>
    /// <returns></returns>
    public int getCombat()
    {
        return _monst.Combat;
    }


    /// <summary>
    /// 掉落包
    /// </summary>
    /// <returns></returns>
    public int getDrop()
    {
        return _monst.Drop;
    }


    /// <summary>
    /// 攻速加成
    /// </summary>
    /// <returns></returns>
    public float getBonus()
    {
        return _monst.Bonus;
    }


    /// <summary>
    /// 暴伤强度
    /// </summary>
    /// <returns></returns>
    public int getViolenceIntensity()
    {
        return _monst.ViolenceIntensity;
    }

    /// <summary>
    /// 暴击强度
    /// </summary>
    /// <returns></returns>
    public float getCritIntensity()
    {
        return _monst.CritIntensity;
    }

    /// <summary>
    /// 等级
    /// </summary>
    /// <returns></returns>
    public int getLevel()
    {
        return _monst.Level;
    }

}