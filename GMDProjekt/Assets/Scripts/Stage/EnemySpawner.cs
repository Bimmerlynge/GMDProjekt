using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private int enemyCount = 10;
    [SerializeField] private List<GameObject> enemyTypes;

    [SerializeField]
    private SpawnArea _spawnArea;

    private void Start()
    {
        
    }

    public void SpawnEnemies()
    {
        for (var i = 0; i < enemyCount; i++)
        {
            InstantiateEnemy(GetRandomEnemy());
        }
    }

    private void InstantiateEnemy(GameObject enemy)
    {
        Instantiate(enemy, _spawnArea.GetRandomSpawnLocation(), Quaternion.identity);
    }
    
    private GameObject GetRandomEnemy()
    {
        var rand = Random.Range(0, enemyTypes.Count);
        return enemyTypes[rand];
    }
}
