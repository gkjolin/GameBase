using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class TestLoadImage : MonoBehaviour
{

    private Transform mTransform;
    void Start()
    {
        mTransform = this.transform;
        //StartCoroutine(LoadUIAB());
        //StartCoroutine(LoadUI("uilogin"));
        StartCoroutine(LoadManifest());
    }
    private AssetBundleManifest manifest;
    private IEnumerator LoadManifest()
    {
        string path = "file://" + Application.streamingAssetsPath + "/StreamingAssets";
        WWW www = new WWW(path);
        yield return www;
        manifest = www.assetBundle.LoadAsset("AssetBundleManifest") as AssetBundleManifest;
        www.assetBundle.Unload(false);
        StartCoroutine(LoadAB("uilogin", (ab) =>
        {
            GameObject go = Instantiate(ab.LoadAsset("uilogin") as GameObject);
            go.transform.SetParent(mTransform);
            go.transform.localScale = Vector3.one;
            go.transform.localPosition = Vector3.zero;
        }));
    }

    private string[] GetAllDependecies(string name)
    {
        return manifest.GetAllDependencies(name);
    }

    private AssetBundle uiAB;
    private IEnumerator LoadUIAB()
    {
        string path = "file://" + Application.streamingAssetsPath + "/ui";
        WWW www = new WWW(path);
        yield return www;
        www.assetBundle.LoadAsset("ui");
        StartCoroutine(LoadUI("uilogin"));
    }

    private IEnumerator LoadAB(string name, Action<AssetBundle> callBack = null)
    {
        string[] arrDepends = GetAllDependecies(name);
        if (arrDepends != null && arrDepends.Length > 0)
        {
            for (int i = 0; i < arrDepends.Length; i++)
            {
                string pathD = "file://" + Application.streamingAssetsPath + "/" + arrDepends[i];
                WWW wwwD = new WWW(pathD);
                yield return wwwD;
                wwwD.assetBundle.LoadAsset(arrDepends[i]);
                if(i == arrDepends.Length-1)
                {
                    StartCoroutine(LoadUI("uilogin"));
                }
            }
        }
    }

    private GameObject CreatImage(Sprite s)
    {
        GameObject go = new GameObject();
        Image image = go.AddComponent<Image>();
        image.sprite = s;
        go.transform.SetParent(mTransform);
        go.transform.localPosition = Vector3.zero;
        go.transform.localScale = Vector3.one;
        go.name = s.name;
        return go;
    }

    private IEnumerator LoadUI(string name)
    {
        string path = "file://" + Application.streamingAssetsPath + "/" + name;
        WWW www = new WWW(path);
        yield return www;
        GameObject go = Instantiate(www.assetBundle.LoadAsset(name) as GameObject);
        go.transform.SetParent(mTransform);
        go.transform.localScale = Vector3.one;
        go.transform.localPosition = Vector3.zero;
        www.assetBundle.Unload(false);
    }

}
