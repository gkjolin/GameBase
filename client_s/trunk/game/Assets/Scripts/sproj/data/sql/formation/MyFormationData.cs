using UnityEngine;
using System.Collections.Generic;


/// <summary>
/// 己方编队的数据类
/// @author MXL
/// @date 2015-07
/// </summary>
class MyFormationData
{
    /// <summary>
    /// 单例
    /// </summary>
    private static MyFormationData _instance = null;


    //默认 士兵结构
    private int[] soldierStruct = { 1, 2, 3, 4, 5, 6, 7 };

    private BattleAgent _battle;

    /// <summary>
    /// 保存所有阵型  线性排列
    /// </summary>
    public static List<FormationData> formationList;

    /// <summary>
    /// 单例
    /// </summary> 
    /// <returns></returns>
    public static MyFormationData getInstance()
    {
        if (_instance == null)
        {
            _instance = new MyFormationData();
        }
        return _instance;
    }


    /// <summary>
    /// 将阵容上 6个位置上的英雄ID 传过来 null 表示没有人 占位用的
    /// </summary>
    /// <param name="idArray"></param>
    private MyFormationData()
    {
        // 初始化 自己阵容list
        formationList = new List<FormationData>();

        // 阵型， pos  等信息
        FormationAgent foramtion = new FormationAgent();
        foramtion.setData((int)Defaults.ResultNum.One);  // 目前 1 formation 表中 1 是自己的队伍信息

        // 兵种结构
        _battle = new BattleAgent();
        _battle.setData((int)Defaults.ResultNum.One); // 目前 1 battle 表中 1 是自己的队伍信息

        setData(foramtion, _battle);
    }

    // 设置数据
    private void setData(FormationAgent formation, BattleAgent battle)
    {

        setAllData(soldierStruct, formation.getShapeArray(), formation.getPosXArray(), formation.getPosYArray(), formation.getPosZArray());
    }

    // 重载方法  // 兵种结构， 阵型  pos信息，是否是自己  -- 提供外部设计数据
    public void setData(int[] soldierArray, int[] shapeIdArray, float[] posXArray, float[] posYArray, float[] posZArray)
    {
        setAllData(soldierArray, shapeIdArray, posXArray, posYArray, posZArray);
    }


    // 兵种结构， 阵型  pos信息，是否是自己  -- 最终实现
    private void setAllData(int[] soldierArray, int[] shapeIdArray, float[] posXArray, float[] posYArray, float[] posZArray)
    {
        formationList.Clear();

        for (int i = 0; i < soldierArray.Length; ++i)
        {
            // 组织pos信息
            float[] pos = { posXArray[i], posYArray[i], posZArray[i] };

            FormationData mation = new FormationData(soldierArray[i], shapeIdArray[i], pos, true);

            formationList.Add(mation);
        }

    }


    // 第一场坐标
    public float [] getOneSelfPos()
    {
        return _battle.getOneSelfPos();
    }

    // 集合坐标
    public float[] getSelfCollection()
    {
        return _battle.getOneSelfCollection();
    }

    //  第二场坐标
    public float[] getOneSelfTwoPos()
    {
        return _battle.getOneSelfTwoPos();
    }

}
