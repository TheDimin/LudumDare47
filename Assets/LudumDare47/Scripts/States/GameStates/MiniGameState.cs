using Cinemachine;
using LD47.Minigame;
using Tools.StateManager;
using UnityEngine;

namespace LD47.GameStates
{
    public class MiniGameState : GameStateBase
    {
        public override void OnEnterState()
        {
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
            return PCController.Instance.pcStateManager.GetState().GetType() == typeof(PCPlayState);
        }

        public override bool CanExit()
        {
            return PCController.Instance.pcStateManager.GetState().GetType() != typeof(PCPlayState);
        }
    }
}