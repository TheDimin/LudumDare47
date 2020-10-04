using System.Collections;
using System.Collections.Generic;
using Tools.StateManager;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LD47.GameStates
{
    public class PreGameState : GameStateBase
    {
        private bool canTransAction = false;


        public override void OnEnterState()
        {
            canTransAction = false;
            SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);

            //TODO blur screen
        }

        public override void OnExitState()
        {
            SceneManager.UnloadSceneAsync(1);
        }

        public void EnterGame()
        {
            canTransAction = true;
        }

        public override bool CanEnter(StateBase currentStateBase)
        {
            return currentStateBase == null;
        }

        public override bool CanExit()
        {
            return canTransAction;
        }
    }
}
