using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

using XingLuoTianXia.lib;

/// <summary>
/// 主城
/// @author PT CJC
/// @date 2015-07
/// </summary>
public class HomeCityPanel : UIPanelBase
{
    void Start()
    {
        GameObject mainCamera = GameObject.Find("Main Camera");
        mainCamera.AddComponent<XLFpsDebug>();

        //创建容器
        List<string> btnsName = new List<string>();
        //通过按钮名向容器内添加按钮
        btnsName.Add("GameBtn");
        btnsName.Add("BagBtn");
        btnsName.Add("PlayerBtn");
        btnsName.Add("MainCityBtn");

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

    /// <summary>
    /// 导入场景
    /// </summary>
    /// <returns></returns>
    //     IEnumerator DownloadAssetAndScene()
    //     {
    //         //下载场景，加载场景  
    //         string sceneUrl = null;
    // 
    //         // "jar:file://" + Application.dataPath + "!/assets/" + "";
    // 
    //         if (Application.platform == RuntimePlatform.Android)
    //         {
    //             sceneUrl = Application.streamingAssetsPath + "/ShiYan001.bytes";
    //         }
    //         else
    //         {
    //             sceneUrl = "file:///" + Application.streamingAssetsPath + "/ShiYan001.bytes";
    //         }
    // 
    //         //--------------------------
    //         // if (Application.platform == RuntimePlatform.Android)
    //         // {
    //         //
    //         // }
    //         // else 
    //         // {
    //         //     dir = "file://" + dir;
    //         // }
    //         //
    //         // string filePath = dir + name + EXT;
    //         // WWW www = new WWW(filePath);
    //         // while (!www.isDone || www.error==null)
    //         // {
    //         // }
    //         //--------------------------
    //         // windows下的方式
    //         // string DIR = "./Assets/Resources/Bin/";
    //         // FileStream fs = File.OpenRead();
    // 
    //         Debug.Log("----------------------::::::::::::::::::::" + sceneUrl);
    // 
    //         using (WWW scene = new WWW(sceneUrl))
    //         {
    //             yield return scene;
    // 
    //             AssetBundle bundle = scene.assetBundle;
    //             Application.LoadLevel("ShiYan001");
    // 
    //             SceneInstaller.Instance.gameObject.SetActive(true);
    //         }
    // 
    // 
    //         Resources.Load("_AssetBundle/ShiYan001.unity3d");
    // }

    /// <summary>
    /// 通过按钮名称为按钮添加点击事件
    /// </summary>
    /// <param name="sender"></param>
    public void OnClick(GameObject sender)
    {
        if (sender.name == "GameBtn")
        {
            UIManager.getInstance().closePanel(PanelConfig.HOMECITYPANEL);
            UIManager.getInstance().openPanel(PanelConfig.WORLDMAPPANEL);
            return;
        }

        if (sender.name == "BagBtn")
        {
            Debug.Log("BagBtn!!!!!!");

            return;
        }

        if (sender.name == "PlayerBtn")
        {
            Debug.Log("PlayerBtn!!!!!!");

            return;
        }

        if (sender.name == "MainCityBtn")
        {
            Debug.Log("MainCityBtn!!!!!!");

            return;
        }
    }
}
