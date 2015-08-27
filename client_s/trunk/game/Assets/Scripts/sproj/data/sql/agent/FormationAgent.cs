
using System.Collections.Generic;

/// <summary>
/// 编队
/// @author MXL
/// @date 2015-06
/// </summary>
public class FormationAgent
{
    private FormationVO _formation;

    public FormationAgent()
    {
 
    }

    /// <summary>
    /// 对应的数据
    /// </summary>
    /// <param name="id"></param>
    public void setData(int id)
    {
        IList<FormationVO> list = DataMgr.getInstance().Formation;

        for (int i = 0; i < list.Count; i++)
        {
            if (list[i].ID == id)
            {
                _formation = list[i];
            }
        }

    }
    
    /// <summary>
    ///  获取所有阵型
    /// </summary>
    /// <returns></returns>
    public int[] getShapeArray()
    {
        return _formation.ShapeArray;
    }


    /// <summary>
    /// 获取X 坐标数组
    /// </summary>
    /// <returns></returns>
    public float[] getPosXArray()
    {
        return _formation.PosXArray;
    }

    /// <summary>
    /// 获取Y 坐标数组
    /// </summary>
    /// <returns></returns>
    public float[] getPosYArray()
    {
        return _formation.PosYArray;
    }

    /// <summary>
    /// 获取Z 坐标数组
    /// </summary>
    /// <returns></returns>
    public float[] getPosZArray()

    {
        return _formation.PosZArray;
    }

}
