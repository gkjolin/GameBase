using UnityEngine;
using System.Collections.Generic;


/// <summary>
/// 阵形基类
/// </summary>
public abstract class LineupBase {

    /// <summary>
    /// 阵形数据
    /// </summary>
    public LineupData data;

    /// <summary>
    /// 坐标点
    /// </summary>
    protected List<Vector3> _room = new List<Vector3>();


    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="data"></param>
    public LineupBase(LineupData data_)
    {
        //转存阵形数据
        this.data = data_;

        //生成阵形
        init(data_);
    }


    /// <summary>
    /// 根据索引，取得在阵形中的相对坐标
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public Vector3 getPoint(int index)
    {
        //如果存在，返回对应索引的坐标
        if (index < _room.Count)
        {
            return _room[index];
        }
        
        //不存在，返回假值
        return new Vector3(-100, -100, -100);
    }


    /// <summary>
    /// 修改阵形坐标
    /// </summary>
    /// <param name="point"></param>
    public void changePoint(Vector3 point)
    {
        //修改坐标
        data.point = point;

        //清空原有阵形数据
        _room.Clear();

        //重新布阵
        init(data);
    }


    /// <summary>
    /// 初始化，主要初始化阵形数据。由子类实现
    /// </summary>
    /// <param name="data"></param>
    /// <param name="point"></param>
    public abstract void init(LineupData data);
    
}
