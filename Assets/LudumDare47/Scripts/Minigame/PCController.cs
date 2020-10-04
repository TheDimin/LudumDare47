using System.Collections;
using System.Collections.Generic;
using Tools.StateManager;
using UnityEngine;

namespace LD47
{
    namespace Minigame
    {
        public class PCController : MonoBehaviour
        {
            private StateManagerBase<PCState> pcStateManager;
            
            private void Start() {
                pcStateManager = new StateManagerBase<PCState>();
                pcStateManager.RegisterState(new PCIdleState());
                pcStateManager.RegisterState(new PCPlayState());
                pcStateManager.RegisterState(new PCProgressState());
            }

            private void Update() {
                pcStateManager.Update();
            }
        }
    }
}

