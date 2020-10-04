using Tools.StateManager;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace LD47
{
    namespace Minigame
    {
        public class PCBrokenProgressState : PCState
        {
            private GameObject progressUI;

            private Image progressBar;

            private bool tweenIsDone = false;

            private Tween tween;

            public PCBrokenProgressState() {
                progressUI = GameObject.Find("_PROGRESS");
                progressBar = GameObject.Find("progressBarFill").GetComponent<Image>();
                
                progressUI.SetActive(false);
            }
            
            public override void OnEnterState() {
                progressUI.SetActive(true);
                progressBar.fillAmount = 0.0f;
                
                pcUI = GameObject.FindObjectOfType<PCUiController>();

                tween = progressBar.DOFillAmount(1f, 3.69f).OnComplete(() => { tween.Restart(); }).SetEase(Ease.Linear);
            }

            public override void OnExitState() {
                tween.Kill();
            }

            public override bool CanEnter(StateBase currentStateBase) {
                return PCController.stage == 3 && PCController.score != 3;
            }

            public override bool CanExit() {
                return false;
            }
        }
    }
}

