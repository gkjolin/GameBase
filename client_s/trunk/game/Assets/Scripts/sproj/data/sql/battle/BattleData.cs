
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 战场逻辑数据
/// @author MXL
/// @date 2015-07
/// </summary>
public class BattleData
{
   
    /// <summary>
    /// 编队信息
    /// </summary>
    private List<FormationData> _formationList;

    public List<FormationData> FormationList { get { return _formationList; } }

    /// <summary>
    /// 战场数据
    /// </summary>
    private BattleAgent _battle;

    /// <summary>
    /// battleID：战场ID
    /// formationIdx：编队ID
    /// </summary>
    /// <param name="battleID"></param>
    /// <param name="formationIdx"></param>
    public BattleData( int battleID, int formationIdx )
    {
        _battle  = new BattleAgent();

        _battle.setData(battleID);

        // 编队的容器
        _formationList = new List<FormationData>();

        addAllFormation(formationIdx);
    }

    /// <summary>
    /// 兵种结构， 和阵型数据
    /// idx ： 编队ID
    /// </summary>
    /// <param name="idx"></param>
    private void addAllFormation( int idx )
    {

        FormationAgent formation = new FormationAgent();

        // 设置对应的数据
        formation.setData(_battle.getFormation()[idx]);

        int[] soildArray; // 保存兵种结构

        if (idx == (int)Defaults.ResultNum.Zero) ///第一个战场
        {
            soildArray = (int[])_battle.getOneStruct().Clone();
        }
        else
        {
            soildArray = (int[])_battle.getTwoStruct().Clone();
        }

        /// 获取阵型
        int[] shapeArray = formation.getShapeArray();

        //  这里需要注意下 兵种结构 的个数 和 阵型的个数 是一致的

        for (int i = 0; i < soildArray.Length; i++)
        {
            // 记录当前的 位置
            float[] pos = { formation.getPosXArray()[i], formation.getPosYArray()[i], formation.getPosZArray()[i] };

            // 兵种ID  兵种阵型ID  位置信息
            FormationData mation = new FormationData(soildArray[i], shapeArray[i], pos, false);

            _formationList.Add(mation);
        }
    }

    /// <summary>
    /// 清除编队容器
    /// </summary>
    public void clearFormationDict()
    {
        if (_formationList.Count > 0)
        {
            _formationList.Clear();
        }

    }


    /// <summary>
    /// 获取第一个战场的位置
    /// </summary>
    /// <returns></returns>
    public float [] getOnePos()
    {
        return _battle.getOnePos();
    }


    /// <summary>
    ///  获取第二个战场的位置
    /// </summary>
    /// <returns></returns>
    public float [] getTwoPos()
    {
        return _battle.getTwoPos();
    }
    
}
