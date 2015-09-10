using UnityEngine;
using System.Collections;
using UnityEditor;
using System.IO;
using System.Collections.Generic;

public class PackTool : MonoBehaviour
{
    [MenuItem("PackTool/Pack")]
    public static void Pack()
    {
        BuildPipeline.BuildAssetBundles(Application.streamingAssetsPath);
    }

    //test
    [MenuItem("PackTool/SetFileBundleName")]
    static void SetBundleName()
    {
        //PrintArray(AssetDatabase.GetSubFolders("Assets"));
        //PrintArray(AssetDatabase.GetDependencies(new string[]{"Assets/StreamingAssets/uilogin"}));
        //Path.get
        //Selection.
        //AssetDatabase.SetLabels()
        Object o = AssetDatabase.LoadMainAssetAtPath("Assets/c");
        string[] s = new string[] { "generat" };
        AssetDatabase.SetLabels(o, s);
        AssetImporter.GetAtPath("Assets/c").assetBundleName = "c";

        return;
        #region 设置资源的AssetBundle的名称和文件扩展名
        UnityEngine.Object[] selects = Selection.objects;

        Debug.Log("Selection.activeGameObject.name :" + Selection.activeGameObject.name);
        Debug.Log("Selection.activeObject.name :" + Selection.activeObject.name);
        Debug.Log("Selection.activeObject.name :" + Selection.gameObjects.Length);

        Debug.Log("selects length " + selects.Length);
        foreach (UnityEngine.Object selected in selects)
        {
            string path = AssetDatabase.GetAssetPath(selected);
            Debug.Log(path);
            AssetImporter asset = AssetImporter.GetAtPath(path);
            asset.assetBundleName = selected.name; //设置Bundle文件的名称
            //asset.assetBundleVariant = "unity3d";//设置Bundle文件的扩展
            asset.SaveAndReimport();

            //AssetDatabase.
        }
        AssetDatabase.Refresh();
        #endregion
    }
    /// <summary>
    /// 以文件夹形式，将一个文件里的资源 打到 一个 assetbundle里，assetbundle name 为文件夹的名字
    /// </summary>
    [MenuItem("PackTool/PackAssetBundleByFolder")]
    public static void PackAssetBundleByFolder()
    {
        AssetDatabase.RemoveUnusedAssetBundleNames();
        string[] arrFolders = AssetDatabase.GetSubFolders("Assets/AssetBundle");
        for (int i = 0; i < arrFolders.Length; i++)
        {
            string folderName = arrFolders[i];
            AssetImporter ai = AssetImporter.GetAtPath(folderName);
            DirectoryInfo di = new DirectoryInfo(Application.dataPath + folderName);
            ai.assetBundleName = di.Name;
        }
    }

    /// <summary>
    /// ui界面 打成单个 assetbundle
    /// </summary>
    [MenuItem("PackTool/PackAssetBundleSingle")]
    public static void PackAssetBundleSingleOfUIPrefab()
    {
        DirectoryInfo di = new DirectoryInfo(Application.dataPath + "/Resources/prefabs/UIPrefab");
        FileInfo[] files = di.GetFiles("*.prefab");
        for (int i = 0; i < files.Length; i++)
        {
            FileInfo fi = files[i];
            string p = "Assets/Resources/prefabs/UIPrefab/" + fi.Name;
            Debug.Log(p + "      fileName " + fi.Name);
            AssetImporter ai = AssetImporter.GetAtPath(p);
            ai.assetBundleName = fi.Name.Substring(0,fi.Name.Length-7);
        }
        AssetDatabase.Refresh();
    }

    public static void PrintArray(string[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            Debug.Log(" print array index " + i + "  " + arr[i]);
        }
    }
}
