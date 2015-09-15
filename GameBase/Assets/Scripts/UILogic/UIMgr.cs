using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
using Game;
public class UIMgr : MonoBehaviour
{
    public enum Layer
    {
        layer1 = 0,
        layer2,
        layer3,
    }

    private static UIMgr _instance;
    private string ui_pre = "file://";
    private string ui_path = "/UI/";
    private string ui_ex = ".unity3D";
    private string path_head;
    public Canvas uiRoot;
    private Transform layer1;
    private Transform layer2;
    private Transform layer3;
    private Transform scene;
    private Transform[] arr_layers;
    private Dictionary<string, GameObject> dict_ui = new Dictionary<string, GameObject>();
    public Transform Layer1
    {
        get { return layer1; }
    }
    public Transform Layer2
    {
        get { return layer2; }
    }
    public Transform Layer3
    {
        get { return layer3; }
    }
    public static UIMgr Instance
    {
        get { return UIMgr._instance; }
    }

    void Awake()
    {
        Init();
        InitPreUI();
    }
    void Start()
    {

    }

    private void Init()
    {
        _instance = this;
        path_head = ui_pre + Application.streamingAssetsPath + ui_path;
        uiRoot = GameObject.Find("Canvas").GetComponent<Canvas>();
        layer1 = uiRoot.transform.Find("Layer1");
        layer2 = uiRoot.transform.Find("Layer2");
        layer3 = uiRoot.transform.Find("Layer3");
        arr_layers = new Transform[3] { layer1, layer2, layer3 };
        layer3.gameObject.SetActive(true);
    }

    /// <summary>
    /// 预加载 常用的UI
    /// </summary>
    private void InitPreUI()
    {
        this.LoadUIPrefab<UILoading>(UILoading.UIName, Layer.layer3);
    }
    /// <summary>
    /// 加载 assetbundle 类型的 UI, 正式版本使用
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="name"></param>
    /// <param name="layer"></param>
    /// <param name="OnLoadCallBack"></param>
    public void ShowUI<T>(string name, Layer layer = Layer.layer2, Action<GameObject> OnLoadCallBack = null,bool isReasle = false) where T : MonoBehaviour
    {
        
        GameObject go = null;
        if (dict_ui.ContainsKey(name))
        {
            go = dict_ui[name];
            if (go.activeSelf) return;
            go.SetActive(true);
            if (OnLoadCallBack != null)
            {
                OnLoadCallBack(go);
            }
        }
        else
        {
            if (GlobalData.isRealse)
            {
                LoadUI<T>(name, OnLoadCallBack, layer);
            }
            else
            {
                this.LoadUIPrefab<T>(name,layer);
            }
        }
    }

    public void CloseUI(string name, bool isDestory = false)
    {
        GameObject go = null;
        if (dict_ui.ContainsKey(name))
        {
            go = dict_ui[name];
            if (isDestory)
            {
                dict_ui.Remove(name);
                Destroy(go);
            }
            else
            {
                go.SetActive(false);
            }
        }
        else
        {
            Debug.Log("do not find this ui");
        }
    }

    public T GetUIScript<T>(string name) where T : UIBase
    {
        GameObject go = null;
        if (dict_ui.ContainsKey(name))
        {
            go = dict_ui[name];
            return go.GetComponent<T>();
        }
        return null;
    }

    public GameObject GetUIGameObject(string name)
    {
        return dict_ui[name];
    }

    public void LoadUI<T>(string name, Action<GameObject> OnLoadComplete, Layer layer) where T : MonoBehaviour
    {
        StartCoroutine(LoadRes<T>(name, OnLoadComplete, layer));
    }

    private IEnumerator LoadRes<T>(string name, Action<GameObject> OnLoadComplete, Layer layer) where T : MonoBehaviour
    {
        string url = GetResPath(name);
        WWW www = new WWW(url);

        while (!www.isDone)
        {
            yield return 0;
        }
        yield return www;

        if (www.error != null)
        {
            Debug.Log("load res error  : " + name);
        }
        else
        {
            GameObject go = Instantiate(www.assetBundle.mainAsset) as GameObject;
            go.transform.SetParent(arr_layers[(int)layer]);
            if (go.GetComponent<T>() == null)
            {
                go.AddComponent<T>();
            }
            (go.transform as RectTransform).anchoredPosition3D = Vector3.zero;
            (go.transform as RectTransform).localScale = Vector3.one;
            dict_ui.Add(name, go);
            if (OnLoadComplete != null)
            {
                OnLoadComplete(go);
            }
            www.assetBundle.Unload(false);
            Debug.Log("load new ui name : " + name);
        }
    }

    /*void Update()
    {
        if (www!=null && !www.isDone)
        {  
            Debug.Log("www.progress: " + www.progress);
        }
    }*/

    private string GetResPath(string name)
    {
        return path_head + name + ui_ex;
    }

   // private Dictionary<string, GameObject> _dict_UIPrefabs = new Dictionary<string, GameObject>();
    /// <summary>
    /// 开发阶段使用 加载本地资源
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="uiname"></param>
    /// <param name="layer"></param>
    /// <returns></returns>
    public T LoadUIPrefab<T>(string uiname, Layer layer = Layer.layer2, Action<GameObject> OnLoadCallBack = null) where T : MonoBehaviour
    {
        GameObject go = null;
        if (dict_ui.ContainsKey(uiname))
        {
            go = dict_ui[uiname];
        }
        else
        {
            go = GameObject.Instantiate(Resources.Load("Prefabs/" + uiname)) as GameObject;
            dict_ui.Add(uiname, go);
            go.transform.SetParent(arr_layers[(int)layer]);
            (go.transform as RectTransform).anchoredPosition = Vector3.zero;
            go.transform.localScale = Vector3.one;
        }
        if (go.GetComponent<T>() == null)
        {
            go.AddComponent<T>();
        }
        if (OnLoadCallBack != null)
        {
            OnLoadCallBack(go);
        }
        return go.GetComponent<T>();
    }

    public T GetUILogicScript<T>(string uiname) where T : MonoBehaviour
    {
        GameObject go = dict_ui[uiname];
        T t = go.GetComponent<T>();
        if (t != null)
        {
            t = go.AddComponent<T>();
        }
        return t;
    }

    public void SetUIPrefabVisible(string name, bool visible)
    {
        GameObject go = dict_ui[name];
        go.SetActive(visible);
    }

    public void DestoryUIPrefab(string name)
    {
        GameObject go = dict_ui[name];
        dict_ui.Remove(name);
        Destroy(go);
    }

    public GameObject LoadNewPrefab(string uiname, Transform parent)
    {
        return ResourceManager.Instance.LoadNewPrefab(uiname, parent);
    }

    public Transform GetLayer(Layer __layer)
    {
        return arr_layers[(int)__layer];
    }
}
