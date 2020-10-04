﻿using Tools.StateManager;
using UnityEngine;

namespace LD47
{
    namespace Minigame
    {
        public class PCProgressState : PCState
        {
            public override void OnEnterState() {
                pcUI = GameObject.FindObjectOfType<PCUiController>();
                
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

