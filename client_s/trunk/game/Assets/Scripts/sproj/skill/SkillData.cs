
/// /// <summary>
/// 技能数据组织
/// @author MXL
/// @date 2015-07
/// </summary>
using System.Collections.Generic;
public class SkillData
{

    /// <summary>
    /// 特效数据
    /// </summary>
    private Dictionary<int, EffectAngent> _effectDict = new Dictionary<int,EffectAngent>();

    /// <summary>
    /// 
    /// </summary>
    private Dictionary<int, BuffAgent> _buff = new Dictionary<int,BuffAgent>();



    /// <summary>
    ///  技能数据代理
    /// </summary>
    private SkillAgent _agent = new SkillAgent();


    public SkillData(int skillId)
    {     

        _agent.setData(skillId);

        effectAndBuffData();

    }

    /// <summary>
    /// 获取技能对应的特效 及buff数据
    /// </summary>
    protected void effectAndBuffData()
    {
        // 获取特效数据
        EffectAngent effect = new EffectAngent();

        effect.setData(_agent.getEffectID());

        _effectDict.Add(_agent.getID(), effect);


        // 获取buff
        BuffAgent buffAge = new BuffAgent();
        buffAge.setData(_agent.getBuffID());
        _buff.Add(_agent.getID(), buffAge);
    }

    /// <summary>
    /// 当前技能描述
    /// </summary>
    public SkillAgent Skill { get { return _agent; } }
    /// <summary>
    /// 技能需要的特效数据
    /// </summary>
    public Dictionary<int, EffectAngent> Effect { get { return _effectDict; } }
    /// <summary>
    /// 技能需要的buff数据
    /// </summary>
    public Dictionary<int, BuffAgent> Buff { get { return _buff; } }


}

