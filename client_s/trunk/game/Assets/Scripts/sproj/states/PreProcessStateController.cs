using System;
namespace Game
{
	public class PreProcessStateController : StateController
	{
		protected PreProcessStateController () : base () {
		}

		public static PreProcessStateController Register ()
		{
			PreProcessStateController retV = new PreProcessStateController ();
			StateController.Register (GameState.PreProcess, retV, false);
			retV.AddTransition ((uint)GameState.Init, GameState.Init);
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

