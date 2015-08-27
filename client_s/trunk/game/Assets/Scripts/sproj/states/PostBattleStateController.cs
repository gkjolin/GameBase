using System;
namespace Game
{
	public class PostBattleStateController : StateController
	{
		public PostBattleStateController () : base () {
		}

		public static PostBattleStateController Register ()
		{
			PostBattleStateController retV = new PostBattleStateController ();
			StateController.Register (GameState.PostBattle, retV, true);
			retV.AddTransition ((uint)GameState.MainMenu, GameState.MainMenu);
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
	}
}

