using GameData;

namespace Managers
{
    public class GameStateHandler : Singleton<GameStateHandler>
    {
        private RunTimer timer;

        private void Start()
        {
            timer = GetComponent<RunTimer>();
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