
using System.Collections.Generic;

/// <summary>
/// buff属性
/// @author MXL
/// @date 2015-06
/// </summary>
public class BuffRuleAgent
{
    private BuffRuleV0 _buffRule;

    public BuffRuleAgent()
    {
 
    }

    /// <summary>
    /// 对应的规则
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public void setData(int id)
    {
        IList<BuffRuleV0> list = DataMgr.getInstance().BuffRule;

        for (int i = 0; i < list.Count; ++i)
        {
            if (list[i].ID == id)
            {
                _buffRule = list[i];
            }
        } 
    }

    /// <summary>
    /// 获取优先级
    /// （1 - 10 ） 1 为最高
    /// </summary>
    /// <returns></returns>
    public byte getPriority()
    {
        return _buffRule.Priority;
    }
}
