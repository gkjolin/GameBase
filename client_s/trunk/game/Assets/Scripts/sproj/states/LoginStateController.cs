using System;
namespace Game
{
	public class LoginStateController : StateController
	{
		public LoginStateController () : base () {
		}

		public static LoginStateController Register ()
		{
			LoginStateController retV = new LoginStateController ();
			StateController.Register (GameState.Login, retV, true);
			retV.AddTransition ((uint)GameState.Notice, GameState.Notice);
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

