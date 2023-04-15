using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private int enemyCount = 10;

    private void Start()
    {
        Invoke( "SpawnEnemies",3f);
    }

    private void SpawnEnemies()
    {
        for (var i = 0; i < enemyCount; i++)
        {
            Instantiate(enemyPrefab, GetRandomSpawn(), Quaternion.identity);
        }
    }

    private Vector3 GetRandomSpawn()
    {
        return new Vector3(
            UnityEngine.Random.Range(-16, 16),
            0.5f,
            UnityEngine.Random.Range(0, 20)
        );
    }
}
