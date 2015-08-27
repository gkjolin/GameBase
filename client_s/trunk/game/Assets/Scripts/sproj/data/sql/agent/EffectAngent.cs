using System.Collections.Generic;

/// <summary>
/// 特效
/// @author MXL
/// @date 2015-06
/// </summary>
public class EffectAngent
{

    private EffectsVO _effect;

    public EffectAngent()
    {
 
    }

    /// <summary>
    /// 对外设置对应的数据
    /// </summary>
    /// <param name="id"></param>
    public void setData(int id)
    {
        IList<EffectsVO> list = DataMgr.getInstance().Effects;

        for (int i = 0; i < list.Count; ++i)
        {
            if (list[i].EffectId == id)
            {
                _effect =  list[i];
            }
        }

    }


    /// <summary>
    /// 特效名字
    /// </summary>
    /// <returns></returns>
    public string getEffectName()
    {
        return _effect.EffectName;
    }

    /// <summary>
    /// 获取当前特效ID
    /// </summary>
    /// <returns></returns>
    public int getID()
    {
        return _effect.EffectId;
    }


}
