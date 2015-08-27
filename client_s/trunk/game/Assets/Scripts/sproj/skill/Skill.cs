/// /// <summary>
/// 技能描述/ 资源加载
/// @author MXL
/// @date 2015-07
/// </summary>
using UnityEngine;
using System.Collections.Generic;


/// <summary>
///  武器类型（左手，右手  双手）
/// </summary>
enum weaponsType
{
    left = 0, 
    right  ,  
    bothHands
}


public class Skill
{
    /// <summary>
    ///  数据
    /// </summary>
    private SkillData _skillData;

    /// <summary>
    /// 逻辑处理实例
    /// </summary>
    private SkillLogic _skillLogic;

    /// <summary>
    /// 释放者
    /// </summary>
    private GeneralSoldier _eman;

    // 技能ID
    public int skillId = 0;

    // 技能挂载点
    public string mountPoint = "";


    /// <summary>
    /// 技能释放对象
    /// </summary>
    public GeneralSoldier Sold
    {
        get { return _eman; }
    }

    public SkillData Data
    {
        get { return _skillData; }
    }


    public Skill(GeneralSoldier soldier, int id)
    {
        if (id == 0)
        {
            return;
        }

        skillId = id;
        // 数据
        _skillData = new SkillData(id);


        mountPoint = getBindType(0);//(_skillData.Skill.getBindType());

        _eman = soldier;

        //加载技能所需要的特效
        loadSkllResource();

        setInstance();

    }

    /// <summary>
    /// 加载技能所需要的特效
    /// </summary>
    private void loadSkllResource()
    {
        foreach(int key in _skillData.Effect.Keys)
        {
            if (!EffectsManager.getInstance().hasEffect(_skillData.Effect[key].getEffectName()))
           {
                GameObject effect = Resources.Load<GameObject>(_skillData.Effect[key].getEffectName());

                // 设置pool name 和存放的对象
                EffectPool pool = new EffectPool( effect);

                EffectsManager.getInstance().add(pool);
           }
        }      
    }



    /// <summary>
    ///  播放
    /// </summary>
    /// <param name="id"></param>
    /*
     * --技能类型--
     * 1:隐身
       2:突进
       3:Debuff
       4:召唤
       5:Buff
       6:触发型
       7:伤害型
     * 
     * **/
    private void setInstance()
    {
        switch (_skillData.Skill.getSkillClass())
        {
            case (int)Defaults.ResultNum.One:
                
                _skillLogic = new StealthInstance();
                break;

            case (int)Defaults.ResultNum.Two:
                
                _skillLogic = new DashInstance();
                break;

            case (int)Defaults.ResultNum.Three:

                _skillLogic = new DebuffInstance();
                break;

            case (int)Defaults.ResultNum.Four:

                _skillLogic = new SummonInstance();
                break;

            case (int)Defaults.ResultNum.Five:

                _skillLogic = new BuffInstance();
                break;

            case (int)Defaults.ResultNum.Six:

                _skillLogic = new TriggerInstance();
                break;

            case (int)Defaults.ResultNum.Seven:

                _skillLogic = new DamageInstance();
                break;
        }
    }


    /// <summary>
    /// 获取绑定点 - 与骨骼名对应
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    private string getBindType(int type)
    {
        string str = "";

        string pathRoot = "";

        switch (type)
        {
            case 0:
                str = "head";
                break;
            case 1:
                str = "center";
                break;
            case 2:
                str = "foot";
                break;
            case 3:
               // str = pathRoot + "Bip01 L Clavicle/";
                break;
            case 4:
                //str = pathRoot + "";
                break;
            default:
                str = "center";
                break;
        }

        return str;
 
    }
    
    /// <summary>
    /// 相关骨骼映射
    /// </summary>
    /// <param name="weapons"></param>
    /// <returns></returns>
    private string getBindType(weaponsType weapons)
    {

        // 最后返回的路径
        string str = "";

        switch (_eman.transform.name.Substring(0, _eman.transform.name.LastIndexOf("(")))
        {
            case "A_JS_RenLei_A_001":

                str = "Bip01/Bip01 Pelvis/Bip01 Spine/Bip01 Spine1/Bip01 Neck/Bip01 R Clavicle/Bip01 R UpperArm/Bip01 R Forearm/Bip01 R Hand/right";
                       
                break;

            case "AxeSoldierPre":

                str = "Bip01/Bip01 Pelvis/Bip01 Spine/Bip01 Neck/Bip01 R Clavicle/Bip01 R UpperArm/Bip01 R Forearm/Bip01 R Hand/Bone01_wuqi/right";
                       
                break;

            case "GaylenPre":
                str = "Bip01/Bip01 Pelvis/Bip01 Spine/Bip01 Spine1/Bip01 Neck/Bip01 R Clavicle/Bip01 R UpperArm/Bip01 R Forearm/Bip01 R Hand/Bone01_wuqi/right";
                break;

            case "MasterSoldierPre":
                str = "Bip01/Bip01 Pelvis/Bip01 Spine/Bip01 Spine1/Bip01 Neck/Bip01 R Clavicle/Bip01 R UpperArm/Bip01 R Forearm/Bip01 R Hand/Bone01/Bone06/right";
                break;

            /**
             * A_JS_RenLei_A_001
             * 
             * AxeSoldierPre
             * 
             * GaylenPre 
             * 
             * MasterSoldierPre 
             *              
             */
        }

        return str;
    }

    /// <summary>
    /// 播放动作
    /// </summary>
    public void play()
    {
        //string effectName = _skillData.Effect.
        _skillLogic.skillLogic( this );
    }



}

