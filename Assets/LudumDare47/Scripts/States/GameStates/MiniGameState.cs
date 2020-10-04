using Cinemachine;
using LD47.Minigame;
using Tools.StateManager;
using UnityEngine;

namespace LD47.GameStates
{
    public class MiniGameState : GameStateBase
    {
        private StateManagerBase<PCState> pcState;

        public override void OnEnterState()
        {
            if (pcState == null)
                pcState = PCController.Instance.pcStateManager;
            
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            gameManager.Player.GetComponentInChildren<CinemachineVirtualCamera>().gameObject.SetActive(false);

        }

        public override void OnExitState()
        {
            gameManager.Player.GetComponentInChildren<CinemachineVirtualCamera>().gameObject.SetActive(true);
        }

        public override bool CanEnter(StateBase currentStateBase)
        {
            return pcState.GetState().GetType() == typeof(PCPlayState);
        }

        public override bool CanExit()
        {
            return pcState.GetState().GetType() != typeof(PCPlayState);
        }
    }
}