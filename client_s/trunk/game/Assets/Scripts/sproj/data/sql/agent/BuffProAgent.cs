
using System;
using System.Collections.Generic;

/// <summary>
/// buff属性数据
/// @author MXL
/// @date 2015-05
/// </summary>
class BuffProAgent
{
    BuffPropertyVO _buffPro;
    public BuffProAgent()
    {
        
    }

    /// <summary>
    ///  通过id 获取数据
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public void setData(int id)
    {
        IList<BuffPropertyVO> list = DataMgr.getInstance().BuffPro;

        for (int i = 0; i < list.Count; ++i)
        {
            if (list[i].ID == id)
            {
                _buffPro =  list[i];
            }
        }
    }

    /// <summary>
    /// 属性值
    ///0:HP,
    ///1:Physical atk, 
    ///2:Physical def,
    ///3:Attack speed,
    ///4:Move speed,
    ///5:Magic atk,
    ///6:Magic def 
    /// </summary>
    /// <returns></returns>
    public byte getProperty()
    {
        return _buffPro.Property;
    }
}

