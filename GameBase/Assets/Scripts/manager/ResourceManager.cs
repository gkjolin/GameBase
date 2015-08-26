using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
namespace Game
{
    public class ResourceManager
    {
        private static ResourceManager _instance;

        public static ResourceManager Instance
        {
            get { if (_instance == null) { _instance = new ResourceManager(); } return ResourceManager._instance; }
        }

        private AssetBundle ab_atlas_icon;
        private AssetBundle ab_atlas_ui;
        
        /// <summary>
        /// 动态更新图片， 打包版本使用
        /// </summary>
        /// <param name="name"></param>
        /// <param name="isIcon"></param>
        /// <returns></returns>
        public Sprite LoadSprite(string name, bool isIcon = true)
        {
            if (isIcon)
            {
                //不同平台的 路径设置要不一样
                if (ab_atlas_icon == null){
                    ab_atlas_icon = AssetBundle.CreateFromFile(Application.streamingAssetsPath + "/ui/sprite/UI_release.assetbundle"+GetPlatform());
                    ab_atlas_icon.Unload(false);
                }
                return ab_atlas_icon.LoadAsset(name, typeof(Sprite)) as Sprite;
            }
            else
            {
                if (ab_atlas_ui == null) ab_atlas_ui = AssetBundle.CreateFromFile(Application.streamingAssetsPath + "/ui/sprite/UI.assetbundle");
                return ab_atlas_ui.LoadAsset(name) as Sprite;
            }
        }

        /// <summary>
        /// 文本加载
        /// </summary>
        public string LoadTxtTable(string tableName)
        {
            /*TextAsset ta = Resources.Load("Data/"+tableName, typeof(TextAsset)) as TextAsset;  //notice 如果文本中有 中文， 编码格式改为 utf-8 才能显示  同步方法
            Debug.Log("loadtable content :"+ta.text);
            return ta.text;*/

            /*AssetBundle ab = AssetBundle.CreateFromFile(Application.streamingAssetsPath + "/data/" + tableName + ".unity3D");
            TextAsset ta = ab.mainAsset as TextAsset;
            return ta.text;*/
            if (ab_text == null)
            {
                ab_text = AssetBundle.CreateFromFile(Application.streamingAssetsPath + "/data/data.unity3D");
            }
            //AssetBundle ab = AssetBundle.CreateFromFile(Application.streamingAssetsPath + "/data/data.unity3D");
            TextAsset ta = ab_text.LoadAsset(tableName) as TextAsset;
            return ta.text;
        }

        private AssetBundle ab_text;

        //start batch load asset
        private List<string> _list = new List<string>();
        private int asset_length;
        private int progress;
        public void BatchLoadAsset()
        {
            asset_length = _list.Count;
            progress = 0;
            for (int i = 0; i < asset_length; i++)
            {
                string assetName = _list[i];
                UIEffectManager.Instance.LoadUIEffect(assetName, BatchLoadComplete);
            }
            //_list.Clear();
        }

        private void BatchLoadComplete(GameObject go)
        {
            Debug.Log("load progress : " + (progress++) + "  /  " + asset_length);
            UILoading.Instance.SetBarProgress(progress / asset_length, delegate { Debug.Log("load complete >>>>>>>>>>>>>>>"); });
        }

        public void AddAssetToQueue(string name)
        {
            if (_list.Contains(name) == false)
            {
                _list.Add(name);
            }
        }

        public void TestBatchLoad()
        {
            UILoading.Instance.StartShow();
            AddAssetToQueue("EffectDiamond");
            BatchLoadAsset();
        }

        public string GetPath()
        {
            //jar:file:///data/app/xxx.xxx.xxx.apk/!/assets
            //Application/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/xxx.app/Data/Raw
            return "";
        }


        public string GetPlatform()
        {
            string ext="";
#if UNITY_STANDALONE
            ext = "";
#elif UNITY_IPHONE
            ext = "IOS";
#elif UNITY_ANDROID
            ext = "Android";
#endif
            return ext;
        }

        public GameObject LoadNewPrefab(string prefabName, Transform parent=null)
        {
            GameObject go = GameObject.Instantiate(Resources.Load("Prefabs/" + prefabName)) as GameObject;
            if (parent!=null)
            {
                go.transform.SetParent(parent);
                go.transform.localPosition = Vector3.zero;
                go.transform.localScale = Vector3.one;
            }
            return go;
        }
    }
}
