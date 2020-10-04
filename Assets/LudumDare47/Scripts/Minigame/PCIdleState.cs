using Tools.StateManager;
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
                PCController.Instance.PlayingOnPC = false;
                idleUI.SetActive(true);
            }

            public override void OnExitState() {
                idleUI.SetActive(false);
            }

            public override bool CanEnter(StateBase currentStateBase) {
                return currentStateBase == null || currentStateBase.GetType() == typeof(PCProgressState
                ) || currentStateBase.GetType() == typeof(PCBrokenProgressState);
            }

            public override bool CanExit() => PCController.Instance.PlayingOnPC;
        }
    }
}

