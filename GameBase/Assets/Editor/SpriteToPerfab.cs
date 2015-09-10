using UnityEngine;
using System.Collections;
using UnityEditor;
using System.IO;
using System.Collections.Generic;

public class SpriteToPerfab : MonoBehaviour
{
    [MenuItem("MyMenu/PackUIPerfab")]
    static void PackUIPerfab()
    {
        if (Selection.activeGameObject != null)
        {
            GameObject obj = Selection.activeGameObject;
            BuildPipeline.BuildAssetBundle(obj, new Object[] { obj }, Application.dataPath + "/StreamingAssets/UI/" + obj.name + ".unity3D");
        }
    }
    [MenuItem("MyMenu/PackUIEffectPerfab")]
    public static void PackUIEffectPerfab()
    {
        if (Selection.activeGameObject != null)
        {
            GameObject go = Selection.activeGameObject;
            BuildPipeline.BuildAssetBundle(go, new Object[] { go }, Application.dataPath + "/StreamingAssets/UIEffect/" + go.name + ".unity3D");
        }
    }

    [MenuItem("MyMenu/PackSelectText")]
    public static void PackText()
    {
        if (Selection.activeObject != null)
        {
            Object go = Selection.activeObject;
            Debug.Log("select text : " + go.name);
            BuildPipeline.BuildAssetBundle(go, new Object[] { go }, Application.dataPath + "/StreamingAssets/data/" + go.name + ".unity3D", BuildAssetBundleOptions.UncompressedAssetBundle, GetBuildTarget());
        }
    }

    [MenuItem("MyMenu/PackAllSelectText")]
    public static void PackAllTexts()
    {
        //Object[] _objs = Selection.GetFiltered(typeof(Object), SelectionMode.DeepAssets);
        /*foreach(Object o in _objs)
        {
            BuildPipeline.BuildAssetBundle(o, new Object[] { o }, Application.dataPath + "/StreamingAssets/data/" + o.name + ".unity3D", BuildAssetBundleOptions.UncompressedAssetBundle, GetBuildTarget());
        }*/
        //每个数据表单独打包为一个 assetbundle
        //BuildPipeline.BuildAssetBundle(null, _objs, Application.dataPath + "/StreamingAssets/data/data.unity3D", BuildAssetBundleOptions.UncompressedAssetBundle, GetBuildTarget()); //把所有数据表打包到一个 assetbundle里

        string path = Application.dataPath + "/Resources/Data";
        DirectoryInfo directoryInfo = new DirectoryInfo(path);
        List<Object> _objsList = new List<Object>();
        FileInfo[] _arrFiles = directoryInfo.GetFiles("*.json", SearchOption.AllDirectories);
        Debug.Log("PackAllTexts : " + directoryInfo.Name);
        foreach (FileInfo cellFileInfo in _arrFiles)
        {
            string fullname = cellFileInfo.FullName;
            string assetPath = fullname.Substring(fullname.IndexOf("Assets"));
            _objsList.Add(AssetDatabase.LoadAssetAtPath(assetPath, typeof(Object)));
        }
        BuildPipeline.BuildAssetBundle(null, _objsList.ToArray(), Application.dataPath + "/StreamingAssets/data/data.unity3D", BuildAssetBundleOptions.UncompressedAssetBundle, GetBuildTarget()); //把所有数据表打包到一个 assetbundle里
    }


    /*[MenuItem("MyMenu/SpriteToPerfab")]
    static private void MakePerfab()
    {
        string spriteDir = Application.dataPath + "/Resources/PerfabBindSprite";
        if (!Directory.Exists(spriteDir))
        {
            Directory.CreateDirectory(spriteDir);
        }

        DirectoryInfo rootDirInfo = new DirectoryInfo(Application.dataPath + "/IconsPackage/UI_DEMO2");
        foreach (DirectoryInfo dirInfo in rootDirInfo.GetDirectories())
        {
            foreach (FileInfo pngFile in dirInfo.GetFiles("*.png", SearchOption.AllDirectories))
            {
                string allPath = pngFile.FullName;
                string assetPath = allPath.Substring(allPath.IndexOf("Assets"));
                Sprite sprite = AssetDatabase.LoadAssetAtPath<Sprite>(assetPath);
                GameObject go = new GameObject(sprite.name);
                go.AddComponent<SpriteRenderer>().sprite = sprite;
                allPath = spriteDir + "/" + sprite.name + ".prefab";
                string prefabPath = allPath.Substring(allPath.IndexOf("Assets"));
                PrefabUtility.CreatePrefab(prefabPath, go);
                GameObject.DestroyImmediate(go);
            }
        }
    }*/
    /*[MenuItem("MyMenu/BuildSpriteToAssetBundle")]
    //把 图片资源打包成 assetbundle
    static private void BuildSpriteToAssetBundle()
    {
        string dir = Application.dataPath + "/StreamingAssets/UI/sprite";

        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }
        DirectoryInfo rootDirInfo = new DirectoryInfo(Application.dataPath + "/IconsPackage");
        foreach (DirectoryInfo dirInfo in rootDirInfo.GetDirectories())
        {
            List<Sprite> assets = new List<Sprite>();
            string path = dir + "/" + dirInfo.Name + ".assetbundle";
            foreach (FileInfo pngFile in dirInfo.GetFiles("*.png", SearchOption.AllDirectories))
            {
                string allPath = pngFile.FullName;
                string assetPath = allPath.Substring(allPath.IndexOf("Assets"));
                assets.Add(AssetDatabase.LoadAssetAtPath<Sprite>(assetPath));
            }
            if (BuildPipeline.BuildAssetBundle(null, assets.ToArray(), path, BuildAssetBundleOptions.UncompressedAssetBundle, GetBuildTarget()))
            {
                Debug.Log("build sprite to assetbundle success");
            }
        }
    }*/

    /*[MenuItem("MyMenu/BuildSpriteToAssetBundleOfAndroid")]
    //把 图片资源打包成 assetbundle
    static private void BuildSpriteToAssetBundleOfAndroid()
    {
        string dir = Application.dataPath + "/StreamingAssets/UI/sprite";

        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }
        DirectoryInfo rootDirInfo = new DirectoryInfo(Application.dataPath + "/IconsPackage");
        foreach (DirectoryInfo dirInfo in rootDirInfo.GetDirectories())
        {
            List<Sprite> assets = new List<Sprite>();
            string path = dir + "/" + dirInfo.Name + ".assetbundleAndroid";
            foreach (FileInfo pngFile in dirInfo.GetFiles("*.png", SearchOption.AllDirectories))
            {
                string allPath = pngFile.FullName;
                string assetPath = allPath.Substring(allPath.IndexOf("Assets"));
                assets.Add(AssetDatabase.LoadAssetAtPath<Sprite>(assetPath));
            }
            if (BuildPipeline.BuildAssetBundle(null, assets.ToArray(), path, BuildAssetBundleOptions.UncompressedAssetBundle, BuildTarget.Android))
            {
                Debug.Log("build sprite to assetbundle success");
            }
        }
    }*/
    static private BuildTarget GetBuildTarget()
    {
        BuildTarget target = BuildTarget.WebPlayer;
#if UNITY_STANDALONE
        target = BuildTarget.StandaloneWindows;
#elif UNITY_IPHONE
			target = BuildTarget.iPhone;
#elif UNITY_ANDROID
			target = BuildTarget.Android;
#endif
        return target;
    }


    //[MenuItem("MyMenu/BuildSelected")]
    static void ExportResource()
    {
        if (Selection.activeObject != null)
        {
            string path = AssetDatabase.GetAssetPath(Selection.activeObject);
            BuildFile(path);
        }
    }

    public static void BuildFile(string path)
    {
        //BuildActorMesh.AdjustObjInfo(path);
        string savePath = path.Replace("BuildRes", "StreamingAssets");
        savePath = savePath.Substring(0, savePath.LastIndexOf('.')) + ".unity3D";

        Object obj = AssetDatabase.LoadAssetAtPath(path, typeof(Object));
        string dir = Path.GetDirectoryName(savePath);
        Directory.CreateDirectory(dir);

#if UNITY_IPHONE
		BuildPipeline.BuildAssetBundle(obj, null, savePath,
			BuildAssetBundleOptions.CollectDependencies | BuildAssetBundleOptions.CompleteAssets, BuildTarget.iPhone);
#elif UNITY_WEBPLAYER
        BuildPipeline.BuildAssetBundle(obj, null, savePath,
            BuildAssetBundleOptions.CollectDependencies | BuildAssetBundleOptions.CompleteAssets, BuildTarget.WebPlayer);
#elif UNITY_ANDROID
		BuildPipeline.BuildAssetBundle(obj, null, savePath,
			BuildAssetBundleOptions.CollectDependencies | BuildAssetBundleOptions.CompleteAssets, BuildTarget.Android);
#else
		BuildPipeline.BuildAssetBundle(obj, null, savePath,
			BuildAssetBundleOptions.CollectDependencies | BuildAssetBundleOptions.CompleteAssets, BuildTarget.StandaloneWindows);
#endif
    }

    //自动打包图集,讲文件目录设置为打包标签
    public class AutoPackIcons : AssetPostprocessor
    {
        void OnPostprocessTexture(Texture2D texture)
        {
            string ap = Path.GetDirectoryName(assetPath);//将 iconspackage 下的图片进行自动打包
            if (ap.IndexOf("IconsPackage") != -1)
            {
                string AtlasName = new DirectoryInfo(ap).Name;
                //Debug.Log("autopack icons directory>>>>>>>>>>>>>>>>>>>>>>>>" + ap + " atlasName : " + AtlasName); 
                TextureImporter textureImporter = assetImporter as TextureImporter;
                textureImporter.textureType = TextureImporterType.Sprite;
                textureImporter.spritePackingTag = AtlasName;
                textureImporter.mipmapEnabled = false;
                textureImporter.textureFormat = TextureImporterFormat.ARGB32;
                //textureImporter.maxTextureSize
            }
        }
    }

}
