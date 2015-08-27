using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 地图/战役数据
/// @author MXL
/// @date 2015-07
/// </summary>
public class CampaignData
{
// ----------------------------------------历史数据 --------------------------------------------------------------------

    /// <summary>
    /// 战役ID
    /// </summary>

    public int campaignId = 0;

    /// <summary>
    ///  战役状态（是否开启）
    /// </summary>
    public bool campState = false;
    
    /// <summary>
    /// 战役描述信息
    /// </summary>
    public string capaignMessage = "";

    /// <summary>
    /// 战场的总数
    /// </summary>
    public int battleNumber = 0;
    /// <summary>
    /// 当前战场的index
    /// </summary> 
    public int battleIndex = 0;

    /// <summary>
    /// 战场容器  -- 历史代码
    /// </summary>

    public Dictionary<int, FormationData> battles;

// ----------------------------------------历史数据 --------------------------------------------------------------------

    /// <summary>
    /// 战场容器
    /// </summary>
    //private Dictionary<int, BattleData> _battleDict = new Dictionary<int,BattleData>();
    private List<BattleData> _battleList;

    public List<BattleData> BattleList { get { return _battleList; } }

    // 获取数据代理
    private CheckPointAgent _checkPoint;    
    
    /// <summary>
    /// 战役ID
    /// </summary>
    /// <param name="id"></param>
    public CampaignData(int id)
    {
        // 战场容器
        _battleList = new List<BattleData>();
        // 数据代理
        _checkPoint  = new CheckPointAgent();

        // 设置对应的数据
        _checkPoint.setData(id);

        // 将战场数据添加进去
        addAllBattle();

    }

    /// <summary>
    /// 获取战役名字 
    /// </summary>
    /// <returns></returns>
    public string getName()
    {
        return _checkPoint.getName();
    }

    /// <summary>
    /// 获取对应的 icon
    /// </summary>
    /// <returns></returns> 
    public string getIcon()
    {
        return _checkPoint.getIcon();
    }

    /// <summary>
    ///  获取描述
    /// </summary>
    /// <returns></returns>
    public string getDescribe()
    {
        return _checkPoint.getDescribe();
    }

    
    /// <summary>
    ///  获取当前ID / 所属地图ID
    /// </summary>
    /// <returns></returns>
    public int getMapID()
    {
        return _checkPoint.getMapID();
    }


    /// <summary>
    ///  推荐的战斗力
    /// </summary>
    /// <returns></returns>
    public int getCombat()
    {
        return _checkPoint.getCombat();
    }

    /// <summary>
    ///  消耗类型
    /// </summary>
    /// <returns></returns>
    public byte getConsume()
    {
        return _checkPoint.getConsume();
    }

    /// <summary>
    /// 上限次数
    /// </summary>
    /// <returns></returns> 
    public byte getCeiling()
    {
        return _checkPoint.getCeilling();
    }

    /// <summary>
    /// 胜利消耗
    /// </summary>
    /// <returns></returns>
    public int getWinConsume()
    {
        return _checkPoint.getWinConsume();
    }

    /// <summary>
    /// 失败消耗
    /// </summary>
    /// <returns></returns>
    public int getFailureConsume()
    {
        return _checkPoint.getFailureConsume();
    }


    /// <summary>
    /// 英雄经验
    /// </summary>
    /// <returns></returns>
    public int getHeroExperience()
    {
        return _checkPoint.getHeroExp();
    }

    /// <summary>
    /// 获取金币
    /// </summary>
    /// <returns></returns>
    public int getGold()
    {
        return _checkPoint.getGold();
    }


    //添加所有战场
    private void addAllBattle()
    {
        /// 获取战场ID
        int battleId = _checkPoint.getBattleId();

        // _checkPoint.getBattleNumber()  战场个数 == 编队个数
        for (int i = 0; i < _checkPoint.getBattleNumber(); i++)
        {

            BattleData battle = new BattleData( battleId, i );

            if (!_battleList.Contains(battle))
            {
                _battleList.Add(battle);
            }
            else
            {
                _battleList[i] = battle;
            }
        }

    }

    /// <summary>
    /// 清除所有的战场数据
    /// </summary>
    private void clearBattle()
    {
        if ( _battleList.Count > 0)
        {
            _battleList.Clear();
        }
    }



}
