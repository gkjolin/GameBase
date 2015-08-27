
using System;
using System.Collections.Generic;
/// <summary>
/// 伤害性类型技能
/// </summary>
using UnityEngine;
public class DamageInstance : SkillLogic
{
    public override bool skillLogic(Skill skill)
    {
        GameObject effect = null;

        // 获取对应的技能对应 特效文件名
        string key = skill.Data.Effect[skill.skillId].getEffectName();

        bool hasEffect = EffectsManager.getInstance().hasEffect(key);

        if (hasEffect)
        {
            effect = EffectsManager.getInstance().get(key).pickObj().Value;
        }
        else
        {
            throw new Exception("未找到技能所需特效：" + key);
        }

        //播放特效
        if (effect != null && skill.Sold._data.AttackTarget != null)
        {
            //effect.transform.position = skill.Sold._data.AttackTarget.transform.position;

            //effect.transform.position = skill.Sold.transform.GetChild("")
            //if (skill.Sold._data.AttackTarget == null)  //放到自身的特效
            //{
                effect.transform.position = skill.Sold.transform.FindChild(skill.mountPoint).position;
            //}
            //else // 伤害对方
            //{
            //    effect.transform.position = skill.Sold._data.AttackTarget.transform.position;
            //}
            

            effect.SetActive(true);
        }


        return true;
    }
}
