using DG.Tweening;
using Tools.StateManager;
using UnityEngine;
using UnityEngine.UI;

namespace LD47
{
    namespace Minigame
    {
        public class PCProgressState : PCState
        {
            private GameObject progressUI;

            private Image progressBar;

            private bool tweenIsDone = false;

            public PCProgressState() {
                progressUI = GameObject.Find("_PROGRESS");
                progressBar = progressUI.transform.Find("progressBarFill").GetComponent<Image>();
                
                // progressUI.SetActive(false); its gets disabled in broken progress state
            }
            
            public override void OnEnterState() {
                tweenIsDone = false;
                progressUI.SetActive(true);
                progressBar.fillAmount = 0.0f;
                
                pcUI = GameObject.FindObjectOfType<PCUiController>();
                
                progressBar.DOFillAmount(1, 5f).SetEase(Ease.Linear).OnComplete(() => { tweenIsDone = true;});
            }

            public override void OnExitState() {
                progressUI.SetActive(false);
            }

            public override bool CanEnter(StateBase currentStateBase) {
                return PCController.score == 3 && PCController.stage == 3;
            }
            
            public override bool CanExit() {
                return tweenIsDone;
            }
        }
    }
}

