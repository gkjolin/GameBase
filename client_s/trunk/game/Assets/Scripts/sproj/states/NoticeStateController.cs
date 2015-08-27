using System;
namespace Game
{
	public class NoticeStateController : StateController
	{
		public NoticeStateController () : base () {
		}

		public static NoticeStateController Register ()
		{
			NoticeStateController retV = new NoticeStateController ();
			StateController.Register (GameState.Notice, retV, true);
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

