using UnityEngine;
using System.Collections.Generic;

using XingLuoTianXia.lib;

/// <summary>
/// 编队的数据类
/// @author MXL
/// @date 2015-07
/// </summary>
public class FormationData
{

    // ----------------------------------------- 历史数据 ---------------------------------------------
    /// <summary>
    /// 编队的国家（阵容）
    /// </summary>
    public Defaults.Country country;

    /// <summary>
    /// 记录编队id 最多6个编队
    /// </summary>
    public int formationId = 0;

    /// <summary>
    /// 英雄的类型，通过这个判断阵型
    /// </summary>
    public Defaults.SoldierType heroType;
    /// <summary>
    ///  携带士兵的类型
    /// </summary>
    public Defaults.SoldierType  soldierType;

    /// <summary>
    /// 兵种数据，数据统一，但是要分开管理 -- 暂留
    /// </summary>
   // public SoldierDataBase [] soldierData;
    /// <summary>
    /// 士兵 pos  
    /// </summary>
    public float[] formationData;

    /// <summary>
    /// 编队中心坐标 -- 英雄所在的位置
    /// </summary>
    public Vector3 point;

    /// <summary>
    /// 目标编队  -- 目前先保留下 看策划需求
    /// </summary>
    //public Soldier fightTarget;

    /// <summary>
    /// 这个编队 士兵数量
    /// </summary>
    public int soldierNumebr = 0;

    // ----------------------------------------- 历史数据 ---------------------------------------------
    /// <summary>
    /// 英雄数据
    /// </summary>
    private RoleAttributeAgent _monster;

    // 士兵数据
    private SoldierDataBase _soldier;

    /// <summary>
    /// 阵型所有信息
    /// </summary>
    public Dictionary<int, SoldierDataBase> SoldiersDict;

    private bool _isMe = false;

    // 保存当前阵型的位置信息
    private float[] _myPos;

    // 当前阵型的数据
    private int[] _shapeData;

    /// <summary>
    /// // 英雄ID
    /// isMe : 是否是自己的英雄
    /// </summary>
    /// <param name="heroId"></param>
    //public FormationData(FormationAgent formation, int []soldArray, bool isMe)

    // 兵种结构值， 阵型id  pos信息，是否是自己
    public FormationData(int soldierId, int shapeId, float []posArray, bool isMe)
    {


        SoldiersDict = new Dictionary<int, SoldierDataBase>();

        _myPos = (float[])posArray.Clone();

        // 阵型数据
        ShapeAgent shape = new ShapeAgent();
        shape.setData(shapeId);

        // 阵型数据
        _shapeData = shape.get();      

        // 是否是自己
        this._isMe = isMe;

        if (isMe == true)
        {
            _monster = new RoleAttributeAgent();
        }
        else
        {
            _monster = new MonsterAgent();
            
        }   

        // 添加数据到表中
        addSoldierData(soldierId, isMe);

    }

    /// <summary>
    ///  将所有数据添加进字典中
    /// </summary>
    private void addSoldierData( int soldierId, bool isMe)
    {
        SoldiersCollocationAgent soldiers = new SoldiersCollocationAgent();

        soldiers.setData(soldierId);

        // 对应的兵种ID
        int[] soldierIdArray = soldiers.getSoldies();

        for (int i = 0; i < soldierIdArray.Length; ++i)
        {
            if (soldierIdArray[i] != 0)
            {
                SoldierDataBase soldier = new SoldierDataBase();
                soldier.Sid = soldierIdArray[i];

                setSoldierData(soldier);

                SoldiersDict.Add(i, soldier);
            }
            else // 占位用
            {
                SoldiersDict.Add(i, null);
            }
        }
    }

    /// <summary>
    /// 设置数据
    /// </summary>
    //private void setSoldierHeroData(SoldierDataBase _heroSoldier)
    private void setSoldierData(SoldierDataBase heroSoldier)

    {

        // 相关的类型转换
        _monster = _isMe == true ? _monster : ((MonsterAgent)_monster);

        // 设置对应的数据
        _monster.setData(heroSoldier.Sid);

        // 设置英雄数据
        heroSoldier.Sid                          = _monster.getID() ;

        heroSoldier.Model                        = _monster.getModel();

        heroSoldier.HP                           =  _monster.getHP() ;

        // TODO 
        if (heroSoldier.HP<=0)
        {
            int a=0;
        }

        heroSoldier.RoleID                       = _monster.getRoleID(); 
    
        heroSoldier.RoleName                     = _monster.getRoleName();

        heroSoldier.PhysicalStrength             =  _monster.getPhysicalStrength();

        heroSoldier.PhysicalNormal               =  _monster.getPhysicalNormal();

        heroSoldier.SpellIntensity               =  _monster.getSpellIntensity();

        heroSoldier.SpellOrdinary                =  _monster.getSpellOrdinary() ;

        heroSoldier.Crit                         =  _monster.getCrit();

        heroSoldier.CritCoefficient              =  _monster.getCritCoefficient();

        heroSoldier.Violence                     =  _monster.getViolence() ;

        heroSoldier.ViolenceCoefficient          =  _monster.getViolenceCoefficient();

        heroSoldier.PhysicalDefense              =  _monster.getPhysicalDefense();

        heroSoldier.Physical                     =  _monster.getPhysical();

        heroSoldier.Things                       =  _monster.getThings();

        heroSoldier.SpellDefense                 =  _monster.getSpellDefense();

        heroSoldier.Spell                        =  _monster.getSpell();

        heroSoldier.SpellCoefficient             =  _monster.getSpellCoefficient();

        heroSoldier.Dodge                        =  _monster.getDodge();

        heroSoldier.DodgeCoefficient             = _monster.getDodgeCoefficient();

        heroSoldier.Interval                     =  _monster.getInterval();

        heroSoldier.MoveSpeed                    =  _monster.getSpeed();

        heroSoldier.AttckDistance                =   _monster.getAttackDistance();

        heroSoldier.Skills                       = _monster.getSkills();

        heroSoldier.InitialMP                    = _monster.getInitialMP();

        // 目前没啥用  从 兵种结构那里可以获取
        heroSoldier.CarryMosterNumber            = _monster.getCarrayMosterNumber();  // 佣兵数量

        heroSoldier.HavaMosterID                 = _monster.getMercenary(); // 如果是英雄那么他将拥有兵种ID


        if (_isMe == true) // 自己的英雄数据
        {      

            heroSoldier.WorldName      = _monster.getWorldName();

            heroSoldier.RoleType       = _monster.getRoleType();

            heroSoldier.RoleProduct    = _monster.getRoleProduct();

            heroSoldier.ProductParam   = _monster.getProductParam();

            heroSoldier.HPGrowth       = _monster.getHPGrowth();

            heroSoldier.PhysicalGrowth = _monster.getPhysicalGrowth();

            heroSoldier.SpellGrowth    = _monster.getSpellGrowth();

            heroSoldier.DefGrowth      = _monster.getDefGrowth();

            heroSoldier.SdefGrowth     = _monster.getSdefGrowth();

            heroSoldier.MPGrowth       = _monster.getMpGrowth();
        }
        else  // 敌方
        {
            heroSoldier.Level                 = ((MonsterAgent)_monster).getLevel();

            heroSoldier.DodgeIntensity        = ((MonsterAgent)_monster).getDodgeIntensity();

            heroSoldier.Bonus                 = ((MonsterAgent)_monster).getBonus();

            heroSoldier.Combat                = ((MonsterAgent)_monster).getCombat();

            heroSoldier.Drop                  = ((MonsterAgent)_monster).getDrop();

            heroSoldier.ViolenceIntensity     = ((MonsterAgent)_monster).getViolenceIntensity();

            heroSoldier.CritIntensity         = ((MonsterAgent)_monster).getCritIntensity();
        }


        heroSoldier.ATK = Formula.Formula.getNakedAttribute(heroSoldier.PhysicalStrength, _isMe == true ? heroSoldier.PhysicalGrowth : 0, 0);

        heroSoldier.SATK = Formula.Formula.getNakedAttribute(heroSoldier.SpellIntensity,  _isMe == true ? heroSoldier.SpellGrowth : 0, 0);

    }


    /// <summary>
    ///  当前阵型数据 
    /// </summary>
    /// <returns></returns>
    public int[] getShape()
    {
        return _shapeData;
    }

    /// <summary>
    ///  当前pos
    /// </summary>
    /// <returns></returns>
    public float[] getPos()
    {
        return _myPos;
    }
}
