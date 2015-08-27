using System;
namespace Game
{
	public class InitStateController : StateController
	{
		public InitStateController () : base () {
		}

		public static InitStateController Register ()
		{
			InitStateController retV = new InitStateController ();
			StateController.Register (GameState.Init, retV, false);
			retV.AddTransition ((uint)GameState.Login, GameState.Login);
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

