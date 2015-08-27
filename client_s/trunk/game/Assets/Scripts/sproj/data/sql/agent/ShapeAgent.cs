
using System.Collections.Generic;

/// <summary>
/// 阵型
/// @author MXL
/// @date 2015-07
/// </summary>
class ShapeAgent
{
    private ShapeVO _shape = null;

    /// <summary>
    ///  设置对应的数据
    /// </summary>
    /// <param name="id"></param>
    public void setData(int id)
    {
        IList<ShapeVO> list = DataMgr.getInstance().Shape;

        for (int i = 0; i < list.Count; ++i)
        {
            if (id == list[i].ID)
            {
                _shape = list[i];
            }
        }
    }

    /// <summary>
    /// 获取数据
    /// </summary>
    /// <returns></returns>
    public int[] get()
    {
        return _shape.ShapeArray;
    }
}

