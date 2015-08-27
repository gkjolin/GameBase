using UnityEngine;
using System.Collections.Generic;

using XingLuoTianXia.lib;

/**
 * 场景数据 {UI 管理器, 数据管理器} * 
 */

public class Scenario : DataBase
{
    /// <summary>
    /// 记录场景ID
    /// </summary>
    public int scenearioId = 0;

    /// <summary>
    /// 场景的名字（看需求）
    /// </summary>
    public string sceneariodName = "";
    
    // UI 信息容器
    private Dictionary<int, SceneariodUI> _uiDict      = new  Dictionary<int, SceneariodUI>();

    // 场景临时数据管理器
    private Dictionary<int, ModuleData> _moduleDataDict = new Dictionary<int, ModuleData>(); 


    /// <summary>
    /// 添加UI 到容器中
    /// </summary>
    public void addSceneariod(SceneariodUI sceneariod)
    {
        // 同一个 id 只能添加一次
        if (_uiDict.ContainsKey(sceneariod.uiId))
        {
            return;
        }

        _uiDict.Add(sceneariod.uiId, sceneariod);
    }

   /// <summary>
   ///  通过ID 获取 对应的 ui对象
   /// </summary>
    public SceneariodUI getSceneariod(int uid)

    {
        if (_uiDict.ContainsKey(uid))
        {
            return _uiDict[uid];
        }

        return new SceneariodUI();
    }

    /// <summary>
    ///  删除指定的 ui 对象
    /// </summary>
    /// <param name="uid"></param>
    public void removeSceneariod(int uid)
    {
        if (_uiDict.ContainsKey(uid))
        {
            _uiDict.Remove(uid);
        }

    }

    /// <summary>
    /// 添加模块数据
    /// </summary>
    /// <param name="moduleData"></param>
    public void addModuleData(ModuleData moduleData)
    {
        if (_moduleDataDict.ContainsKey(moduleData.moduleId))
        {
            return;
        }
        _moduleDataDict.Add(moduleData.moduleId, moduleData);
    }

    /// <summary>
    /// 通过 指定数据
    /// </summary>
    /// <param name="mid"></param>
    /// <returns></returns>
    public ModuleData getModuleData(int mid)
    {
        if (_moduleDataDict.ContainsKey(mid))
        {
            return _moduleDataDict[mid];
        }

        return null;
    }

    /// <summary>
    /// 删除指定的数据
    /// </summary>
    /// <param name="moduleId"></param>
    public void removeModule(int mid)
    {
        if (_moduleDataDict.ContainsKey(mid))
        {
            _moduleDataDict.Remove(mid);
        }
    }

    /// <summary>
    /// 清空 ui/data dict
    /// </summary>
    public void cleanDict(int flag)
    {
        if (flag == 1)
        {
            if (_uiDict.Count > 0)
            {
                _uiDict.Clear();
            }
        }
        else
        {
            if (_moduleDataDict.Count > 0)
            {
                _moduleDataDict.Clear();
            }
        }

    }

}


