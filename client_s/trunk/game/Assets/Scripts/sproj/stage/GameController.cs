using UnityEngine;
using System.Collections;


/// <summary>
/// @Description: 游戏控制器
/// @author WSG
/// @date 2015-0505
/// </summary>
public class GameController{

    /// <summary>
    /// 单例
    /// </summary>
    private static GameController _instance = null;


    /// <summary>
    /// 单例
    /// </summary>
    /// <returns></returns>
    public static GameController getInstance()
    {
        if (_instance == null)
        {
            _instance = new GameController();
        }
        return _instance;
    }


    /// <summary>
    /// 进入战斗
    /// </summary>
    /// <param name="battleID"></param>
    /// <returns></returns>
    public bool EnterTheBattle(int battleID)
    {
        //条件判断



        //释放资源




        //显示加载界面




        //进入战斗场景
        //BattleController.getInstance().EnterTheBattle(battleID);
        Application.LoadLevel("Buttle1");


        //移除加载界面

        
        return true;
    }


}
