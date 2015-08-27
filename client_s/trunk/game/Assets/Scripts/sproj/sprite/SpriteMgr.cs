using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using XingLuoTianXia.lib;

/// <summary>
/// 精灵管理器
/// CJC
/// </summary>
public class SpriteMgr {
    /// <summary>
    /// 单例对象
    /// </summary>
    private static SpriteMgr g_instance;

    /// <summary>
    /// 事件ID计数器
    /// </summary>
    private XLCounter _eventCount = new XLCounter(10000);
    public int EventID
    {
        get { return _eventCount.getNext(); }
    }

    /// <summary>
    /// 玩家活着的所有士兵的容器(get/set)
    /// </summary>
    protected List<XLSpriteBase> _selfSoldiers = new List<XLSpriteBase>();
    public List<XLSpriteBase> SelfSoldiers
    {
        get { return _selfSoldiers; }
    }

    /// <summary>
    /// 敌人活着的所有士兵的容器(get/set)
    /// </summary>
    protected List<XLSpriteBase> _enemySoldiers = new List<XLSpriteBase>();
    public List<XLSpriteBase> EnemySoldiers
    {
        get { return _enemySoldiers; }
    }

    public static SpriteMgr getInstance()
    {
        if (g_instance == null)
        {
            g_instance = new SpriteMgr();
        }

        return g_instance;
    }


    /// <summary>
    /// 受击
    /// </summary>
    /// <param name="soldier"></param>
    /// <returns>是否死亡</returns>
    public bool hit(GeneralSoldier soldier)
    {
        GeneralSoldier attackTarget = (GeneralSoldier)soldier._data.AttackTarget;

        if (attackTarget == null)
        {
            return true;
        }

        bool isDead = attackTarget.hurt(soldier._data.PhysicalStrength);

        if (isDead)
        {
            removeSoldier(attackTarget);

            if (_selfSoldiers.Count == 0)
            {
                //发战斗失败消息
                XLMessageManager.getInstance().sendNotification(BattleController.BATTLESTATE_FAILED);
            }

            if(_enemySoldiers.Count == 0)
            {
                //发战斗胜利消息
                XLMessageManager.getInstance().sendNotification(BattleController.BATTLESTATE_VICTORY);
            }

        }

        return isDead;
    }

    /// <summary>
    /// 移除一个士兵
    /// </summary>
    /// <param name="soldier"></param>
    /// <returns></returns>
    public void removeSoldier(XLSpriteBase soldier)
    {
        if (soldier == null)
        {
            return;
        }

        if (soldier._data.Country == Defaults.Country.Enemy)
        {
            if (_enemySoldiers.Contains(soldier))
            {
                _enemySoldiers.Remove(soldier);
            }
            return;
        }

        bool isSelf = (soldier.Country == Defaults.Country.Me || soldier.Country == Defaults.Country.Friend);
        if (isSelf)
        {
            if (_selfSoldiers.Contains(soldier))
            {
                _selfSoldiers.Remove(soldier);
            }
        }
    }

    public void addSoldier(XLSpriteBase soldier)
    {
        if (soldier == null)
        {
            return;
        }

        if (soldier._data.Country == Defaults.Country.Enemy)
        {
            if (!_enemySoldiers.Contains(soldier)) 
            {
                _enemySoldiers.Add(soldier);
            }
        }

        bool isSelf = (soldier.Country == Defaults.Country.Me || soldier.Country == Defaults.Country.Friend);
        if (isSelf)
        {
            if (!_selfSoldiers.Contains(soldier))
            {
                _selfSoldiers.Add(soldier);
            }
        }
    }

    private static int sprId = 0;

    /// <summary>
    /// 添加一个士兵——————测试用
    /// </summary>
    /// <param name="country"></param>
    /// <param name="x_"></param>
    /// <param name="y_"></param>
    public void addSoldier(SoldierDataBase data, Defaults.SoldierType soldierType, Vector3 point)
    {
        //复制预制件
        GameObject soldierBody = ResourceManager.getInstance().getGameObject(ResourceConfig.getPrefabName(soldierType));
        soldierBody.name = null;

        if (data == null)
        {
            return;
        }

        if (data.Country == Defaults.Country.Me)
        {
            soldierBody.name = "me" + sprId;
        }
        else
        {
            soldierBody.name = "enemy" + sprId;
        }
        sprId++;

        //如果取得预制件失败，返回
        if(soldierBody == null)
        {
            return;
        }

        //根据兵种实例化兵种类,绑定到预制件
        Type scriptType = ResourceConfig.getClassType(soldierType);
        soldierBody.AddComponent(scriptType);
        GeneralSoldier soldierScript = soldierBody.GetComponent(scriptType) as GeneralSoldier;
        //如果取得脚本失败，返回
        if (soldierScript == null)
        {
            return;
        }

        //设置属性
        soldierScript._data = data;//势力
        soldierScript._data.DeadDelay = 10;
        soldierScript._data.SkillMgr.setSkills(soldierScript);//技能
        int distance = data.Country == Defaults.Country.Me ? 14 : 26;//敌我距离
        soldierBody.transform.Rotate(0, data.Country == Defaults.Country.Me ? 0 : 180, 0);//设置敌我部队的朝向
        soldierBody.transform.position = point;//设置坐标

        //存进士兵容器
        if (data.Country == Defaults.Country.Enemy)
        {
            _enemySoldiers.Add(soldierScript);
        }
        else
        {
            _selfSoldiers.Add(soldierScript);
        }
    }

    /// <summary>
    /// 获得对手精灵集合
    /// </summary>
    /// <param name="coutry"></param>
    /// <returns></returns>
    public IList<XLSpriteBase> getMatchSprites(Defaults.Country coutry)
    {
        IList<XLSpriteBase> matchSprites = null;
        if (coutry == Defaults.Country.Enemy)
        {
            matchSprites = _selfSoldiers;
        }
        else if (coutry == Defaults.Country.Me || coutry == Defaults.Country.Friend)
        {
            matchSprites = _enemySoldiers;
        }
        return matchSprites;
    }

    /// <summary>
    /// 获取距离我最近的对手
    /// </summary>
    /// <param name="sprite"></param>
    /// <returns></returns>
    public XLSpriteBase getCloselyMatchSprite(XLSpriteBase sprite, XLSpriteBase ignoreSprite)
    {
        if (sprite == null)
        {
            return null;
        }

        List<XLSpriteBase> matchSprites = null;
        if (sprite.Country == Defaults.Country.Enemy)
        {
            matchSprites = _selfSoldiers;
        }
        else if (sprite.Country == Defaults.Country.Me || sprite.Country == Defaults.Country.Friend)
        {
            matchSprites = _enemySoldiers;
        }

        if (matchSprites == null)
        {
            return null;
        }

        XLSpriteBase ret = null;
        float retDistance = -1;
        for (int i = 0; i < matchSprites.Count; i++)
        {
            XLSpriteBase matchSprite = matchSprites[i];
            if (!matchSprite.isCanBeTarget())
            {
                continue;
            }

            // 如果对手就只有一个那就不用换目标了 && 更换目标
            if (matchSprites.Count > 1 && matchSprite == ignoreSprite)
            {
                continue;
            }

            float matchDistance = Vector3.Distance(sprite.transform.position, matchSprite.transform.position);
            if (ret == null || matchDistance < retDistance)
            {
                ret = matchSprite;
                retDistance = matchDistance;
                continue;
            }
        }

        return ret;
    }

    /// <summary>
    /// 获取距离我最近的对手
    /// </summary>
    /// <param name="sprite"></param>
    /// <returns></returns>
    public XLSpriteBase getCloselyMatchSprite1(XLSpriteBase sprite, XLSpriteBase ignoreSprite)
    {
        if (sprite == null)
        {
            return null;
        }

        List<XLSpriteBase> matchSprites = null;
        if (sprite.Country == Defaults.Country.Enemy)
        {
            matchSprites = _selfSoldiers;
        }
        else if(sprite.Country == Defaults.Country.Me || sprite.Country == Defaults.Country.Friend){
            matchSprites = _enemySoldiers;
        }

        if(matchSprites == null){
            return null;
        }

        XLSpriteBase ret = null;
        float retDistance = -1;

        List<float> distArray = new List<float>(matchSprites.Count);
        //float[] distArray = new float[matchSprites.Count]; 
        float maxDist = 100000f; 
        float totalHP = 0; 
        for (int i = 0; i < matchSprites.Count; i++)
        {
            XLSpriteBase matchSprite = matchSprites[i];
            if (!matchSprite.isCanBeTarget())
            {
                distArray.Add(maxDist);
                continue;
            }

            // 如果对手就只有一个那就不用换目标了 && 更换目标
            if (matchSprites.Count>1 && matchSprite == ignoreSprite)
            {
                distArray.Add(maxDist);
                continue;
            }

            float matchDistance = Vector3.Distance(sprite.transform.position, matchSprite.transform.position);
            distArray.Add(matchDistance);
            
            totalHP += matchSprite._data.HP;

        }


        // 对距离进行排序，然后在距离最短的几个里面找一个血量最小的攻击
        var sorted = distArray.Select((x, i) => new KeyValuePair<float, int>(x, i)).OrderBy(x => x.Key).ToList();
        List<float> sortedDistArray = sorted.Select(x => x.Key).ToList();
        List<int> idx = sorted.Select(x => x.Value).ToList();


        float minRatio = 1;
        //if (sprite._data.Country == Defaults.Country.Me)  // 只有我方士兵才适用这种寻敌方式
        if(true)    // 双方士兵都用这种寻敌方式
        {
            //Debug.Log("xueliang--------");
            for (int i = 0; i < Math.Min(8, distArray.Count); i++)  // 以8人为小组单位，在里面选一个血量最小的士兵进行攻击。
            {
                float ratio = (float)matchSprites[idx[i]]._data.HP / (float)sprite._data.HP; // *UnityEngine.Random.Range(0.1f, 1);
                if (ret == null || ratio < minRatio)
                {
                    ret = matchSprites[idx[i]];                    
                    minRatio = ratio;
                    continue;
                }
            }
        }
        else
        {
            ret = matchSprites[idx[0]];
        }

        // 调试用的，用来显示最后有多少士兵存活，总共还剩多少血量
        //string strTotal = String.Format("#.{0},HP={1}", matchSprites.Count, totalHP);
        //if(matchSprites[0]._data.Country != Defaults.Country.Me)
        //    Debug.Log(strTotal);

        return ret;
    }


    public void pause()
    {
        for (int i = 0; i < _selfSoldiers.Count; i++)
        {
            XLSpriteBase selfSpr = _selfSoldiers[i];
            selfSpr.pause();
        }

        for (int i = 0; i < _enemySoldiers.Count; i++)
        {
            XLSpriteBase enemySpr = _enemySoldiers[i];
            enemySpr.pause();
        }
    }

    public void resume()
    {
        for (int i = 0; i < _selfSoldiers.Count; i++)
        {
            XLSpriteBase selfSpr = _selfSoldiers[i];
            selfSpr.resume();
        }

        for (int i = 0; i < _enemySoldiers.Count; i++)
        {
            XLSpriteBase enemySpr = _enemySoldiers[i];
            enemySpr.resume();
        }
    }
}
