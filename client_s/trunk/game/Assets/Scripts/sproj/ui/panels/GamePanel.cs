using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using XingLuoTianXia.lib;

/// <summary>
/// 游戏中界面
/// </summary>
public class GamePanel : UIPanelBase
{
    /// <summary>
    /// 倒计时文本
    /// </summary>
    public Text timeText;

    //按钮容器
    public List<Button> _GamePanelIconBtns;

    //游戏是否暂停
    public bool isPause = false;

    void Start()
    {
        //创建容器
        List<string> btnsName = new List<string>();
        //通过按钮名向容器内添加按钮
        btnsName.Add("HeroBtnPre_1");
        btnsName.Add("HeroBtnPre_2");
        btnsName.Add("HeroBtnPre_3");
        btnsName.Add("HeroBtnPre_4");
        btnsName.Add("HeroBtnPre_5");
        btnsName.Add("HeroBtnPre_6");
        btnsName.Add("AutoBattleBtn");
        btnsName.Add("TaskListBtn");
        btnsName.Add("PauseBtnPre");
        //遍历容器
        foreach (string btnName in btnsName)
        {
            //通过按钮名称获取按钮
            GameObject btnObj = GameObject.Find(btnName);
            Button btn = btnObj.GetComponent<Button>();

            btn.onClick.AddListener(delegate()
            {
                this.OnClick(btnObj);
            });
        }
    }

    private GameObject _scene;

    //通过按钮名称为按钮添加点击事件
    public void OnClick(GameObject sender)
    {
        switch (sender.name)
        {
            case "HeroBtnPre_1":
                Debug.Log("HeroBtnPre_1");
                break;
            case "HeroBtnPre_2":
                Debug.Log("HeroBtnPre_2");
                break;
            case "HeroBtnPre_3":
                Debug.Log("HeroBtnPre_3");
                break;
            case "HeroBtnPre_4":
                Debug.Log("HeroBtnPre_4");
                break;
            case "HeroBtnPre_5":
                Debug.Log("HeroBtnPre_5");
                break;
            case "HeroBtnPre_6":
                Debug.Log("HeroBtnPre_6");
                break;
            case "AutoBattleBtn":
                if (_scene == null)
                {
                    _scene = GameObject.Find("moxingziyuan");
                }
                _scene.SetActive(!_scene.active);

                Debug.Log("AutoBattleBtn");
                break;
            case "TaskListBtn":
                Debug.Log("AutoBattleBtn");
                Debug.Log("TaskListBtn");
                break;
            case "PauseBtnPre":
                Resume();
                break;

            default:
                Debug.Log("none");
                break;
        }
    }


    public void Resume()
    {
        if (!isPause)
        {
            Time.timeScale = 0;
            isPause = true;

            UIManager.getInstance().openPanel(PanelConfig.PAUSEPANEL);

            for (int i = 0; i < _GamePanelIconBtns.Count; i++)
            {
                _GamePanelIconBtns[i].interactable = false;
            }

            SpriteMgr.getInstance().pause();

        }
        else
        {
            Time.timeScale = 1;
            isPause = false;

            UIManager.getInstance().closePanel(PanelConfig.PAUSEPANEL);

            for (int i = 0; i < _GamePanelIconBtns.Count; i++)
            {
                _GamePanelIconBtns[i].interactable = true;
            }

            SpriteMgr.getInstance().resume();
        }
    }
}
