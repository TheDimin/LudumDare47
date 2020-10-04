using System.Collections;
using System.Collections.Generic;
using LD47.Minigame;
using Tools.StateManager;
using UnityEngine;

namespace LD47.GameStates
{
    public class WalkingGameState : GameStateBase
    {
        private StateManagerBase<PCState> pcState;

        public override void OnEnterState()
        {
            if (pcState == null)
                pcState = PCController.Instance.pcStateManager;
            //throw new System.NotImplementedException();
        }

        public override void OnExitState()
        {
            //  throw new System.NotImplementedException();
        }

        public override bool CanEnter(StateBase currentStateBase)
        {
            if (currentStateBase.GetType() == typeof(PreGameState))
                return true;


            return false;
        }

        public override bool CanExit()
        {
            return pcState.GetState().GetType() == typeof(PCPlayState);
        }
    }
}
