using System;
namespace Game
{
	public class ExitFinalizeStateController : StateController
	{
		public ExitFinalizeStateController () : base () {
		}

		public static ExitFinalizeStateController Register ()
		{
			ExitFinalizeStateController retV = new ExitFinalizeStateController ();
			StateController.Register (GameState.ExitFinalize, retV, false);
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

