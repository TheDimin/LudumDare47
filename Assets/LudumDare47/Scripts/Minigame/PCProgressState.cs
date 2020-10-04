using Tools.StateManager;
using UnityEngine;

namespace LD47
{
    namespace Minigame
    {
        public class PCProgressState : PCState
        {
            private GameObject progressUI;
            
            public override void OnEnterState() {
                pcUI = GameObject.FindObjectOfType<PCUiController>();
                
                progressUI.SetActive(true);
            }

            public override void OnExitState() {
                progressUI.SetActive(false);
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

