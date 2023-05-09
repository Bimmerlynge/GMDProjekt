using Enemies;
using Managers;
using UnityEngine;

namespace Stage
{
    public class Wave : MonoBehaviour
    {
        public delegate void FinalWaveComplete();
        public static event FinalWaveComplete OnFinalWaveCompleted;
    
    
        [SerializeField] private int count = 3;
        [SerializeField] private EnemySpawner _spawner;
    
        [SerializeField]
        private int _currentWave = 0;
        [SerializeField]
        private bool _isFinalWave;

        private void Start()
        {
            EnemyController.OnLastEnemyDefeated += OnLastEnemyKilled;
        }

        public void SpawnNextWave()
        {
            if (!GameStateHandler.Instance.IsSpawnSafe) return;
            _spawner.SpawnEnemies();
            _currentWave++;
            CheckIfLastWave();
        }

        private void CheckIfLastWave()
        {
            _isFinalWave = _currentWave == count;
        }

        private void OnLastEnemyKilled()
        {
            if (_isFinalWave)
                FireLastWaveCompleted();
            else
                SpawnNextWave();
        }

        private void FireLastWaveCompleted()
        {
            if (OnFinalWaveCompleted != null) OnFinalWaveCompleted.Invoke();
        }

        private void OnDestroy()
        {
            EnemyController.OnLastEnemyDefeated -= OnLastEnemyKilled;
        }
    }
}
