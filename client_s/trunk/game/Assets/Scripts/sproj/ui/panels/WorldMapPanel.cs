using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Collections;

using XingLuoTianXia.lib;

/// <summary>
/// 世界地图界面
/// </summary>
public class WorldMapPanel : UIPanelBase
{
    //界面是否开启
    private bool isDisabled = false;
    //界面按钮容器
    private List<Button> WorldMapPanelIconBtns;

    //缩放事件初始值
    private float pinchdistance = 0;

    //判断点击事件或者缩放事件是否运行
    private bool isRunning = false;
    void Start()
    {
        GamePanel worldMapPanel = UIManager.getInstance().getPanel(PanelConfig.WORLDMAPPANEL) as GamePanel;
        //创建容器
        List<string> btnsName = new List<string>();
        //通过按钮名向容器内添加按钮
        btnsName.Add("ReturnCityBtn");
        btnsName.Add("DiasLeagueBtn");
        btnsName.Add("TheIslandsOfTheSeaBtn");
        btnsName.Add("TlantisEmpireBtn");
        btnsName.Add("CityOfStarsBtn");
        btnsName.Add("SixtenRepblicBtn");
        btnsName.Add("MoonShadowVillageBtn");

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

    //通过按钮名称为按钮添加点击事件
    public void OnClick(GameObject sender)
    {
        if (isRunning)
        {
            return;
        }
        switch (sender.name)
        {
            case "ReturnCityBtn":
                Debug.Log(sender.name);
                UIManager.getInstance().closePanel(PanelConfig.WORLDMAPPANEL);
                UIManager.getInstance().openPanel(PanelConfig.HOMECITYPANEL);
                break;

            case "DiasLeagueBtn":
            case "TheIslandsOfTheSeaBtn":
            case "TlantisEmpireBtn":
            case "CityOfStarsBtn":
            case "SixtenRepblicBtn":
            case "MoonShadowVillageBtn":
                Debug.Log(sender.name);

                Destroy(GameObject.Find(PanelConfig.HOMECITYPANEL));
                //StartCoroutine(DownloadAssetAndScene());
				SwitchScene ();
                isRunning = true;
                break;

            default:
                Debug.Log("none");
                break;
        }
    }

    //FingerGestures缩放方法
    void OnPinch(PinchGesture gesture)
    {
        if (gesture.Phase == ContinuousGesturePhase.Started)
        {
            pinchdistance = gesture.Gap;
        }


        else if (gesture.Phase == ContinuousGesturePhase.Ended)
        {
            if (pinchdistance > gesture.Gap)
            {
                if (!isRunning)
                {
                    Destroy(GameObject.Find(PanelConfig.HOMECITYPANEL));
					SwitchScene ();
                }
            }

            else
            {
                if (!isRunning)
                {
                    UIManager.getInstance().closePanel(PanelConfig.WORLDMAPPANEL);
                    UIManager.getInstance().openPanel(PanelConfig.HOMECITYPANEL);
                }
            }
        }
    }

	/*
    /// <summary>
    /// 导入场景
    /// </summary>
    /// <returns></returns>
    IEnumerator DownloadAssetAndScene()
    {
        //下载场景，加载场景  
        string sceneUrl = null;

        // "jar:file://" + Application.dataPath + "!/assets/" + "";

        if (Application.platform == RuntimePlatform.Android)
        {
            sceneUrl = Application.streamingAssetsPath + "/ShiYan001.bytes";
        }
        else
        {
            sceneUrl = "file:///" + Application.streamingAssetsPath + "/ShiYan001.bytes";
        }

        //--------------------------
        // if (Application.platform == RuntimePlatform.Android)
        // {
        //
        // }
        // else 
        // {
        //     dir = "file://" + dir;
        // }
        //
        // string filePath = dir + name + EXT;
        // WWW www = new WWW(filePath);
        // while (!www.isDone || www.error==null)
        // {
        // }
        //--------------------------
        // windows下的方式
        // string DIR = "./Assets/Resources/Bin/";
        // FileStream fs = File.OpenRead();

        Debug.Log("----------------------::::::::::::::::::::" + sceneUrl);

        using (WWW scene = new WWW(sceneUrl))
        {
            yield return scene;

            AssetBundle bundle = scene.assetBundle;
			SceneLoaded ("ShiYan001");
        }
    }
    */

	void SwitchScene ()
	{
		UIManager.getInstance ().closePanel (PanelConfig.WORLDMAPPANEL);
		//StartCoroutine(DownloadAssetAndScene());
		Game.StateController.Current<Game.MainMenuStateController> ().SwitchScene ("ShiYan001");
	}
}