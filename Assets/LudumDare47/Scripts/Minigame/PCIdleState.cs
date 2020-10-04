﻿using Tools.StateManager;
using UnityEngine;

namespace LD47
{
    namespace Minigame
    {
        public class PCIdleState : PCState
        {
            private GameObject idleUI;
            
            public PCIdleState() {
                idleUI = GameObject.Find("_IDLE");
                idleUI.SetActive(false);
            }
            
            public override void OnEnterState() {
                pcUI = GameObject.FindObjectOfType<PCUiController>();
                
                idleUI.SetActive(true);
            }

            public override void OnExitState() {
                idleUI.SetActive(false);
            }
            
            public override bool CanEnter(StateBase currentStateBase) {
                return currentStateBase == null || currentStateBase.GetType() == typeof(PCProgressState) || currentStateBase.GetType() == typeof(PCBrokenProgressState);
            }

            public override bool CanExit() {
                return Input.GetKeyDown(KeyCode.F1); // quick hack for testing
            }
        }
    }
}

