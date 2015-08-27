using UnityEngine;
using System.Collections;


/// <summary>
/// 三角形阵形
/// </summary>
public class TriangleLineup : LineupBase {

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="data_"></param>
	public TriangleLineup(LineupData data_) : base(data_){}


    /// <summary>
    /// 生成阵形
    /// </summary>
    /// <param name="data_"></param>
    public override void init(LineupData data_)
    {
        //边长
        float side = 0;

        //依次添加每行的其他坐标
        int num = 0;
        for (int i = 0; i < data_.room[1]; i++)
        {
            //取半个边长
            side = data_.room[0] * i / Mathf.Tan(45);
            //取每一行最左侧的点的坐标
            float left = data_.point.x - side;
            //间隔
            float spacing = side * 2 / i;

            for (int j = 0; j <= i; j++)
            {
                //添加顶点
                if (i == 0 && j == 0)
                {
                    _room.Add(data_.point);
                }
                else
                {
                    //从最左侧坐标依次增加固定长度
                    _room.Add(new Vector3(left + spacing * j, data_.point.y, data_.point.z + data_.room[0] * i));
                }

                num++;
                if (num >= data_.room[1])
                {
                    return;
                }
            }
        }
    }
}
