using System;
using System.Collections;
using UnityEngine;
namespace Game
{
	public class MainMenuStateController : StateController
	{
		public MainMenuStateController () : base () {
		}

		public static MainMenuStateController Register ()
		{
			MainMenuStateController retV = new MainMenuStateController ();
			StateController.Register (GameState.MainMenu, retV, true);
			retV.AddTransition ((uint)GameState.PreBattle, GameState.PreBattle);
			retV.AddTransition ((uint)GameState.InTransition, GameState.InTransition);
			return retV;
		}
		
		public override void OnEnter (object op)
		{
			base.OnEnter (op);
		}
		
		public override void OnExit ()
		{
			base.OnExit ();
		}

		public void SwitchScene (string id)
		{
			Game.IAsyncProgress prog = Game.ExternalResources.Instance.Cache (id, Game.ResCategory.Scene, SceneLoaded);
			StateController.Condition ((uint)(GameState.PreBattle | GameState._AsyncTransition), null, prog);
		}

		void SceneLoaded (string id)
		{
			GameEntry.Instance.StartCoroutine (LoadScene(id));
		}
		
		IEnumerator LoadScene (string id)
		{
			yield return Application.LoadLevelAsync(id);
			StateController.Current<InTransitionStateController> ().Continue ();
		}
	}
}

