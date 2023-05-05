
using UnityEngine;

namespace DefaultNamespace
{
    public class GameStateHandler : MonoBehaviour
    {
        public static GameStateHandler Instance;
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                CurrentState = GameState.Running;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
        
        public GameState CurrentState { get; private set; }

        public bool IsSpawnSafe => CurrentState == GameState.Running;

        void OnApplicationQuit()
        {
            CurrentState = GameState.Quitting;
        }
    }
}