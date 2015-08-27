using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace XingLuoTianXia.lib 
{
    /// <summary>
    /// @Description: 战斗单位数据体基类
    /// @author WSG
    /// @date 2015-0413
    /// </summary>
    public class SoldierDataBase : DataBase
    {
        // ------------------------------ 历史 ---------------------------------

        protected int _atkSpeed;
        public int ATKSpeed
        {
            get { return _atkSpeed; }
            set { _atkSpeed = value; }
        }

        protected float _speed;
        public float Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }




        protected int _deadDelay;
        public int DeadDelay
        {
            get { return _deadDelay; }
            set { _deadDelay = value; }
        }

        protected Defaults.Country _country;
        public Defaults.Country Country
        {
            get { return _country; }
            set { _country = value; }
        }

        // ------------------------------ 历史 ---------------------------------

        /// <summary>
        /// 物理攻击力
        /// </summary>
        protected int _atk;
        public int ATK
        {
            get { return _atk; }
            set { _atk = value; }
        }

        /// <summary>
        /// 魔法攻击力
        /// </summary>
        protected int _sAtk;
        public int SATK
        {
            get { return _sAtk; }
            set { _sAtk = value; }
        }

        /// <summary>
        /// 攻击目标
        /// </summary>
        protected XLSpriteBase _attackTarget = null;
        public XLSpriteBase AttackTarget
        {

            get { return _attackTarget; }
            set { _attackTarget = value; }
        }


        /// <summary>
        /// id
        /// </summary>
        protected int _sid;
        public int Sid
        {
            get { return _sid; }
            set { _sid = value; }
        }

        /// <summary>
        /// 模型ID
        /// </summary>
        protected int _model;
        public int Model
        {
            get { return _model; }
            set { _model = value; }
        }

        /// <summary>
        /// 生命值
        /// </summary>
        protected int _hp;
        public int HP
        {
            get { return _hp; }
            set { _hp = value; }
        }

        /// <summary>
        /// 初始魔法值
        /// </summary>
        protected int _initialMP;
        public int InitialMP
        {
            get { return _initialMP; }
            set { _initialMP = value; }
        }

        /// <summary>
        /// 蓝量成长
        /// </summary>
        protected float _mpGrowth;
        public float MPGrowth
        {
            get { return _mpGrowth; }
            set { _mpGrowth = value; }
        }

        /// <summary>
        /// 物理强度
        /// </summary>
        protected int _physicalStrength;
        public int PhysicalStrength
        {
            get { return _physicalStrength; }
            set { _physicalStrength = value; }
        }

        /// <summary>
        /// 物理普攻系数
        /// </summary>
        protected float _physicalNormal;
        public float PhysicalNormal
        {
            get { return _physicalNormal; }
            set { _physicalNormal = value; }
        }


        /// <summary>
        /// 法术强度
        /// </summary>
        protected int _spellIntensity;
        public int SpellIntensity
        {
            get { return _spellIntensity; }
            set { _spellIntensity = value; }
        }

        /// <summary>
        /// 法强普攻系数
        /// </summary>
        protected float _spellOrdinary;
        public float SpellOrdinary
        {
            get { return _spellOrdinary; }
            set { _spellOrdinary = value; }
        }


        /// <summary>
        /// 暴击常数
        /// </summary>
        protected int _crit;
        public int Crit
        {
            get { return _crit; }
            set { _crit = value; }
        }

        /// <summary>
        /// 暴击系数
        /// </summary>
        protected float _critCoefficient;
        public float CritCoefficient
        {
            get { return _critCoefficient; }
            set { _critCoefficient = value; }
        }



        /// <summary>
        /// 暴伤常数
        /// </summary>
        protected int _violence;
        public int Violence
        {
            get { return _violence; }
            set { _violence = value; }
        }

        /// <summary>
        /// 暴伤系数
        /// </summary>
        protected float _violenceCoefficient;
        public float ViolenceCoefficient
        {
            get { return _violenceCoefficient; }
            set { _violenceCoefficient = value; }
        }

        /// <summary>
        /// 物理防御
        /// </summary>
        protected int _physicalDefense;
        public int PhysicalDefense
        {
            get { return _physicalDefense; }
            set { _physicalDefense = value; }
        }



        /// <summary>
        /// 物免常数
        /// </summary>
        protected int _physical;
        public int Physical
        {
            get { return _physical; }
            set { _physical = value; }
        }


        /// <summary>
        /// 物免系数
        /// </summary>
        protected float _things;
        public float Things
        {
            get { return _things; }
            set { _things = value; }
        }

        /// <summary>
        /// 法术防御
        /// </summary>
        protected int _spellDefense;
        public int SpellDefense
        {
            get { return _spellDefense; }
            set { _spellDefense = value; }
        }

        /// <summary>
        /// 法免常数
        /// </summary>
        protected int _spell;
        public int Spell
        {
            get { return _spell; }
            set { _spell = value; }
        }

        /// <summary>
        /// 法免系数
        /// </summary>
        protected float _spellCoefficient;
        public float SpellCoefficient
        {
            get { return _spellCoefficient; }
            set { _spellCoefficient = value; }
        }


        /// <summary>
        /// 闪避常数
        /// </summary>
        protected int _dodge;
        public int Dodge
        {
            get { return _dodge; }
            set { _dodge = value; }
        }

        /// <summary>
        /// 闪避系数
        /// </summary>
        protected float _dodgeCoefficient;
        public float DodgeCoefficient
        {
            get { return _dodgeCoefficient; }
            set { _dodgeCoefficient = value; }
        }

        /// <summary>
        /// 攻击间隔
        /// </summary>
        protected float _interval;
        public float Interval
        {
            get { return _interval; }
            set { _interval = value; }
        }





        /// <summary>
        /// 移动速度
        /// </summary>
        protected float _moveSpeed;
        public float MoveSpeed
        {
            get { return _moveSpeed; }
            set { _moveSpeed = value; }
        }


        /// <summary>
        /// 攻击距离
        /// </summary>
        protected float _attackDistance;
        public float AttckDistance
        {
            get { return _attackDistance; }
            set { _attackDistance = value; }
        }




        /// --------------------------------------------- 玩家自身英雄一些属性-----------------------------------------
        /// <summary>
        /// 保存技能数据
        /// </summary>

        public int[] Skills;


        /// <summary>
        /// 技能管理器
        /// </summary>
        protected SkillsManager _skillManager = new SkillsManager();
        public SkillsManager SkillMgr
        {
            get { return _skillManager; }
            set { _skillManager = value; }
        }

        /// <summary>
        /// 角色直接ID
        /// </summary>
        protected int _roleID;
        public int RoleID
        {
            get { return _roleID; }
            set { _roleID = value; }
        }


        /// <summary>
        /// 角色职业名字 or 怪物名字
        /// </summary>
        protected string _roleName;
        public string RoleName
        {
            get { return _roleName; }
            set { _roleName = value; }

        }


        /// <summary>
        /// 世界观中名字
        /// </summary>
        protected string _worldName;
        public string WorldName
        {
            get { return _worldName; }
            set { _worldName = value; }
        }

        /// <summary>
        /// 角色类型
        /// </summary>
        protected int _roleType;
        public int RoleType
        {
            get { return _roleType; }
            set { _roleType = value; }
        }


        /// <summary>
        /// 角色品阶
        /// </summary>
        protected int _roleProduct;
        public int RoleProduct
        {
            get { return _roleProduct; }
            set { _roleProduct = value; }
        }


        /// <summary>
        /// 品阶参数
        /// </summary>
        protected int _productParam;
        public int ProductParam
        {
            get { return _productParam; }
            set { _productParam = value; }
        }

        /// <summary>
        /// 生命成长
        /// </summary>
        protected float _hpGrowth;
        public float HPGrowth
        {
            get { return _hpGrowth; }
            set { _hpGrowth = value; }
        }


        /// <summary>
        /// 物理成长
        /// </summary>
        protected float _physicalGrowth;
        public float PhysicalGrowth
        {
            get { return _physicalGrowth; }
            set { _physicalGrowth = value; }
        }


        /// <summary>
        /// 法术成长
        /// </summary>
        protected float _spellGrowth;
        public float SpellGrowth
        {
            get { return _spellGrowth; }
            set { _spellGrowth = value; }
        }

        /// <summary>
        /// 物理防御成长
        /// </summary>
        protected float _defGrowth;
        public float DefGrowth
        {
            get { return _defGrowth; }
            set { _defGrowth = value; }
        }


        /// <summary>
        /// 法术防御成长
        /// </summary>
        protected float _sdefGrowth;
        public float SdefGrowth
        {
            get { return _sdefGrowth; }
            set { _sdefGrowth = value; }

        }

        /// <summary>
        /// 拥有佣兵数量
        /// </summary>
        protected int _carryMosterNumber = 0;
        public int CarryMosterNumber
        {
            get { return _carryMosterNumber; }
            set { _carryMosterNumber = value; }

        }

        /// <summary>
        /// 拥有佣兵ID
        /// </summary>
        protected int _havaMosterID = 0;
        public int HavaMosterID
        {
            get { return _havaMosterID; }
            set { _havaMosterID = value; }

        }

        /// --------------------------------------------- 玩家自身英雄一些属性-----------------------------------------

        ///-------------------------------------------------- 敌方拥有的属性 -----------------------------------------
        /// <summary>
        /// 等级
        /// </summary>
        protected int _level;
        public int Level
        {
            get { return _level; }
            set { _level = value; }
        }

        /// <summary>
        /// 闪避强度
        /// </summary>
        protected int _dodgeIntensity;
        public int DodgeIntensity
        {
            get { return _dodgeIntensity; }
            set { _dodgeIntensity = value; }
        }

        /// <summary>
        /// 攻速加成
        /// </summary>
        protected float _bonus;
        public float Bonus
        {
            get { return _bonus; }
            set { _bonus = value; }
        }


        /// <summary>
        /// 战斗力
        /// </summary>
        protected int _combat;
        public int Combat
        {
            get { return _combat; }
            set { _combat = value; }
        }


        /// <summary>
        /// 掉落包ID
        /// </summary>
        protected int _drop;
        public int Drop
        {
            get { return _drop; }
            set { _drop = value; }
        }

        /// <summary>
        /// 暴伤强度
        /// </summary>
        protected int _violenceIntensity;
        public int ViolenceIntensity
        {
            get { return _violenceIntensity; }
            set { _violenceIntensity = value; }
        }

        /// <summary>
        /// 暴击强度
        /// </summary>
        protected float _critIntensity;
        public float CritIntensity
        {
            get { return _critIntensity; }
            set { _critIntensity = value; }
        }

        ///-------------------------------------------------- 敌方拥有的属性 -----------------------------------------




    }
}

