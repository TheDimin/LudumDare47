using JimTheKiwifruit;
using LD47.GameStates;
using System.Dynamic;
using Tools.StateManager;
using UnityEngine;

namespace LD47
{
    public class GameManager : Singleton<GameManager>
    {
        public GameStateManager StateManager { get; private set; }
        public PlayerController Player { get; private set; } = null;

        protected override void Awake()
        {
            base.Awake();

            StateManager = new GameStateManager(this);

            StateManager.RegisterState(new PreGameState());
            StateManager.RegisterState(new MiniGameState());
            StateManager.RegisterState(new WalkingGameState());

            Player = FindPlayer();
        }

        private void Update()
        {
            StateManager.Update();
        }

        private PlayerController FindPlayer()
		{
            PlayerController[] players = FindObjectsOfType<PlayerController>(); 

            if(players.Length > 1)
			{
                Debug.LogError($"There should only be one {typeof(PlayerController)}.");
                return null;
			}

            return players[0];
		}
    }
}