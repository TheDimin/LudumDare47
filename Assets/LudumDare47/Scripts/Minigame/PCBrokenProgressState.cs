using Tools.StateManager;
using UnityEngine;

namespace LD47
{
    namespace Minigame
    {
        public class PCBrokenProgressState : PCState
        {
            public override void OnEnterState() {
                pcUI = GameObject.FindObjectOfType<PCUiController>();
            }

            public override void OnExitState() {
                
            }

            public override bool CanEnter(StateBase currentStateBase) {
                return false;
            }

            public override bool CanExit() {
                return false;
            }
        }
    }
}

