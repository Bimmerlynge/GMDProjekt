using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private int enemyCount = 10;
    [SerializeField] private List<GameObject> enemyTypes;

    [SerializeField]
    private SpawnArea _spawnArea;

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
