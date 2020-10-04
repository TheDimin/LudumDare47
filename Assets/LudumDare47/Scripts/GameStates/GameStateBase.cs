using System.Collections;
using System.Collections.Generic;
using Tools.StateManager;
using UnityEngine;


namespace LD47.GameStates
{
    public abstract class GameStateManager : StateManagerBase<GameStateBase>
    {
       // public GameStateManager(GameMang)
        public override void RegisterState(GameStateBase stateBase)
        {
            base.RegisterState(stateBase);

        }
    }

    public abstract class GameStateBase : StateBase
    {

    }
}
