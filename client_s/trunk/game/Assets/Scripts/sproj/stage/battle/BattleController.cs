using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

using XingLuoTianXia.lib;

/// <summary>
/// @Description: 战场控制器
/// @author WSG
/// @date 2015-0414
/// 1、对峙
/// 2、挑衅
/// 3、倒计时
/// 4、战斗
/// 5、胜利
/// 6、失败
/// 7、编队前移
/// </summary>
public class BattleController : MonoBehaviour, IObserver, ITimeListener
{

    //初始化
    public const string BATTLESTATE_START = "battlestate_start";
    //对峙
    public const string BATTLESTATE_CONFRONTATION = "battlestate_confrontation";
    //挑衅
    public const string BATTLESTATE_PROVOCATION = "battlestate_provocation";
    //倒计时
    public const string BATTLESTATE_COUNTDOWN = "battlestate_countdown";
    //战斗
    public const string BATTLESTATE_FIGHT = "battlestate_fight";
    //胜利
    public const string BATTLESTATE_VICTORY = "battlestate_victory";
    //失败
    public const string BATTLESTATE_FAILED = "battlestate_failed";
    //编队前移
    public const string BATTLESTATE_WING_FORWARD = "battlestate_wing_forward";



    /// <summary>
    /// 正在进行战斗
    /// </summary>
    public bool isFighting = false;


    /// <summary>
    /// 战役数据
    /// </summary>
    private CampaignData campaignData;


    //自己的数据
    private MyFormationData myFormationData;


    /// <summary>
    /// 倒计时文本
    /// </summary>
    private Text timeText;

    /// <summary>
    /// 失败界面————————测试用
    /// </summary>
    //public GameObject FailedMenu;

    /// <summary>
    /// 胜利界面————————测试用
    /// </summary>
    //public GameObject VictoryMenu;


    /// <summary>
    /// 计时器
    /// </summary>
    private TimerListener timerListener;

    /// <summary>
    /// 战役进度——————测试用
    /// </summary>
    private int num = 2;

    //private float offsetY = 20.0f;

    /// <summary>
    /// 己方编队坐标
    /// </summary>
    private Vector3[] _mySoldierPoints = new Vector3[] { 
        new Vector3(9.5f,0,20 + 25),//英雄

        new Vector3(3.5f,0,14+ 25),
        new Vector3(9.5f,0,14+ 25),
        new Vector3(15.7f,0,14+ 25),

        new Vector3(3.5f,0,8 + 25),
        new Vector3(9.5f,0,8 + 25),
        new Vector3(15.7f,0,8 + 25),


        new Vector3(3.5f,0,20 + 25),
        new Vector3(15.7f,0,20 + 25)
    };

    /// <summary>
    /// 敌方编队坐标
    /// </summary>
    private Vector3[] _enemySoldierPoints = new Vector3[]{
        new Vector3(5,0,51),
        new Vector3(5,0,57),
        new Vector3(5,0,63),

        new Vector3(11.2f,0,51),
        new Vector3(11.2f,0,57),
        new Vector3(11.2f,0,63),

        new Vector3(17.2f,0,51),
        new Vector3(17.2f,0,57),
        new Vector3(17.2f,0,63)
    };




    public void Start()
    {
        //UI面板初始化
        UIManager.getInstance().closePanel(PanelConfig.WORLDMAPPANEL);
        UIManager.getInstance().closePanel(PanelConfig.HOMECITYPANEL);

        //注册计时器,3,2,1,go,隐藏一共5次
        timerListener = new TimerListener(this, 1, 5, false);

        //注册
        XLMessageManager.getInstance().register(this);

        //进入战斗
        XLMessageManager.getInstance().sendNotification(BATTLESTATE_START);

        //取得倒计时文本
        GamePanel gamePanel = UIManager.getInstance().getPanel(PanelConfig.GAMEPANEL) as GamePanel;
        if (gamePanel != null)
        {
            timeText = gamePanel.timeText;
        }

		GameObject mainCamera = Game.GameEntry.Instance.Cameras.mainCamera.gameObject;
        iTween.MoveTo(mainCamera, new Vector3(mainCamera.transform.position.x, mainCamera.transform.position.y, mainCamera.transform.position.z + 44), 5f);

        // 这样调节场景坐标，不管用
        // GameObject sceneObject = GameObject.Find("GameObject");
        // sceneObject.transform.position = new Vector3(sceneObject.transform.position.x, sceneObject.transform.position.y + 10f, sceneObject.transform.position.z);
    }

    /// <summary>  
    /// 鼠标射线  
    /// </summary>  
    //private Ray _ray;
    /// <summary>  
    /// 射线碰撞的结构  
    /// </summary>  
    //private RaycastHit _rayhit;
    /// <summary>  
    /// 鼠标拾取的有效距离  
    /// </summary>  
    //private float _fDistance = 20f;

    public void Update()
    {
        // Debug.Log("u-----------------------------------");

        //检测鼠标左键的拾取  
        //         if (Input.GetMouseButtonDown(0))
        //         {
        //             if (_camPlayer == null)
        //             {
        //                 //_camPlayer = (this.gameObject as Camera);
        //             }
        // 
        //             //鼠标的屏幕坐标空间位置转射线  
        //             _ray = _camPlayer.ScreenPointToRay(Input.mousePosition);
        //             //射线检测，相关检测信息保存到RaycastHit 结构中  
        //             if (Physics.Raycast(_ray, out _rayhit, _fDistance))
        //             {
        //                 //打印射线碰撞到的对象的名称  
        //                 print(_rayhit.collider.gameObject.name);
        //             }
        //         }
    }


    /// <summary>
    /// 观察者关心的消息列表
    /// </summary>
    /// <returns></returns>
    public IList<string> listNotificationInterests()
    {
        return new List<string>(){
            BATTLESTATE_START, 
            BATTLESTATE_CONFRONTATION,
            BATTLESTATE_PROVOCATION,
            BATTLESTATE_COUNTDOWN,
            BATTLESTATE_FIGHT,
            BATTLESTATE_VICTORY,
            BATTLESTATE_FAILED,
            BATTLESTATE_WING_FORWARD
        };
    }


    /// <summary>
    /// 接收关心的消息的方法
    /// </summary>
    /// <param name="notification"></param>
    public void handleNotification(XLNotification notification)
    {
        //根据消息名对应处理
        switch (notification.Name)
        {
            case BATTLESTATE_START:   //战斗开始
                //显示战斗界面
                UIManager.getInstance().openPanel(PanelConfig.GAMEPANEL);

                //战役进度
                num--;

                //战役初始化
                BattleInit();

                //开始倒计时
                XLMessageManager.getInstance().sendNotification(BATTLESTATE_COUNTDOWN);
                break;

            case BATTLESTATE_COUNTDOWN:    //倒计时
                if (timeText != null)
                {
                    timeText.text = "";
                    timeText.gameObject.SetActive(true);
                }
                timerListener.number = 5;
                TimerManager.getInstance().addListener(timerListener);
                timerListener.isRunning = true;
                break;

            case BATTLESTATE_FIGHT:    //战斗
                fighting();
                break;

            case BATTLESTATE_FAILED:   //战斗失败
                battlestateFailed();
                break;

            case BATTLESTATE_VICTORY:  //战斗胜利
                battlestateVictory();
                break;


        }
    }


    private void loadSkillRes()
    {

    }


    /// <summary>
    /// 战役初始化
    /// </summary>
    private void BattleInit()
    {
        //取得数据
        creatTestData();

        //显示
        viewInit();
    }


    /// <summary>
    /// 生成测试用的数据
    /// </summary>
    private void creatTestData()
    {
        //生成自己数据
        MyFormationData.getInstance();

        //生成战役数据
        campaignData = new CampaignData(1);
    }



    /// <summary>
    /// 显示初始化
    /// </summary>
    private void viewInit()
    {
        //生成自己部队，只在第一回合生成自己部队
        if (campaignData != null && campaignData.battleIndex == 0)
        {
            //creatNextBattle(myFormationData);
        }

        //生成下一个战场敌人部队
        //creatNextBattle(campaignData.getBattle(index));

        //生成下一个战场（测试）
        creatNextBattle(null);
    }

    /// <summary>
    /// 摄影机移动
    /// </summary>
    private void camplayerMove()
    {
		GameObject mainCamera = Game.GameEntry.Instance.Cameras.mainCamera.gameObject;
        iTween.MoveTo(mainCamera, new Vector3(mainCamera.transform.position.x, mainCamera.transform.position.y, mainCamera.transform.position.z + 5), 5f);
    }

    /// <summary>
    /// debug,控制人数的
    /// </summary>
    private static int SPRITE_COUNT = 20;

    /// <summary>
    /// 生成下一个战场的显示内容
    /// </summary>
    private void creatNextBattle(BattleData data)
    {
        int spriteCount = 0;
        bool isBreak = false;

        if (num == 1)
        {
            //生成自己的部队
            for (int i = 0; i < MyFormationData.formationList.Count; i++)
            {
                for (int j = 0; j < MyFormationData.formationList[i].SoldiersDict.Count; j++)
                {
                    if (MyFormationData.formationList[i].SoldiersDict[j] != null)
                    {
                        MyFormationData.formationList[i].SoldiersDict[j].Country = Defaults.Country.Me;
                        if (i == 0)
                        {
                            SpriteMgr.getInstance().addSoldier(MyFormationData.formationList[i].SoldiersDict[j], Defaults.SoldierType.Cavalryman, new Vector3(j % 3 + _mySoldierPoints[i].x, 0 + _mySoldierPoints[i].y, (int)(j / 3) + _mySoldierPoints[i].z));
                        }
                        else
                        {
                            SpriteMgr.getInstance().addSoldier(MyFormationData.formationList[i].SoldiersDict[j], Defaults.SoldierType.Armorman, new Vector3(j % 3 + _mySoldierPoints[i].x, 0 + _mySoldierPoints[i].y, (int)(j / 3) + _mySoldierPoints[i].z));
                        }

                        if (++spriteCount >= SPRITE_COUNT)
                        {
                            isBreak = true;
                            break;
                        }
                    }
                }

                if (isBreak)
                {
                    break;
                }
            }
        }

        spriteCount = 0;
        if (num == 0)
        {
            //自己部队停止动作
            for (int i = 0; i < SpriteMgr.getInstance().SelfSoldiers.Count; i++)
            {
                GeneralSoldier soldier = SpriteMgr.getInstance().SelfSoldiers[i] as GeneralSoldier;
                soldier.setState(soldier.IdleState);
                soldier.IsDebug = true;

                if (++spriteCount >= SPRITE_COUNT)
                {
                    break;
                }
            }
        }

        //生成敌人的部队
        spriteCount = 0;
        isBreak = false;
        for (int i = 0; i < campaignData.BattleList[campaignData.battleIndex].FormationList.Count; i++)
        {
            for (int j = 0; j < campaignData.BattleList[campaignData.battleIndex].FormationList[i].SoldiersDict.Count; j++)
            {
                //Debug.Log(i + " " + j + " " + campaignData.BattleList[campaignData.battleIndex].FormationList[i].soldiersDict[j]);
                if (campaignData.BattleList[campaignData.battleIndex].FormationList[i].SoldiersDict[j] != null)
                {
                    campaignData.BattleList[campaignData.battleIndex].FormationList[i].SoldiersDict[j].Country = Defaults.Country.Enemy;
                    if (j == 0)
                    {
                        SpriteMgr.getInstance().addSoldier(campaignData.BattleList[campaignData.battleIndex].FormationList[i].SoldiersDict[j], Defaults.SoldierType.Masterman, new Vector3(j % 3 + _enemySoldierPoints[i].x, 0 + _enemySoldierPoints[i].y, (int)(j / 3) + _enemySoldierPoints[i].z));
                    }
                    else
                    {
                        SpriteMgr.getInstance().addSoldier(campaignData.BattleList[campaignData.battleIndex].FormationList[i].SoldiersDict[j], Defaults.SoldierType.Axeman, new Vector3(j % 3 + _enemySoldierPoints[i].x, 0 + _enemySoldierPoints[i].y, (int)(j / 3) + _enemySoldierPoints[i].z));
                    }
                }

                if (++spriteCount >= SPRITE_COUNT)
                {
                    isBreak = true;
                    break;
                }
            }

            if (isBreak)
            {
                break;
            }
        }
    }


    /// <summary>
    /// 时间到的回调
    /// </summary>
    /// <param name="deltaTime"></param>
    public void timerHandler(float deltaTime)
    {
        //Debug.Log(timerListener.number);
        //3,2,1
        if (timerListener.number > 2)
        {
            if (timeText != null)
            {
                timeText.text = (timerListener.number - 2).ToString();
            }
        }
        else if (timerListener.number == 2)
        {
            //GO
            if (timeText != null)
            {
                timeText.text = "GO!";
            }
        }
        else
        {
            //隐藏倒计时文本
            if (timeText != null)
            {
                timeText.gameObject.SetActive(false);
            }
            //开始战斗
            XLMessageManager.getInstance().sendNotification(BATTLESTATE_FIGHT);
        }
    }


    /// <summary>
    /// 全员进入战斗状态
    /// </summary>
    private void fighting()
    {
        GeneralSoldier soldier;

        //我军进入战斗状态
        for (int i = 0; i < SpriteMgr.getInstance().SelfSoldiers.Count; i++)
        {
            //取得脚本
            soldier = SpriteMgr.getInstance().SelfSoldiers[i] as GeneralSoldier;
            if (soldier != null)
            {
                //变成锁敌状态
                soldier.setState(soldier.WalkState);
            }
        }

        //敌军进入战斗状态
        for (int i = 0; i < SpriteMgr.getInstance().EnemySoldiers.Count; i++)
        {
            //取得脚本
            soldier = SpriteMgr.getInstance().EnemySoldiers[i] as GeneralSoldier;
            if (soldier != null)
            {
                //变成锁敌状态
                soldier.setState(soldier.WalkState);
            }
        }
    }

    /// <summary>
    /// 战斗胜利
    /// </summary>
    private void battlestateVictory()
    {
        //己方全员播放胜利动作
        GeneralSoldier soldier;
        for (int i = 0; i < SpriteMgr.getInstance().SelfSoldiers.Count; i++)
        {
            soldier = SpriteMgr.getInstance().SelfSoldiers[i] as GeneralSoldier;
            soldier.setState(soldier.WinState);
        }

        //战役是否结束
        if (num == 0)
        {
            //弹胜利窗口
            UIManager.getInstance().openPanel(PanelConfig.VICTORYPANEL);
            Debug.Log("弹胜利窗口");
        }
        else
        {
            //下一波战斗
            XLMessageManager.getInstance().sendNotification(BATTLESTATE_START);
            camplayerMove();
        }
    }


    /// <summary>
    /// 战斗失败
    /// </summary>
    private void battlestateFailed()
    {
        //敌方全员播放胜利动作
        for (int i = 0; i < SpriteMgr.getInstance().EnemySoldiers.Count; i++)
        {
            GeneralSoldier soldier = SpriteMgr.getInstance().EnemySoldiers[i] as GeneralSoldier;
            soldier.setState(soldier.WinState);
        }

        //弹失败窗口
        UIManager.getInstance().openPanel(PanelConfig.FAILEDPANEL);
        Debug.Log("弹失败窗口");
    }
}