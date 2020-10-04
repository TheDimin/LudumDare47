using Tools.StateManager;
using UnityEngine;

namespace LD47
{
    namespace Minigame
    {
        public class PCPlayState : PCState
        {
            public MinigameController minigame;
            private GameObject playUI;
            
            public override void OnEnterState() {
                pcUI = GameObject.FindObjectOfType<PCUiController>();
                minigame = new MinigameController();
                
                playUI = GameObject.Find("PlayUI");
            }

            public override void OnExitState() {
                
            }

            public override void Update() {
                minigame.Update();
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

