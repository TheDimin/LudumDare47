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
        }

        public override void OnExitState()
        {
            
        }

        public override bool CanEnter(StateBase currentStateBase)
        {
            return PCController.Instance.pcStateManager.GetState().GetType() == typeof(PCPlayState);
        }

        public override bool CanExit()
        {
            throw new System.NotImplementedException();
        }
    }
}