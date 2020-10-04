using System.Collections;
using System.Collections.Generic;
using Tools.StateManager;
using UnityEngine;

namespace LD47
{
    namespace Minigame
    {
        public class PCPlayState : PCState
        {
            public override void OnEnterState() {
                
            }

            public override void OnExitState() {
                
            }

            public override bool CanEnter(StateBase currentStateBase) {
                return true;
            }

            public override bool CanExit() {
                return false;
            }
        }
    }
}

