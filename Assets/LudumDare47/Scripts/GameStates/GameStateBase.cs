using System.Collections;
using System.Collections.Generic;
using Tools.StateManager;
using UnityEngine;


namespace LD47.GameStates
{
    public class GameStateManager : StateManagerBase<GameStateBase>
    {
        private GameManager gameManager;
        public GameStateManager(GameManager gm)
        {
            gameManager = gm;
        }

        public override void RegisterState(GameStateBase stateBase)
        {
            base.RegisterState(stateBase);
            stateBase.SetGameManagerRef(gameManager);
        }
    }

    public abstract class GameStateBase : StateBase
    {
        protected GameManager gameManager;

        internal void SetGameManagerRef(GameManager gameManager)
        {
            this.gameManager = gameManager;
        }
    }
}
