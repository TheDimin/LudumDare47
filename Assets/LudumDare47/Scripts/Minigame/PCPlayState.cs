using Tools.StateManager;
using UnityEditor.Build.Player;
using UnityEngine;

namespace LD47
{
    namespace Minigame
    {
        public class PCPlayState : PCState
        {
            public MinigameController minigame;
            private GameObject playUI;

            public PCPlayState() {
                playUI = GameObject.Find("_PCBEditor");
                playUI.SetActive(false);
            }
            
            public override void OnEnterState() {
                pcUI = GameObject.FindObjectOfType<PCUiController>();
                minigame = new MinigameController();
                
                playUI.SetActive(true);
            }

            public override void OnExitState() {
                playUI.SetActive(false);

                PCController.score = minigame.get_game_score();
                PCController.stage = minigame.get_game_stage();
                
                Debug.Log("yeeeeeeeeeeeeeeet");
            }

            public override void Update() {
                minigame.Update();
            }

            public override bool CanEnter(StateBase currentStateBase) {
                return currentStateBase.GetType() == typeof(PCIdleState);
            }
            
            public override bool CanExit() {
                return minigame.get_game_score() == 3 || minigame.get_game_stage() == 3;
            }
        }
    }
}

