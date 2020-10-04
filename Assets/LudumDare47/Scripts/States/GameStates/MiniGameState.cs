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
            throw new System.NotImplementedException();
        }

        public override bool CanEnter(StateBase currentStateBase)
        {
            throw new System.NotImplementedException();
        }

        public override bool CanExit()
        {
            throw new System.NotImplementedException();
        }
    }
}