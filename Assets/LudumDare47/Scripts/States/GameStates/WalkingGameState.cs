using System.Collections;
using System.Collections.Generic;
using Tools.StateManager;
using UnityEngine;

namespace LD47.GameStates
{
    public class WalkingGameState : GameStateBase
    {
        public override void OnEnterState()
        {
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
            return false;
        }
    }
}
