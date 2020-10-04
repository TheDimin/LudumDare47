using Tools.StateManager;
using UnityEngine;

namespace LD47.States
{
	public class LockedState : PlayerState
	{
		public LockedState(PlayerController player) : base(player){ }

		public override bool CanEnter(StateBase currentStateBase)
		{
			throw new System.NotImplementedException();
		}

		public override bool CanExit()
		{
			throw new System.NotImplementedException();
		}

		public override void OnEnterState()
		{
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}

		public override void OnExitState()
		{
			throw new System.NotImplementedException();
		}
	}
}