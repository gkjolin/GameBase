
using System.Collections.Generic;

/// <summary>
/// 兵种结构
/// @author MXL
/// @date 2015-07
/// </summary>
class SoldiersCollocationAgent
{
    private SoldiersCollocationVO _sg;

    public void setData(int id)
    {
        IList<SoldiersCollocationVO> list = DataMgr.getInstance().SoldiersCollocation;

        for (int i = 0; i < list.Count; ++i)
        {
            if (list[i].ID == id)
            {
                _sg = list[i];
            }
        }
    }

    /// <summary>
    /// 结构数组
    /// </summary>
    /// <returns></returns>
    public int[] getSoldies()
    {
        return _sg.Soldiers;
    }

}