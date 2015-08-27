using UnityEngine;
using System.Collections.Generic;


/// 
/// <summary>
/// 特效池管理
/// @author MXL
/// @date 2015-07
/// </summary>

class EffectsManager
{
    /// <summary>
    /// 单例
    /// </summary>
    private static EffectsManager g_instance;

    /// <summary>
    /// key 特效名 , 特效对象池
    /// </summary>
    public static Dictionary<string, EffectPool> _effects;

    private EffectsManager()
    {
        _effects = new Dictionary<string, EffectPool>();
    }

    /// <summary>
    /// 获取单例
    /// </summary>
    /// <returns></returns>
    public static EffectsManager getInstance()
    {
        if (g_instance == null)
        {
            g_instance = new EffectsManager();
        }

        return g_instance;
    }

    /// <summary>
    /// 添加特效
    /// </summary>
    /// <returns></returns>
    public bool add(EffectPool obj)
    {
        if (_effects.ContainsKey(obj.getName()))
        {
            return false;
        }

        _effects.Add(obj.getName(), obj);

        return true;
    }




    /// <summary>
    /// 获得对应的特效
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public EffectPool get(string key)
    {
        if (_effects.ContainsKey(key))
        {
            return _effects[key];
        }

        return null;
    }

    /// <summary>
    /// 判断是否存在该元素
    /// </summary>
    /// <param name="effectName"></param>
    /// <returns></returns>
    public bool hasEffect(string effectName)
    {
        return _effects.ContainsKey(effectName);            
    }

}

