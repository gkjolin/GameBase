using System;
using System.Collections.Generic;
namespace Game
{
	[Flags]
	public enum GameState : uint {
		PreProcess,
		Init,
		Login,
		Notice,
		MainMenu,
		PreBattle,
		Battle,
		PostBattle,
		InTransition,
		CriticalError,
		ExitFinalize,
		_All = 0xFFFFFFFF,
		_AsyncTransition = 0x80000000
	}

	public interface IStateController {
		void AddTransition (uint condition, GameState target);
		void OnEnter (object op);
		bool Check (uint conditions, out uint target);
		void OnExit ();
	}

	public class StateController : IStateController
	{
		private static IStateController _current;
		public static IStateController _Current {get{return _current;}}
		private static Dictionary<GameState, IStateController> _states;

		protected uint _validTransitions;
		protected Dictionary<uint, GameState> _targets;

		protected StateController ()
		{
			_validTransitions = (uint)GameState._All;
			_targets = new Dictionary<uint, GameState> (4);
		}

		public static void Start (GameState initState) {
			_current = _states [initState];
			_current.OnEnter (null);
		}

		public static void Register (GameState s, IStateController sc, bool shouldReserve)
		{
			if (_states == null) _states = new Dictionary<GameState, IStateController> (16);
			_states.Add (s, sc);
		}

		public static bool Condition(uint c) {
			return Condition (c, null, null);
		}
		public static bool Condition (uint c, object op) {
			return Condition (c, op, null);
		}
		public static bool Condition (uint c, object op, object prog) {
			if (_current is InTransitionStateController) {
				_current.OnExit ();
				_current = _states[(GameState)c];
				_current.OnEnter(op);
				return true;
			}
			bool asyncTrans = (c & (uint)GameState._AsyncTransition) != 0;
			if (asyncTrans) c -= (uint)GameState._AsyncTransition;
			//UnityEngine.Debug.Log ("condition : " + (GameState)c + " : " + asyncTrans);
			uint t;
			bool retV = _current.Check (c, out t);
			UnityEngine.Debug.Log ("condition : " + (GameState)c + " : " + retV + " : switch to " + (GameState)t);
			if (retV) {
				_current.OnExit ();
				if (asyncTrans) {
					_current = _states[GameState.InTransition];
					(_current as InTransitionStateController).Target = t;
					(_current as InTransitionStateController).Progress = prog as IAsyncProgress;
					_current.OnEnter (op);
				} else {
					_current = _states[(GameState)t];
					_current.OnEnter(op);
				}
			} else 
				throw new InvalidOperationException ("unable to transit from " + _current.GetType () + " with conditions " + (GameState)c);
			return retV;
		}

		public static S Current<S> () where S : class, IStateController {
			return _current as S;
		}

		public virtual void AddTransition (uint condition, GameState target) {
			_validTransitions |= condition;
			_targets.Add (condition, target);
		}

		public virtual void OnEnter (object op)
		{

		}

		public virtual bool Check (uint conditions, out uint target)
		{
			bool retV = (_validTransitions & conditions) == conditions;
			if (retV) target = (uint)_targets [conditions]; else throw new InvalidOperationException("No target for condition " + (GameState)conditions);
			return retV;
		}

		public virtual void OnExit ()
		{

		}

		[System.Diagnostics.Conditional("DEBUG")]
		public void ForceTransitTo ()
		{

		}
	}
}

