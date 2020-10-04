using Tools.StateManager;
using UnityEngine;

namespace LD47
{
    namespace Minigame
    {
        public class PCIdleState : PCState
        {
            public override void OnEnterState()
            {
                pcUI = GameObject.FindObjectOfType<PCUiController>();
                
                PCController.Instance.PlayingOnPC = false;
            }

            public override void OnExitState() {
                
            }

            public override bool CanEnter(StateBase currentStateBase) => currentStateBase == null;

            public override bool CanExit() => PCController.Instance.PlayingOnPC;
        }
    }
}

