﻿using Tools.StateManager;
using UnityEngine;

namespace LD47
{
    namespace Minigame
    {
        public class PCIdleState : PCState
        {
            public override void OnEnterState() {
                pcUI = GameObject.FindObjectOfType<PCUiController>();
            }

            public override void OnExitState() {
                
            }

            public override bool CanEnter(StateBase currentStateBase) {
                return currentStateBase == null;
            }

            public override bool CanExit() {
                return Input.GetKeyDown(KeyCode.F1); // quick hack for testing
            }
        }
    }
}

