using System;
namespace Game
{
	public class CriticalErrorStateController : StateController
	{
		public CriticalErrorStateController () : base () {
		}

		public static CriticalErrorStateController Register ()
		{
			CriticalErrorStateController retV = new CriticalErrorStateController ();
			StateController.Register (GameState.CriticalError, retV, false);
			retV.AddTransition ((uint)GameState.ExitFinalize, GameState.ExitFinalize);
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

