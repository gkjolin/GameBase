using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 特效池管理
/// @author MXL
/// @date 2015-07
/// </summary>
public class SkillsManager
{
    /// <summary>
    /// 保存技能数据描述
    /// </summary>
    private Dictionary<int, Skill> _skillList = new Dictionary<int, Skill>();
    
    /// <summary>
    ///  eman -- 释放者对象
    ///  skillList -- 技能id列表
    /// </summary>
    /// <param name="eman"></param>    
    public void setSkills(GeneralSoldier eman)
    {
        if (eman._data.Skills == null)
        {
            return;
        }

        for (int i = 0; i < eman._data.Skills.Length; ++i)
        {
            Skill skill = new Skill(eman, eman._data.Skills[i]);

            // 保存技能
            if (eman._data.Skills[i] != 0 && !_skillList.ContainsKey(eman._data.Skills[i]))
            {
                _skillList.Add(eman._data.Skills[i], skill);
            }
        }
        
    }

    /// <summary>
    /// 通过ID 播放技能
    /// </summary>
    public void play(int skillId)
    {
         _skillList[skillId].play(); 
    }


    
}
