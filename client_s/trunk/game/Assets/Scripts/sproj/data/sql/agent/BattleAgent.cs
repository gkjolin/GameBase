using System.Collections.Generic;

/// <summary>
/// 战场数据
/// @author MXL
/// @date 2015-05
/// </summary>
public class BattleAgent
{
    private BattleVO _battle;

    /// <summary>
    /// 通过数据ID 确定具体条目
    /// </summary>
    /// <param name="id"></param>
    public void setData(int id)
    {
        IList<BattleVO> list = DataMgr.getInstance().Battle;

        for (int i = 0; i < list.Count; ++i)
        {
            if (list[i].ID == id)
            {
                _battle = list[i];
            }
        }
    }



    /// <summary>
    /// 第一个战场的位置
    /// </summary>
    /// <returns></returns>
    public float[] getOnePos()
    {
        return _battle.OnePos;
    }

    /// <summary>
    /// 第一个战场的兵种结构
    /// </summary>
    /// <returns></returns>
    public int[] getOneStruct()
    {
        return _battle.OneStruct;
    }

    /// <summary>
    /// 第二个战场坐标
    /// </summary>
    /// <returns></returns>
    public float[] getTwoPos()
    {
        return _battle.TwoPos;
    }


    /// <summary>
    /// 第二个战场的兵种结构
    /// </summary>
    /// <returns></returns>
    public int[] getTwoStruct()
    {
        return _battle.TwoStruct;
    }

    /// <summary>
    /// 获取编队ID
    /// </summary>
    /// <returns></returns>
    public int [] getFormation()
    {
        return _battle.FormationID; 
    }


    //-------------------------------------- 己方 pos 信息 --------------------------------------

    /// <summary>
    /// 己方初始坐标
    /// </summary>
    /// <returns></returns>
    public float[] getOneSelfPos()
    {
        return _battle.OneSelfPos;
    }


    /// <summary>
    /// 己方集合坐标
    /// </summary>
    /// <returns></returns>
    public float[] getOneSelfCollection()
    {
        return _battle.OneSelfCollection;
    }

    /// <summary>
    /// 己方战场第二场坐标
    /// </summary>
    /// <returns></returns>
    public float[] getOneSelfTwoPos()
    {
        return _battle.OneSelfTwoPos;
    }

    //-------------------------------------- 己方 pos 信息 --------------------------------------
} 