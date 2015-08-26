using UnityEngine;
using System.Collections;
using System.IO;

public class LoadAssetbundles : MonoBehaviour {

    private string BunldeURL = "file:///E:/u3dTest/assetbundle/Assets/assetbundles/MyCube.assetbundle";
	void Start () {
        print("load asset");
        print("app data path : " + Application.dataPath);
        //print : app data path : E:/u3dTest/assetbundle/Assets
        print("app streamingasset path : " + Application.streamingAssetsPath); 
        //print : app streamingasset path : E:/u3dTest/assetbundle/Assets/StreamingAssets

        StartCoroutine(LoadAsset());

        /*WWW w = new WWW("file://" + Application.streamingAssetsPath + "/Test.assetbundle");
        myTexture = w.assetBundle.Load("Test");*/

        //1.资源搜集使用Directory的GetFiles和GetDirectories可以很方便地获取到目录以及目录下的文件
        /*Directory.GetFiles("Assets/MyDirs", "*.*", SearchOption.TopDirectoryOnly);
        Directory.GetDirectories(Application.dataPath + "/Resources/Game", "*.*", SearchOption.AllDirectories);*/


        //2.资源读取 GetFiles搜集到的资源路径可以被加载，加载之前需要判断一下后缀是否.meta，如果是则不取出该资源，然后将路径转换至Assets开头的相对路径，然后加载资源
        
        /*string newPath = "Assets" + mypath.Replace(Application.dataPath, "");
        newPath = newPath.Replace("\\", "/");
        Object obj = AssetDatabase.LoadMainAssetAtPath(newPath);*/
	}

    IEnumerator LoadAsset()
    {
        //两种加载方法 1：

        /*WWW www = new WWW(BunldeURL);
        yield return www;
        if (www.error != null)
        {
            Debug.LogError("Load Bundle Faile " + BunldeURL + " Error Is " + www.error);
            yield break;
        }
        AssetBundle bundle = www.assetBundle;
        Instantiate(bundle.Load("MyCube"));
        bundle.Unload(false);
        print("load complete");*/


        //2 已被摒弃
        WWW www = WWW.LoadFromCacheOrDownload(BunldeURL,1);
        yield return www;
        AssetBundle bundle = www.assetBundle;
        Instantiate(bundle.LoadAsset("MyCube"));

    }

}
