using System.Collections.Generic;
using Enemies;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private int enemyCount = 10;

    [SerializeField]
    private SpawnArea _spawnArea;

    public void SpawnEnemies()
    {
        for (var i = 0; i < enemyCount; i++)
        {
            InstantiateEnemy(enemyPrefab);
        }
    }

    private void InstantiateEnemy(GameObject enemy)
    {
        Instantiate(enemy, _spawnArea.GetRandomSpawnLocation(), Quaternion.identity);
    }
}
