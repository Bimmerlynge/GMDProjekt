using System;
using UnityEngine;

namespace Managers
{
    public class GameStateManager : MonoBehaviour
    {
        public static GameStateManager Instance;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public enum GameState
        {
            InMenu,
            SceneChange,
            ActiveStage
        }

        public GameState CurrentState { get; private set; } = GameState.InMenu;

        private IGameState _currentState;
        
        public void SetState(GameState state)
        {
            CurrentState = state;
        }

    }
}