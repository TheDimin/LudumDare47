using System.Collections;
using System.Collections.Generic;
using JimTheKiwifruit;
using Tools.StateManager;
using UnityEngine;

namespace LD47
{
    namespace Minigame
    {
        public class PCController : Singleton<PCController>
        {
            public static int score = 0;
            public static int stage = 0;
            
            public StateManagerBase<PCState> pcStateManager;
            
            public bool PlayingOnPC = false;

            private void Start() {
                pcStateManager = new StateManagerBase<PCState>();
                pcStateManager.RegisterState(new PCIdleState());
                pcStateManager.RegisterState(new PCPlayState());
                pcStateManager.RegisterState(new PCProgressState());
                pcStateManager.RegisterState(new PCBrokenProgressState());
            }

            private void Update() {
                pcStateManager.Update();
            }
        }
    }
}

