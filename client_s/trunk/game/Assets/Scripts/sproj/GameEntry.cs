using System;
using UnityEngine;

using XingLuoTianXia.lib;

namespace Game
{
	//represents the game application domain
	//domain level controls & info are put here
	[RequireComponent(typeof (CameraControl))]
	public class GameEntry : MonoBehaviour
	{
		private static GameEntry _self;
		public static GameEntry Instance {get{return _self;}}

		public CameraControl Cameras { get; set;}

		void Awake ()
		{
			_self = this;
			DontDestroyOnLoad (gameObject);

#region Appilcation settings
			Application.targetFrameRate = 60;
#endregion Application settings

            // 初始化字典管理器
            XLDictionaryMgr.getInstance();

#if false
            string text = null;
            text = BbbDictionary.SS0;
            text = AaaDictionary.TEST0;

            text = XLDictionaryMgr.getInstance().getTextById(10001);

            int a = 0;
            a++;
#endif

			#region Runtime setup
			StatesInit ();
			ExternalResources.Instance.CrExe = this;
			Cameras = GetComponent<CameraControl> ();
#if DEBUG
			gameObject.AddComponent<XLFpsDebug> ();
#endif
			InitUI ();
			#endregion Runtime setup

			StateController.Start (GameState.PreProcess);
			StateController.Condition ((uint)GameState.Init);
			StateController.Condition ((uint)GameState.Login);
			StateController.Condition ((uint)GameState.Notice);
			StateController.Condition ((uint)GameState.MainMenu);
		}

		void Start ()
		{
			InputControl.Instance.Deactivate();
		}

		#region StatesInit
		void StatesInit ()
		{
			PreProcessStateController.Register ();
			InitStateController.Register ();
			LoginStateController.Register ();
			NoticeStateController.Register ();
			MainMenuStateController.Register ();
			PreBattleStateController.Register ();
			BattleStateController.Register ();
			PostBattleStateController.Register ();
			InTransitionStateController.Register ();
			CriticalErrorStateController.Register ();
			ExitFinalizeStateController.Register ();
		}
		#endregion StatesInit

		#region Init UI
		void InitUI ()
		{
			//添加面板
			UIManager.getInstance().addPanel(PanelConfig.GAMEPANEL);//游戏中界面
			UIManager.getInstance().addPanel(PanelConfig.PAUSEPANEL);//暂停面板
			UIManager.getInstance().addPanel(PanelConfig.VICTORYPANEL);//胜利面板
			UIManager.getInstance().addPanel(PanelConfig.FAILEDPANEL);//失败面板
			UIManager.getInstance().addPanel(PanelConfig.HOMECITYPANEL);//主城界面
			UIManager.getInstance().addPanel(PanelConfig.WORLDMAPPANEL);//世界地图界面
			UIManager.getInstance().addPanel(PanelConfig.PROGRESSPANEL);
			
			DontDestroyOnLoad(UIManager.getInstance().getPanel(PanelConfig.GAMEPANEL));//游戏中界面
			DontDestroyOnLoad(UIManager.getInstance().getPanel(PanelConfig.PAUSEPANEL));//暂停面板
			DontDestroyOnLoad(UIManager.getInstance().getPanel(PanelConfig.VICTORYPANEL));//胜利面板
			DontDestroyOnLoad(UIManager.getInstance().getPanel(PanelConfig.FAILEDPANEL));//失败面板
			DontDestroyOnLoad(UIManager.getInstance().getPanel(PanelConfig.HOMECITYPANEL));//主城界面
			DontDestroyOnLoad(UIManager.getInstance().getPanel(PanelConfig.WORLDMAPPANEL));//世界地图界面
			DontDestroyOnLoad(UIManager.getInstance().getPanel(PanelConfig.PROGRESSPANEL));
			
			DontDestroyOnLoad(this.gameObject);
			DontDestroyOnLoad(GameObject.Find("Canvas"));
			DontDestroyOnLoad(GameObject.Find("UICamera"));
			DontDestroyOnLoad(GameObject.Find("EventSystem"));
			
			UIManager.getInstance().openPanel(PanelConfig.HOMECITYPANEL);
		}
		#endregion InitUI
	}
}

