using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    [SerializeField] private int enemiesLeft = 10;
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private GameObject currentReward;

    private void Start()
    {
        EnemyController.EnemyDefeatedEvent += HandleEnemyDefeated;
        _enemySpawner.EnemyCount = enemiesLeft;
    }

    private void HandleEnemyDefeated()
    {
        enemiesLeft--;
        if (enemiesLeft == 0) StageComplete();
    }

    private void StageComplete()
    {
        SpawnReward();
        GenerateNextStageRewardOptions();
    }

    private void GenerateNextStageRewardOptions()
    {
        print("Generate Next Rooms");
    }

    private void SpawnReward()
    {
        Instantiate(currentReward, Vector3.zero, Quaternion.identity);
    }
}
