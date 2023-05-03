using System;
using UnityEngine;


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

    private void Awake()
    {
        StageManager.OnBeginStage += SpawnNextWave;
    }

    public void SpawnNextWave()
    {
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
            Invoke("SpawnNextWave", 1f);
    }

    private void FireLastWaveCompleted()
    {
        if (OnFinalWaveCompleted != null) OnFinalWaveCompleted.Invoke();
    }

    private void OnDestroy()
    {
        EnemyController.OnLastEnemyDefeated -= OnLastEnemyKilled;
        StageManager.OnBeginStage -= SpawnNextWave;
    }
}
