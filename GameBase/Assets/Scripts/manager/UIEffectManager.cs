using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class UIEffectManager{

    private Dictionary<string, GameObject> dict_effect = new Dictionary<string, GameObject>();
    private static UIEffectManager _instance;


    void Start()
    {
        _instance = this;
    }

    public static UIEffectManager Instance
    {
        get { if (_instance == null) { _instance = new UIEffectManager(); } return UIEffectManager._instance; }
    }

    public GameObject GetUIEffect(string effectName,Action<GameObject> CallBack)
    {
        GameObject go = null;
        if(dict_effect.ContainsKey(effectName))
        {
            go= dict_effect[effectName];
            if(CallBack!=null)
            {
                CallBack(go);
            }
        }else
        {
            go = LoadUIEffect(effectName,CallBack);
        }
        return go;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="name">特效名称 特效要在UIEffect文件夹下</param>
    /// <param name="CallBack">特效加载完的回调</param>
    /// <returns></returns>
    public GameObject LoadUIEffect(string name, Action<GameObject> CallBack)
    {
        IEnumerator ie = StartLoad(name, CallBack);
        GlobalData.Instance.StartCoroutine(ie);
        return null;
    }

    private IEnumerator StartLoad(string name, Action<GameObject> CallBack)
    {
        string path = "file://" + Application.streamingAssetsPath + "/UIEffect/" + name + ".unity3D";
        WWW loader = new WWW(path);
        yield return loader;
        if(loader.error!=null)
        {
            Debug.Log("load effect error :  " +  name);
        }else
        {
            GameObject go = loader.assetBundle.mainAsset as GameObject;
            dict_effect.Add(name,go);
            //go.SetActive(false);
            loader.assetBundle.Unload(false);
            if(CallBack!=null)
            {
                CallBack(go);
            }
        }
    }

}
