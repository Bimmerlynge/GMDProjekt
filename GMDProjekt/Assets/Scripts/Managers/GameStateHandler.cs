
using GameData;
using UnityEngine;

namespace DefaultNamespace
{
    public class GameStateHandler : MonoBehaviour
    {
        private RunTimer timer;
        public static GameStateHandler Instance;
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                CurrentState = GameState.MainMenu;
                timer = GetComponent<RunTimer>();
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
        
        public GameState CurrentState { get; set; }

        public bool IsSpawnSafe => CurrentState == GameState.Running;

        void OnApplicationQuit()
        {
            CurrentState = GameState.Quitting;
        }

        public void StartTimer()
        {
            timer.StartTimer();
        }

        public void StopTimer()
        {
            timer.StopTimer();
        }

        public void ResetTimer()
        {
            timer.ResetTimer();
        }
    }
}