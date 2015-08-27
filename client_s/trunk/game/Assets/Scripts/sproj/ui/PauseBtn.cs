using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
public class PauseBtn : MonoBehaviour
{
//     public GameObject _pauseMenu;
// 
//     public GameObject _victoryMenu;
// 
//     public GameObject _FailedMenu;
// 
//     //public Audio _audio;
// 
//     public List<Button> _HeroIconBtns;
// 
//     //游戏是否暂停
//     public bool isPause = false;
// 
//     public void Start()
//     {
//         _pauseMenu.SetActive(false);
//     }
// 
//     //public void FixedUpdate()
//     //{
//     //    if (!isPause)
//     //    {
//     //        Time.timeScale = 0;
//     //        isPause = true;
//     //        _pauseMenu.SetActive(true);
// 
//     //        _audio.pause();
//     //        //_HeroIconBtns.interactable = false;
//     //        for (int i = 0; i < _HeroIconBtns.Count; i++)
//     //        {
//     //            _HeroIconBtns[i].interactable = false;
//     //        }
// 
//     //        SpriteMgr.getInstance().pause();
//     //    }
// 
//     //    else
//     //    {
//     //        Time.timeScale = 1;
//     //        isPause = false;
//     //        _pauseMenu.SetActive(false);
// 
//     //        _audio.UnPause();
//     //        for (int i = 0; i < _HeroIconBtns.Count; i++)
//     //        {
//     //            _HeroIconBtns[i].interactable = true;
//     //        }
//     //        //_HeroIconBtns.interactable = true;
// 
//     //        SpriteMgr.getInstance().resume();
//     //    }
// 
//     //}
// 
// 
//     //暂停/恢复游戏的方法
// 
// 
//     //    IEnumerator DownloadAssetAndScene()
//     //    {
//     //        //下载assetbundle，加载Cube  
//     ////         using (WWW asset = new WWW(BundleURL))
//     ////         {
//     ////             yield return asset;
//     ////             AssetBundle bundle = asset.assetBundle;
//     ////             Instantiate(bundle.Load("Cube"));
//     ////             bundle.Unload(false);
//     ////             yield return new WaitForSeconds(5);
//     ////         }
// 
//     //        //下载场景，加载场景  
//     //        // string SceneURL = "file:///C:/scene1.unity3d";  
//     //        string SceneURL = "file:///D:/workspace_company_xltx/svn/s/client/trunk/game/Assets/_tempAssetBundle/PathfindingTest.unity3d";
//     //        using (WWW scene = new WWW(SceneURL))
//     //        {
//     //            yield return scene;
//     //            AssetBundle bundle = scene.assetBundle;
//     //            Application.LoadLevel("scene1");
//     //        }
//     //    }  
// 
//     public void Resume()
//     {
//         // TODO cjc-debug:
//         //    IList<XLSpriteBase> selfs = SpriteMgr.getInstance().SelfSoldiers;
//         //    for (int i = 0; i < selfs.Count; i++)
//         //    {
//         //        (selfs[i] as PathfindingSprite).setFindEnemyState();
//         //    }
//         //    IList<XLSpriteBase> enemys = SpriteMgr.getInstance().EnemySoldiers;
//         //    for (int i = 0; i < enemys.Count; i++)
//         //    {
//         //        (enemys[i] as PathfindingSprite).setFindEnemyState();
//         //    }
//         //    if(true)
//         //    {
//         //        return;
//         //    }
// 
//         // TODO cjc-debug:更换场景
//         //         if(true)
//         //         {
//         //             // DownloadAssetAndScene();
//         // 
//         //             string SceneURL = "file:///D:/workspace_company_xltx/svn/s/client/trunk/game/Assets/_tempAssetBundle/ShiYan001.unity3d";
//         //             using (WWW scene = new WWW(SceneURL))
//         //             {
//         //                 AssetBundle bundle = scene.assetBundle;
//         //                 Application.LoadLevel("ShiYan001");
//         //             }
//         //             return;
//         //         }
// 
//         if (!isPause)
//         {
//             Time.timeScale = 0;
//             isPause = true;
//             _pauseMenu.SetActive(true);
// 
//             //_audio.pause();
//             //_HeroIconBtns.interactable = false;
// 
//             for (int i = 0; i < _HeroIconBtns.Count; i++)
//             {
//                 _HeroIconBtns[i].interactable = false;
//             }
// 
//             SpriteMgr.getInstance().pause();
//         }
//         else
//         {
//             Time.timeScale = 1;
//             isPause = false;
//             _pauseMenu.SetActive(false);
// 
//             //_audio.UnPause();
//             for (int i = 0; i < _HeroIconBtns.Count; i++)
//             {
//                 _HeroIconBtns[i].interactable = true;
//             }
//             //_HeroIconBtns.interactable = true;
// 
//             SpriteMgr.getInstance().resume();
//         }
//     }

}
