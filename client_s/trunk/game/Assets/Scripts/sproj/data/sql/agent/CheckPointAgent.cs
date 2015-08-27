
using System.Collections.Generic;

/// <summary>
/// 战役
/// @author MXL
/// @date 2015-06
/// </summary>
class CheckPointAgent
{
    private CheckPointVO _checkPoint;

    /// <summary>
    /// 战场个数
    /// </summary>
    private const int _battleNumber = 2;

    public CheckPointAgent()
    {
       
    }

    /// <summary>
    /// 对外设置对应的数据
    /// </summary>
    /// <param name="id"></param>
    public void setData(int id)
    {
        IList<CheckPointVO> list = DataMgr.getInstance().CheckPoint;

        for (int i = 0; i < list.Count; ++i)
        {
            if (list[i].ID == id)
            {
                _checkPoint = list[i];
            }
        }
    }

    /// <summary>
    /// 获取名字
    /// </summary>
    /// <returns></returns> 
    public string getName()
    {        
       return _checkPoint.Name;
    }

    /// <summary>
    /// 获取描述数据 
    /// </summary>
    /// <returns></returns>
    public string getDescribe()
    {
        return _checkPoint.Describe;       
    }

    /// <summary>
    ///  获取icon
    /// </summary>
    /// <returns></returns>
    public string getIcon()
    {
        return _checkPoint.Icon;
    }

    /// <summary>
    ///  获取大地图的ID
    /// </summary>
    /// <returns></returns>
    public int getMapID()
    {
        return _checkPoint.MapID;        
    }

    /// <summary>
    /// 获取当前地图的名字
    /// </summary>
    /// <returns></returns>
    public string getMapName()
    {
        return _checkPoint.MapName;
    }

    /// <summary>
    /// 获取地图简介
    /// </summary>
    /// <returns></returns>
    public string getMapDescribe()
    {
        return _checkPoint.MapDescribe;
    }

    /// <summary>
    /// 获取地图是否开启
    /// </summary>
    /// <returns></returns>
    public int getMapIsOpen()
    {
        return _checkPoint.MapIsOpen;
    }


    /// <summary>
    /// 获取当前是否默认开启
    /// </summary>
    /// <returns></returns>
    public byte getIsOpen()
    {
        return _checkPoint.IsOpen;        
    }

    /// <summary>
    /// 获取推荐战斗力
    /// </summary>
    /// <returns></returns>
    public int getCombat()
    {
        return _checkPoint.Recommend;        
    }

    /// <summary>
    ///  消耗类型
    /// </summary>
    /// <returns></returns>
    public byte getConsume()
    {
        return _checkPoint.ConsumeType;       
    }

    /// <summary>
    /// 上限次数
    /// </summary>
    /// <returns></returns>
    public byte getCeilling()
    {      
        return _checkPoint.Ceiling;
    }

    /// <summary>
    /// 胜利消耗
    /// </summary>
    /// <returns></returns>
    public int getWinConsume()
    {
        return _checkPoint.WinConsume;        
    }

    /// <summary>
    /// 失败消耗
    /// </summary>
    /// <returns></returns>
    public int getFailureConsume()
    {
        return _checkPoint.FailureConsume;        
    }

    /// <summary>
    /// 英雄经验
    /// </summary>
    /// <returns></returns>
    public int getHeroExp()
    {      
        return _checkPoint.Experience;
    }

    /// <summary>
    /// 金币数量
    /// </summary>
    /// <returns></returns>
    public int getGold()
    {
        return _checkPoint.Gold;       
    }

    /// <summary>
    ///  战场ID
    /// </summary>
    /// <returns></returns>
    public int getBattleId()
    {
        return _checkPoint.BattleId;
    }

    /// <summary>
    /// 获取战场个数
    /// </summary>
    /// <returns></returns>
    public int getBattleNumber()
    {
        return _battleNumber;
    }
}

