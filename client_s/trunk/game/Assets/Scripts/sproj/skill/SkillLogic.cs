
using UnityEngine;
/// /// <summary>
/// 技能逻辑处理基类
/// @author MXL
/// @date 2015-07
/// </summary>
public  abstract class SkillLogic
{
    /// <summary>
    /// 子类重写 技能逻辑
    /// soldier：绑定对象
    /// skill： 需要的数据
    /// </summary>
    /// <returns></returns>
    public abstract bool skillLogic(Skill skill);
    
}

