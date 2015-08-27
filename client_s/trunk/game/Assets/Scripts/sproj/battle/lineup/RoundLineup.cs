using UnityEngine;
using System.Collections;


/// <summary>
/// 圆形阵形
/// </summary>
public class RoundLineup : LineupBase {

	/// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="data_"></param>
    public RoundLineup(LineupData data_) : base(data_) { }


    /// <summary>
    /// 生成阵形
    /// </summary>
    /// <param name="data_"></param>
    public override void init(LineupData data_)
    {
        //生成圆形坐标
        for (int i = 0; i < 12; i++)
        {
            _room.Add(new Vector3(
                    data_.point.x + data_.room[0] * Mathf.Cos(360 / 12 * i * 3.14f / 180),
                    data_.point.y, 
                    data_.point.z + data_.room[0] * Mathf.Sin(360 / 12 * i * 3.14f / 180)));
        }
    }
}
