/// <summary>
/// @Description: 预设值
/// @author WSG
/// @date 2015-0414
/// </summary>
public class Defaults {

    /// <summary>
    /// 数值为 0 的 假 值
    /// </summary>
    public const int FALSE = 0;

    /// <summary>
    /// 数值为 1 的 真 值
    /// </summary>
    public const int TRUE = 1;

    /// <summary>
    /// 士兵缩放比
    /// </summary>
    public const float SOLDIER_SCALE = 1f;

    /// <summary>
    /// 帧频（主要用来计算动画播放速度）
    /// </summary>
    public const int FRAME_RATE = 60;
    


    /// <summary>
    /// 地方类型
    /// </summary>
    public enum MonsterType : byte
    {
        //普通
        ordinary = 0,
        // boss
        boss
    }


    public enum FormationIdArray : byte
    {
        zero = 0,

    }

    
    /// <summary>
    /// 兵种
    /// </summary>
    public enum SoldierType : byte
    {
        /** 刀兵 */
        Swordman = 0,

        /** 弓箭手 */
        Bowman,

        /** 骑士 */
        Cavalryman,

        /** 斧兵 */
        Axeman,

        /** 法师 */
        Masterman,

        /** 盔甲兵 */
        Armorman,

        //---------------------------------------------- 英雄类型选择 ----------------------------------------------
        /**战士*/
        warrior ,
        /**骑士*/
        knight,
        /**弓箭手*/
        archer,
        /**盗贼*/
        robbers,
        /**法师*/
        mage,
        /**牧师*/
        pastor
    }



    /// <summary>
    /// 所有状态的类型枚举
    /// </summary>
    public enum StateType : int
    {
        //空
        Null = 0,

        //战斗单位--静止状态
        Soldier_State_Stop,

        //战斗单位--行军状态
        Soldier_State_Walk,

        //战斗单位--战斗状态
        Soldier_State_Fight,

        //战斗单位--受击状态
        Soldier_State_Hurt,

        //战斗单位--死亡状态
        Soldier_State_Dead,

        //战斗单位--胜利状态
        Soldier_State_Win,


        //战斗单位——释放技能
        Soleier_State_Skill,
    }

    /// <summary>
    /// 加载数据类型
    /// </summary>
    public enum LoadDataType : byte
    {
        // 战役下的所有数据（战场，编队等）
        Load_Data_Fight = 0,
        // UI
        Load_Data_UI,
        // 声音
        Load_Data_Sound

    }
    /// <summary>
    /// 所有行为的类型枚举
    /// </summary>
    public enum ActionType : byte
    {
        //空
        Null = 0,

        //站立行为
        Stand,

        //寻敌行为
        Find,

        //靠近行为
        Move,

        //普通攻击行为
        Attack,

        //受击行为
        Hurt,

        //技能行为
        Skill,

        //死亡行为
        Dead,
    };

    /// <summary>
    /// 行为的执行状态
    /// </summary>
    public enum ActionState : byte
    {
        //行为未执行
        Action_State_Null = 0,

        //行为执行中
        Action_State_Running,

        //行为执行完毕
        Action_State_Complete,
    }
   

    /// <summary>
    /// 国家归属
    /// </summary>
    public enum Country : byte
    {
        /** 玩家自己 */
        Me = 0,

        /** 敌人 */
        Enemy,

        /** 友军 */
        Friend,
    };

    public enum NotificationID : byte
    {
        START = 0,
        UPDATA,
        OVER,
    }


    /// <summary>
    /// 通用数字
    /// </summary>
    public enum ResultNum : byte
    {
        Zero = 0,
        One,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        nine,
        Ten
    }



    
}
