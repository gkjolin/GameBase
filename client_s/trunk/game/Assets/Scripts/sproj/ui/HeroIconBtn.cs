using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine.UI;

public class HeroIconBtn : MonoBehaviour
{

//     public GameObject _pauseMenu;
//         //public GameObject _victoryMenu;
//         //public GameObject _FailedMenu;
//     
//         public List<Button> _HeroIconBtns;
//     
//         //游戏是否暂停
//         public bool isPause = false;
//     
//         /// <summary>
//         /// 单例
//         /// </summary>
//         private static HeroIconBtn _instance = null;
//     
//         public static HeroIconBtn getInstance()
//         {
//             if (_instance == null)
//             {
//                 _instance = new HeroIconBtn();
//             }
//             return _instance;
//         }
//     
//     
//         void Start()
//         {
//             //_pauseMenu.SetActive(false);
//             //创建容器
//             List<string> btnsName = new List<string>();
//             //通过按钮名向容器内添加按钮
//             btnsName.Add("HeroBtnPre_1");
//             btnsName.Add("HeroBtnPre_2");
//             btnsName.Add("HeroBtnPre_3");
//             btnsName.Add("HeroBtnPre_4");
//             btnsName.Add("HeroBtnPre_5");
//             btnsName.Add("HeroBtnPre_6");
//             btnsName.Add("AutoBattleBtn");
//             btnsName.Add("TaskListBtn");
//             btnsName.Add("PauseBtnPre");
//             //遍历容器
//             foreach (string btnName in btnsName)
//             {
//                 //通过按钮名称获取按钮
//                 GameObject btnObj = GameObject.Find(btnName);
//                 Button btn = btnObj.GetComponent<Button>();
//     
//                 btn.onClick.AddListener(delegate()
//                 {
//                     this.OnClick(btnObj);
//                 });
//             }
//         }
//         //通过按钮名称为按钮添加点击事件
//         public void OnClick(GameObject sender)
//         {
//             switch (sender.name)
//             {
//                 case "HeroBtnPre_1":
//                     Debug.Log("HeroBtnPre_1");
//                     break;
//                 case "HeroBtnPre_2":
//                     Debug.Log("HeroBtnPre_2");
//                     break;
//                 case "HeroBtnPre_3":
//                     Debug.Log("HeroBtnPre_3");
//                     break;
//                 case "HeroBtnPre_4":
//                     Debug.Log("HeroBtnPre_4");
//                     break;
//                 case "HeroBtnPre_5":
//                     Debug.Log("HeroBtnPre_5");
//                     break;
//                 case "HeroBtnPre_6":
//                     Debug.Log("HeroBtnPre_6");
//                     break;
//                 case "AutoBattleBtn":
//                     Debug.Log("AutoBattleBtn");
//                     break;
//                 case "TaskListBtn":
//                     Debug.Log("TaskListBtn");
//                     break;
//                 case "PauseBtnPre":
//                     Resume();
//                     break;
//     
//                 default:
//                     Debug.Log("none");
//                     break;
//             }
//         }
//     
//     
//         public void Resume()
//         {
//             if (!isPause)
//             {
//                 Time.timeScale = 0;
//                 isPause = true;
//     
//                 UIManager.getInstance().openPanel("PausePanel");
//                 //_pauseMenu.SetActive(true);
//     
//                 //_audio.pause();
//                 //_HeroIconBtns.interactable = false;
//     
//                 for (int i = 0; i < _HeroIconBtns.Count; i++)
//                 {
//                     _HeroIconBtns[i].interactable = false;
//                 }
//     
//                 SpriteMgr.getInstance().pause();
//     
//             }
//             else
//             {
//                 Time.timeScale = 1;
//                 isPause = false;
//     
//                 //_pauseMenu.SetActive(false);
//                 UIManager.getInstance().closePanel("PausePanel");
//                 //_audio.UnPause();
//                 for (int i = 0; i < _HeroIconBtns.Count; i++)
//                 {
//                     _HeroIconBtns[i].interactable = true;
//                 }
//                 //_HeroIconBtns.interactable = true;
//     
//                 SpriteMgr.getInstance().resume();
//             }
//         }
}