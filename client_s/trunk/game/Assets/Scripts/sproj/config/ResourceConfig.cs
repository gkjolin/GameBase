using System;
using System.Collections.Generic;


/// <summary>
/// 资源文件名预设
/// </summary>
public class ResourceConfig {

    /// <summary>
    /// 士兵与预设件
    /// </summary>
    private static Dictionary<Defaults.SoldierType, string> _soldierPrefabs = new Dictionary<Defaults.SoldierType, string>()
    { 
        //剑兵
        {Defaults.SoldierType.Swordman, "a_zs_al_001"},
        //斧兵
        {Defaults.SoldierType.Axeman, "a_zs_ls_001"},
        //骑士 -- 英雄
        {Defaults.SoldierType.Cavalryman, "h_qs_xxx_001"},
        //法师
        {Defaults.SoldierType.Masterman, "h_fs_dws_001"},
        //铁甲兵————暂时只有4个兵种
        {Defaults.SoldierType.Armorman, "a_zs_al_001"}
    };


    /// <summary>
    /// 士兵与脚本
    /// </summary>
    private static Dictionary<Defaults.SoldierType, Type> _soldierScripts = new Dictionary<Defaults.SoldierType, Type>()
    {
        //剑兵
        {Defaults.SoldierType.Swordman, typeof(IronSoldier)},
        //斧兵
        {Defaults.SoldierType.Axeman, typeof(AxeSoldier)},
        //骑士
        {Defaults.SoldierType.Cavalryman, typeof(Gaylen)},
        //法师
        {Defaults.SoldierType.Masterman, typeof(MasterSoldier)},
        //铁甲兵
        {Defaults.SoldierType.Armorman, typeof(AxeSoldier)},
    };


    /// <summary>
    /// 根据兵种，取得预制件的名字
    /// </summary>
    /// <param name="soldierType_"></param>
    /// <returns></returns>
    public static string getPrefabName(Defaults.SoldierType soldierType)
    {
        if (_soldierPrefabs.ContainsKey(soldierType))
        {
            return _soldierPrefabs[soldierType];
        }
        return null;
    }


    /// <summary>
    /// 根据兵种，取得对应的类的type
    /// </summary>
    /// <param name="soldierScript"></param>
    /// <returns></returns>
    public static System.Type getClassType(Defaults.SoldierType soldierScript)
    {
        if (_soldierScripts.ContainsKey(soldierScript))
        {
            return _soldierScripts[soldierScript];
        }
        return null;
    }
}
