using UnityEngine;


/// <summary>
/// 矩形阵形
/// </summary>
public class RectangleLineup : LineupBase{

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="data"></param>
    public RectangleLineup(LineupData data_) : base(data_){}


    /// <summary>
    /// 初始化
    /// </summary>
    public override void init(LineupData data_)
    {
        //生成矩阵的坐标
        for (int i = 0; i < data_.room[3]; i++)
        {
            for (int j = 0; j < data_.room[4]; j++)
            {
                _room.Add(new Vector3(
                    data_.room[1] * i + data_.point.x,
                    data_.point.y,
                    data_.room[2] * j + data_.point.z));
            }
        }
    }
}
