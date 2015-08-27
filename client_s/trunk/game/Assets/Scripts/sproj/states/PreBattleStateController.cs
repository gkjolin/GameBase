using System;
namespace Game
{
	public class PreBattleStateController : StateController
	{
		public PreBattleStateController () : base () {
		}

		public static PreBattleStateController Register ()
		{
			PreBattleStateController retV = new PreBattleStateController ();
			StateController.Register (GameState.PreBattle, retV, true);
			retV.AddTransition ((uint)GameState.Battle, GameState.Battle);
			return retV;
		}
		
		public override void OnEnter (object op)
		{
			base.OnEnter (op);
			StateController.Condition ((uint)GameState.Battle);
		}
		
		public override void OnExit ()
		{
			base.OnExit ();
		}
	}
}

