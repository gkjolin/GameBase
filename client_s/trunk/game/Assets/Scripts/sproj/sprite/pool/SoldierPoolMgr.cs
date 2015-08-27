using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using XingLuoTianXia.lib;

/// <summary>
/// 士兵池管理器
/// @author CJC
/// @date 2015-0423
/// </summary>
public class SoldierPoolMgr {
    /// <summary>
    /// 单例对象
    /// </summary>
    private static SoldierPoolMgr g_instance = null;

    /// <summary>
    /// 空闲弓箭手池
    /// </summary>
    private BowmanPool _freeBowmanPool = new BowmanPool();
    public BowmanPool FreeBowmanPool
    {
        get { return _freeBowmanPool; }
        set { _freeBowmanPool = value; }
    }

    /// <summary>
    /// 空闲剑士池
    /// </summary>
    private SwordmanPool _freeSwordmanPool = new SwordmanPool();
    public SwordmanPool FreeSwordmanPool
    {
        get { return _freeSwordmanPool; }
        set { _freeSwordmanPool = value; }
    }

    /// <summary>
    /// 空闲骑士池
    /// </summary>
    private CavalrymanPool _freeCavalrymanPool = new CavalrymanPool();
    public CavalrymanPool FreeCavalrymanPool
    {
        get { return _freeCavalrymanPool; }
        set { _freeCavalrymanPool = value; }
    }

    /// <summary>
    /// 获取士兵池管理器的单例对象
    /// </summary>
    /// <returns>SoldierMgr</returns>
    public static SoldierPoolMgr getInstance()
    {
        if (g_instance == null)
        {
            g_instance = new SoldierPoolMgr();
        }
        return g_instance;
    }

    /// <summary>
    /// 初始化所有士兵池
    /// </summary>
    public void init()
    {
        int size = 8;
        //_freeBowmanPool.init(size);
        //_freeSwordmanPool.init(size);
        //_freeCavalrymanPool.init(size);
    }



    /// <summary>
    /// 添加一个士兵
    /// </summary>
    /// <param name="soldierType">士兵类型</param>
    /// <returns>Soldier</returns>
    //public Soldier createSoldier(Defaults.SoldierType type)
    public void createSoldier(Defaults.SoldierType type)
    {
        //取得预制件名
        string prefab = ResourceConfig.getPrefabName(type);

        //实例化预制件
        GameObject gameObj = ResourceManager.getInstance().getGameObject(prefab);

        //缩放
        // gameObj.transform.localScale = new Vector3(Defaults.SOLDIER_SCALE, Defaults.SOLDIER_SCALE, Defaults.SOLDIER_SCALE);

        //绑定脚本
        //UnityEngineInternal.APIUpdaterRuntimeServices.AddComponent(gameObj, "add cs to soldier", ScriptsList.getScript(type));

        //取得脚本
        //Soldier script = (Soldier)gameObj.GetComponent(ScriptsList.getScript(type));
        //script.Type = type;
        //return script;

        return;
    }



    /// <summary>
    /// 根据类型获取空闲的士兵
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    //public Soldier getFreeSoldier(Defaults.SoldierType type)
    public void getFreeSoldier(Defaults.SoldierType type)
    {
        if (type == Defaults.SoldierType.Bowman)
        {
            //return _freeBowmanPool.getFreeChild();
        }

        if (type == Defaults.SoldierType.Cavalryman)
        {
            //return _freeCavalrymanPool.getFreeChild();
        }

        if (type == Defaults.SoldierType.Swordman)
        {
            //return _freeSwordmanPool.getFreeChild();
        }

        //return null;
        return;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="soldier"></param>
    /// <returns></returns>
    //public bool add(Soldier soldier){
    //    if(soldier == null){
    //        return false;
    //    }

    //    soldier.gameObject.SetActive(false);

    //    // 对象池
    //    if (soldier.Type == Defaults.SoldierType.Bowman)
    //    {
    //        return _freeBowmanPool.add((Bowman)soldier);
    //    }
        
    //    if (soldier.Type == Defaults.SoldierType.Cavalryman)
    //    {
    //        return _freeCavalrymanPool.add((Cavalryman)soldier);
    //    }
        
    //    if (soldier.Type == Defaults.SoldierType.Swordman)
    //    {
    //        return _freeSwordmanPool.add((Swordman)soldier);
    //    }

    //    return false;
    //}

    //public bool add(List<Soldier> soldiers)
    //{
    //    if (soldiers == null)
    //    {
    //        return false;
    //    }

    //    foreach (Soldier s in soldiers)
    //    {
    //        if (!add(s))
    //        {
    //            return false;
    //        }
    //    }

    //    soldiers.Clear();
    //    return true;
    //}
}
