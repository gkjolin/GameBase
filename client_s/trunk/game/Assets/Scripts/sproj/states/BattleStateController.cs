using System;
using UnityEngine;

using XingLuoTianXia.lib;

namespace Game
{
	public class BattleStateController : StateController
	{
		public GameObject Battle { get; set;}

		public BattleStateController () : base () {
		}

		public static BattleStateController Register ()
		{
			BattleStateController retV = new BattleStateController ();
			StateController.Register (GameState.Battle, retV, true);
			retV.AddTransition ((uint)GameState.PostBattle, GameState.PostBattle);
			return retV;
		}
		
		public override void OnEnter (object op)
		{
			base.OnEnter (op);
			InputControl.Instance.Activate ();
			GameEntry.Instance.Cameras.mainCamera = GameObject.Find ("Main Camera").GetComponent<Camera> ();
			Battle = new GameObject ("Battle");
			Battle.AddComponent<BattleController>();
			Battle.AddComponent<XingLuoTianXia.lib.TimerManager>();
		}
		
		public override void OnExit ()
		{
			base.OnExit ();
		}
	}
}

