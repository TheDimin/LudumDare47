﻿using JimTheKiwifruit;
using LD47.GameStates;
using Tools.StateManager;
using UnityEngine;

namespace LD47
{
    public class GameManager : Singleton<GameManager>
    {
        public GameStateManager StateManager { get; private set; }

        protected override void Awake()
        {
            StateManager = new GameStateManager(this);

            StateManager.RegisterState(new PreGameState());
            StateManager.RegisterState(new WalkingGameState());
            StateManager.RegisterState(new MiniGameState());

            base.Awake();
        }

        private void Update()
        {
            StateManager.Update();
        }
    }
}