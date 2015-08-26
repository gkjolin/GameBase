using UnityEngine;
using System.Collections;
using UnityEditor;
using UnityEditorInternal;
using System.IO;
public class ExportAssetbundles : MonoBehaviour
{
    //将资源打包为 assetbundle
    [MenuItem("Tools/Build AssetBundle form selection")]
    static void ExportAsset()
    {
        //打开保存面板，选择保存路径
        string path = EditorUtility.SaveFilePanel("Save Resource", "", "New Resource", "unity3D");
        if (path.Length != 0)
        {
            //选择要保存的对象
            Object[] selection = Selection.GetFiltered(typeof(Object), SelectionMode.DeepAssets);
            //对选择的对象 进行打包
            BuildPipeline.BuildAssetBundle(Selection.activeObject, selection, path,
                       BuildAssetBundleOptions.CollectDependencies | BuildAssetBundleOptions.CompleteAssets, BuildTarget.StandaloneWindows);
        }
    }
    //打包场景scene bug
    [MenuItem("Tools/Save Scene")]
    static void ExportScene()
    {
        string path = EditorUtility.SaveFilePanel("Save scene", "", "New Resource", "unity3d");
        if (path.Length != 0)
        {
            //选择要保存的对象
            Object[] selection = Selection.GetFiltered(typeof(Object), SelectionMode.DeepAssets);
            string[] scenes = { "Assets/scene1.unity" };
            //打包
            BuildPipeline.BuildPlayer(scenes, path, BuildTarget.StandaloneWindows, BuildOptions.BuildAdditionalStreamedScenes);
        }
    }

    /// <summary>
    /// 创建animatorController
    /// </summary>
    /*[MenuItem("Tools/CreatAnimationAssets")]
    static void DoCreateAnimationAssets()
    {
        //创建animationController文件，保存在Assets路径下
        UnityEditor.Animations.AnimatorController animatorController = UnityEditor.Animations.AnimatorController.CreateAnimatorControllerAtPath("Assets/animation.controller");
        //得到它的Layer， 默认layer为base 你可以去拓展
        UnityEditor.Animations.AnimatorControllerLayer layer = animatorController.GetLayer(0);
        //把动画文件保存在我们创建的AnimationController中
        AddStateTransition("Assets/Resources/airenlieren@Idle.FBX", layer);
        AddStateTransition("Assets/Resources/attack@attack.FBX", layer);
        AddStateTransition("Assets/Resources/aersasi@Run.FBX", layer);
    }*/

    /*private static void AddStateTransition(string path, UnityEditor.Animations.AnimatorControllerLayer layer)
    {
        UnityEditor.Animations.AnimatorStateMachine sm = layer.stateMachine;
        //根据动画文件读取它的AnimationClip对象
        AnimationClip newClip = AssetDatabase.LoadAssetAtPath(path, typeof(AnimationClip)) as AnimationClip;
        //取出动画名子 添加到state里面
        UnityEditor.Animations.AnimatorState state = sm.AddState(newClip.name);
        state.SetAnimationClip(newClip, layer);
        //把state添加在layer里面
        UnityEditor.Animations.AnimatorTransition trans = sm.AddAnyStateTransition(state);
        //把默认的时间条件删除
        trans.RemoveCondition(0);
    }*/

    //Create Assetbundles Main : 分开打包，会生成两个Assetbundle
    [MenuItem("Tools/Create AssetBunldes Main")]
    static void CreateAssetBunldesMain()
    {
        //获取在Project视图中选择的所有游戏对象
        Object[] SelectedAsset = Selection.GetFiltered(typeof(Object), SelectionMode.DeepAssets);

        //遍历所有的游戏对象
        foreach (Object obj in SelectedAsset)
        {
            string sourcePath = AssetDatabase.GetAssetPath(obj);
            //本地测试：建议最后将Assetbundle放在StreamingAssets文件夹下，如果没有就创建一个，因为移动平台下只能读取这个路径
            //StreamingAssets是只读路径，不能写入
            //服务器下载：就不需要放在这里，服务器上客户端用www类进行下载。
            string targetPath = Application.dataPath + "/StreamingAssets/" + obj.name + ".assetbundle";
            if (BuildPipeline.BuildAssetBundle(obj, null, targetPath, BuildAssetBundleOptions.CollectDependencies))
            {
                Debug.Log(obj.name + "资源打包成功");
            }
            else
            {
                Debug.Log(obj.name + "资源打包失败");
            }
        }
        //刷新编辑器
        AssetDatabase.Refresh();
    }

    //Create AssetBundles All：将所有对象打包在一个Assetbundle中
    //[MenuItem("Custom Editor/Create AssetBunldes ALL")]
    static void CreateAssetBunldesALL()
    {

        Caching.CleanCache();

        string Path = Application.dataPath + "/StreamingAssets/ALL.assetbundle";

        Object[] SelectedAsset = Selection.GetFiltered(typeof(Object), SelectionMode.DeepAssets);

        foreach (Object obj in SelectedAsset)
        {
            Debug.Log("Create AssetBunldes name :" + obj);
        }

        //这里注意第二个参数就行
        if (BuildPipeline.BuildAssetBundle(null, SelectedAsset, Path, BuildAssetBundleOptions.CollectDependencies))
        {
            AssetDatabase.Refresh();
        }
        else
        {

        }
    }

    //读取一个资源
    private IEnumerator LoadMainGameObject(string path)
    {
        WWW bundle = new WWW(path);

        yield return bundle;

        //加载到游戏中
        yield return Instantiate(bundle.assetBundle.mainAsset);

        bundle.assetBundle.Unload(false);
    }

    //读取全部资源
    private IEnumerator LoadALLGameObject(string path)
    {
        WWW bundle = new WWW(path);

        yield return bundle;

        //通过Prefab的名称把他们都读取出来
        Object obj0 = bundle.assetBundle.LoadAsset("Prefab0");
        Object obj1 = bundle.assetBundle.LoadAsset("Prefab1");

        //加载到游戏中	
        yield return Instantiate(obj0);
        yield return Instantiate(obj1);
        bundle.assetBundle.Unload(false);
    }
    /// <summary>
    /// 服务器或者本地下载地址   版本号
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    private IEnumerator LoadMainCacheGameObject(string path)
    {
        WWW bundle = WWW.LoadFromCacheOrDownload(path, 5);

        yield return bundle;

        //加载到游戏中
        yield return Instantiate(bundle.assetBundle.mainAsset);

        bundle.assetBundle.Unload(false);
    }
    //打包场景
    [MenuItem("Tools/CreateScene")]
    static void CreateSceneALL()
    {
        //清空一下缓存
        Caching.CleanCache();
        string Path = Application.dataPath + "/MyScene.unity3d";
        string[] levels = { "Assets/scene1.unity" };
        //打包场景
        BuildPipeline.BuildPlayer(levels, Path, BuildTarget.WebPlayer, BuildOptions.BuildAdditionalStreamedScenes);
        AssetDatabase.Refresh();
    }

    //异步加载场景
    private IEnumerator LoadScene()
    {
        WWW download = WWW.LoadFromCacheOrDownload("file://" + Application.dataPath + "/MyScene.unity3d", 1);//异步方法
        yield return download;
        var bundle = download.assetBundle;
        Application.LoadLevel("Level");
    }
    //同步加载
    private void LoadSceneSync()
    {
        var bundle = AssetBundle.CreateFromFile("file://" + Application.dataPath + "/MyScene.unity3d");
        Application.LoadLevel("Level");
    }

    //打包的时候需要选择不压缩
    /*因为不压缩， 所以就需要我们自己来压缩资源了， 可以用LZMA 和 GZIP来进行压缩。
    1.打包出来的Assetbundle我们自己用LZMA压缩，上传到服务器上。
    2.IOS或者Android下载这些assetbundle
    3.解压缩这些assetbundle并且保存在Application.persistentDataPath 目录下。
    4.以后通过AssetBundle.CreatFromFile  读取assetbundle。*/
    //打包场景
    //BuildPipeline.BuildStreamedSceneAssetBundle(levels, path, target, BuildOptions.UncompressedAssetBundle))
    //打包资源
    //BuildPipeline.BuildAssetBundle(null, assets, path, BuildAssetBundleOptions.UncompressedAssetBundle | BuildAssetBundleOptions.CollectDependencies, target);


    [MenuItem("Tools/GetFilteredtoAnim", true)]
    static bool NotGetFiltered()
    {
        return Selection.activeObject;
    }


    [MenuItem("Tools/GetFilteredtoAnim")]
    static void GetFiltered()
    {
        string targetPath = Application.dataPath + "/AnimationClip";
        if (!Directory.Exists(targetPath))
        {
            Directory.CreateDirectory(targetPath);
        }
        Object[] SelectionAsset = Selection.GetFiltered(typeof(Object), SelectionMode.Unfiltered);
        Debug.Log(SelectionAsset.Length);
        foreach (Object Asset in SelectionAsset)
        {
            AnimationClip newClip = new AnimationClip();
            EditorUtility.CopySerialized(Asset, newClip);
            AssetDatabase.CreateAsset(newClip, "Assets/AnimationClip/" + Asset.name + ".anim");
        }
        AssetDatabase.Refresh();
    }
    [MenuItem("Tools/ImportAssets")]
    static void ImportAssset()
    {
        //AssetDatabase.ImportAsset("Assets/prefabs/MyCube.prefab", ImportAssetOptions.Default);
        //AssetDatabase.RenameAsset("Assets/prefabs/MyCubeNew.prefab", "MyCube");//重命名
        /*AnimationClip newClip = new AnimationClip();
        AssetDatabase.CreateAsset(newClip, "Assets/clip.anim");*/
    }
}
