using LD47.GameStates;
using Tools.StateManager;
using UnityEngine;

namespace LD47.States
{
	public class UiState : PlayerState
	{
		public UiState(PlayerController player) : base(player){ }

		public override bool CanEnter(StateBase currentState)
		{
			return GameManager.Instance.StateManager.GetState().GetType() == typeof(PreGameState) ||
			       GameManager.Instance.StateManager.GetState().GetType() == typeof(MiniGameState);
		}

		public override bool CanExit()
		{
			return GameManager.Instance.StateManager.GetState().GetType() == typeof(WalkingGameState);
		}

		public override void OnEnterState()
		{
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
			player.CrosshairCanvas.SetActive(false);
			player.PlayerPointer.CanDetect = false;
		}

		public override void OnExitState()
		{
			//throw new System.NotImplementedException();
		}
	}
}