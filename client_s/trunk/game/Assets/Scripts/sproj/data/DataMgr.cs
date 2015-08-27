using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using System.IO;
using System.Text;
using System.Reflection;

using XingLuoTianXia.lib;

/// <summary>
/// 数据生成
/// @author CJC MXL
/// @date 2015-05
/// </summary>
public class DataMgr : XLExcelReadAble
{
    /// <summary>
    /// 单例对象
    /// </summary>
    private static DataMgr g_instance;

    /// <summary>
    /// 人物基本属性
    /// </summary> 
    private IList<RoleAttributeVO> _roleAttrList = new List<RoleAttributeVO>();
    public  IList<RoleAttributeVO> RoleattrBute { get { return _roleAttrList; } }
    
    /// <summary>
    /// 技能描述信息
    /// </summary> 
    private IList<SkillVO> _skills = new List<SkillVO>();
    public  IList<SkillVO> Skills { get { return _skills; } }

    /// <summary>
    /// 特效描述
    /// </summary> 
    private IList<EffectsVO> _effects = new List<EffectsVO>();
    public  IList<EffectsVO> Effects { get { return _effects; } }

    /// <summary>
    ///  buff描述
    /// </summary>
    private IList<BuffsVO> _buffs = new List<BuffsVO>();
    public  IList<BuffsVO> Buffs { get { return _buffs; } }

    /// <summary>
    /// buff效果描述
    /// </summary>
    private IList<BuffPropertyVO> _buffPro = new List<BuffPropertyVO>();
    public  IList<BuffPropertyVO> BuffPro { get { return _buffPro; } }

    /// <summary>
    /// buff存在规则
    /// </summary>
    private IList<BuffRuleV0> _buffRule = new List<BuffRuleV0>();
    public  IList<BuffRuleV0> BuffRule { get { return _buffRule; } }

    /// <summary>
    /// 战役
    /// </summary>
    /// <returns></returns>
    private IList<CheckPointVO> _checkPoint = new List<CheckPointVO>();
    public  IList<CheckPointVO> CheckPoint { get { return _checkPoint; } }

    /// <summary>
    /// 战场数据
    /// </summary>
    private IList<BattleVO> _battle = new List<BattleVO>();
    public IList<BattleVO> Battle { get { return _battle; } }

    /// <summary>
    /// 阵型数据
    /// </summary>
    /// <returns></returns>
    private IList<FormationVO> _formation = new List<FormationVO>();
    public  IList<FormationVO> Formation { get { return _formation; } }

    /// <summary>
    /// 阵型
    /// </summary>
    /// <returns></returns>
    private IList<ShapeVO> _shape = new List<ShapeVO>();
    public IList<ShapeVO> Shape { get { return _shape; } }

    /// <summary>
    /// 怪物/佣兵 数据
    /// </summary>
    /// <returns></returns>
    private IList<MonsterVO> _monster = new List<MonsterVO>();
    public  IList<MonsterVO> Monster { get { return _monster; } }

    /// <summary>
    /// 携带士兵数据
    /// </summary>
    private IList<SoldiersCollocationVO> _soldiersCollocation = new List<SoldiersCollocationVO>();
    public IList<SoldiersCollocationVO> SoldiersCollocation { get { return _soldiersCollocation; } }

    /// <summary>
    /// 获取单利对象
    /// </summary>
    /// <returns></returns>
    public static DataMgr getInstance()
    {
        if (g_instance == null)
        {
            g_instance = new DataMgr();
        }

        return g_instance;
    }

    /// <summary>
    /// 读取对应的 bin 文件
    /// </summary>
    private DataMgr()
    {
        // 阵型数据
        readVO<FormationVO>(_formation, "FormationVO");

        // 人物基本属性
        readVO<RoleAttributeVO>(_roleAttrList, "RoleAttributeVO");

        // 技能描述
        readVO<SkillVO>(_skills, "SkillVO");

        // 特效描述
        readVO<EffectsVO>(_effects, "EffectsVO");

        // buff描述
        readVO<BuffsVO>(_buffs, "BuffsVO");

        // buff属性描述
        readVO<BuffPropertyVO>(_buffPro, "BuffPropertyVO");

        //buff 规则
        readVO<BuffRuleV0>(_buffRule, "BuffRuleV0");

        //战役
        readVO<CheckPointVO>(_checkPoint, "CheckPointVO");

        // 战场数据
        readVO<BattleVO>(_battle, "BattleVO");
        
        //阵型
        readVO<ShapeVO>(_shape, "ShapeVO");

        //敌方数据
        readVO<MonsterVO>(_monster, "MonsterVO");

        //携带士兵数据
        readVO<SoldiersCollocationVO>(_soldiersCollocation, "SoldiersCollocationVO");
    }
}

