using System;
using XingLuoTianXia.lib;
namespace Game
{
	public class InTransitionStateController : StateController
	{
		public uint Target { get; set;}
		public IAsyncProgress Progress { get; set; }
		private object _op;

		public InTransitionStateController () : base () {
		}

		public static InTransitionStateController Register ()
		{
			InTransitionStateController retV = new InTransitionStateController ();
			StateController.Register (GameState.InTransition, retV, true);
			return retV;
		}

		public void Continue ()
		{
			StateController.Condition (Target, _op);
		}
		
		public override void OnEnter (object op)
		{
			_op = op;
			ProgressPanel pp = UIManager.getInstance ().getPanel (PanelConfig.PROGRESSPANEL) as ProgressPanel;
			pp.ProgressObj (Progress);
			UIManager.getInstance ().openPanel (PanelConfig.PROGRESSPANEL);
			base.OnEnter (op);
		}

		public override bool Check (uint conditions, out uint target)
		{
			target = conditions;
			return true;
		}
		
		public override void OnExit ()
		{
			UIManager.getInstance ().closePanel (PanelConfig.PROGRESSPANEL);
			base.OnExit ();
		}
	}
}

