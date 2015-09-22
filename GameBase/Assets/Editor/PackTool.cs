using UnityEngine;
using System.Collections;
using UnityEditor;
using System.IO;

public class PackTool : MonoBehaviour
{

    [MenuItem("PackTool/Pack")]
    public static void Pack()
    {
        BuildPipeline.BuildAssetBundles(Application.streamingAssetsPath);
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
            ai.assetBundleName = fi.Name.Substring(0, fi.Name.Length - 7);
        }
        AssetDatabase.Refresh();
    }

    [MenuItem("PackTool/PackClass")]
    public static void PackClass()
    {

        /*AssetDatabase.RemoveUnusedAssetBundleNames();
        string[] arrFolders = AssetDatabase.GetSubFolders("Assets/Scripts/StaticData");
        for (int i = 0; i < arrFolders.Length; i++)
        {
            string folderName = arrFolders[i];
            AssetImporter ai = AssetImporter.GetAtPath(folderName);
            DirectoryInfo di = new DirectoryInfo(Application.dataPath + folderName);
            ai.assetBundleName = di.Name;
        }*/
        AssetImporter ai = AssetImporter.GetAtPath("Assets/Scripts/StaticData");
        DirectoryInfo di = new DirectoryInfo(Application.dataPath + "Assets/Scripts/StaticData");
        ai.assetBundleName = di.Name;
        AssetDatabase.Refresh();
        Pack();
    }

}
