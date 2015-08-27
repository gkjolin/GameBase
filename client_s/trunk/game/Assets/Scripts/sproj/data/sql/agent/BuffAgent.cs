using System.Collections.Generic;
/// <summary>
/// buff数据
/// @author MXL
/// @date 2015-05
/// </summary>
public class BuffAgent
{

    private BuffsVO _buff;

    public BuffAgent()
    {
 
    }

    /// <summary>
    /// 通过数据ID 确定具体条目
    /// </summary>
    /// <param name="id"></param>
    public void setData(int id)
    {
        IList<BuffsVO> list = DataMgr.getInstance().Buffs;

        for (int i = 0; i < list.Count; ++i)
        {
            if (list[i].BuffID == id)
            {
                _buff = list[i];
            }
        }
    }


    /// <summary>
    /// 当前技能ID
    /// </summary>
    /// <returns></returns>
    public int getID()
    {
        return _buff.BuffID;
    }

    /// <summary>
    /// buff name
    /// </summary>
    /// <returns></returns>
    public string getName()
    {
        return _buff.BuffName;
    }

    /// <summary>
    /// 0 buff 1 debuff
    /// </summary>
    /// <returns></returns>
    public byte isBuff()
    {
        return _buff.IsBuff;
    }

    /// <summary>
    /// 0 减益  1 增益
    /// </summary>
    /// <returns></returns>
    public byte getBuffType()
    {
        return _buff.BuffType;
    }

    /// <summary>
    /// buff规则ID
    /// </summary>
    /// <returns></returns>
    public int getPriority()
    {
        return _buff.Priority;
    }

    /// <summary>
    /// icon 路径
    /// </summary>
    /// <returns></returns>
    public string getIcon()
    {
        return _buff.IconPath;
    }


    /// <summary>
    /// 生存时间
    /// </summary>
    /// <returns></returns>
    public float getLiveTime()
    {
        return _buff.LiveTime;
    }


    /// <summary>
    /// 效果时间间隔
    /// </summary>
    /// <returns></returns>
    public float getIntervalTime()
    {
        return _buff.IntervalTime;
    }

    /// <summary>
    /// 效果值
    /// </summary>
    /// <returns></returns>
    public float getValue()
    {
        return _buff.Values;
    }


    /// <summary>
    /// 属性ID
    /// </summary>
    /// <returns></returns>
    public int getPropertierID()
    {
        return _buff.PropertiesID;
    }


    /// <summary>
    /// 特效ID
    /// </summary>
    /// <returns></returns>
    public int getEffectID()
    {
        return _buff.EffectID;
    }


    /// <summary>
    /// 挂载点
    /// 0:None,
    /// 1:Head,
    /// 2:Center,
    /// 3:Foot,
    /// 4:Left Hand,
    /// 5:Right Hand
    /// </summary>
    /// <returns></returns>
    public byte getBindType()
    {
        return _buff.BindType;
    }


    /// <summary>
    /// 特效生存时间
    /// </summary>
    /// <returns></returns>
    public float getEffectLiveTime()
    {
        return _buff.EffectLiveTime;
    }
}
