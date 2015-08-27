using System.Collections.Generic;

using UnityEngine;



/// <summary>
/// 通用的池管理类  目前特效在用
/// @author MXL
/// @date 2015-07
/// </summary>

public class EffectPool : MonoBehaviour
{

    #region 公共属性
    /// <summary>
    /// 特效对象
    /// </summary>
    public GameObject objPrefab;

    /// <summary>
    /// 容量
    /// </summary>
    private int _initialCapacity = 5;

    #endregion

    #region 私有属性

    /// <summary>
    /// 初始下标
    /// </summary>
    private int _startCapacityIndex = 0;

    /// <summary>
    /// 可用下标
    /// </summary>
    private List<int> _avaliableIndex;

    /// <summary>
    /// 池中元素
    /// </summary>
    private Dictionary<int, GameObject> _totalObjList;

    /// <summary>
    /// 记录池的名字
    /// </summary>
    private string poolName = "";

    /// <summary>
    /// 重置技能存活时间用的
    /// </summary>
    private const int survivalTime = 90;

    #endregion

    #region 事件/重写方法

    public EffectPool(GameObject obj)
    {
        poolName = obj.name;

        objPrefab = obj;

        _avaliableIndex = new List<int>(_initialCapacity);

        _totalObjList = new Dictionary<int, GameObject>(_initialCapacity);

        expandPool();

    }

    #endregion


    #region 公共方法

    /// <summary>
    /// 获取当前pool 的名字
    /// </summary>
    /// <returns></returns>
    public string getName()
    {
        return this.poolName;
    }

    /// <summary>
    /// 取得一个物体，返回值 1,obj代表，ID是1的物体被取到，ID可以用来归还物体的时候用到
    /// </summary>
    /// <returns></returns>
    public KeyValuePair<int, GameObject> pickObj()
    {


        if (_avaliableIndex.Count == 0)
        {
            expandPool();
        }

        int id = _avaliableIndex[0];

        _avaliableIndex.Remove(id);

        _totalObjList[id].SetActive(true);

        SkillDispose skillScript = _totalObjList[id].GetComponent<SkillDispose>();

        // 重置技能时间
        skillScript.time = survivalTime;

        return new KeyValuePair<int, GameObject>(id, _totalObjList[id]);

    }


    /// <summary>
    /// 回收一个物体
    /// </summary>
    /// <param name="id"></param>
    public void recyleObj(int id)
    {

        _totalObjList[id].SetActive(false);

     //   _totalObjList[id].transform.parent = transform;

        _avaliableIndex.Add(id);

    }
    #endregion

    #region 私有方法

    /// <summary>
    /// 创建池
    /// </summary>
    private void expandPool()
    {
        int start = _startCapacityIndex;
        int end = _startCapacityIndex + _initialCapacity;

        for (int i = start; i < end; i++)
        {

            //加入验证判断，避免在极端情况下

            //（1：两次申请同时发起 2：第二次申请的时候，第一次还没有扩展任何元素）时

            if (_totalObjList.ContainsKey(i))
            {
                continue;
            }

            GameObject newObj = Instantiate(objPrefab) as GameObject;

            newObj.AddComponent<SkillDispose>();

            SkillDispose skillScript = newObj.GetComponent<SkillDispose>();
            skillScript.id = i;

            newObj.SetActive(false);

            _avaliableIndex.Add(i);

            _totalObjList.Add(i, newObj);

        }

        // 更新索引
        _startCapacityIndex = end;

    }

    #endregion

}