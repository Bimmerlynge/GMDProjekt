using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using Unity.Mathematics;
using UnityEngine;

public class Spider : MonoBehaviour
{
    [SerializeField] private GameObject spiderSpawn;
    [SerializeField] private int amount;


    private void OnDestroy()
    {
        if (!GameStateHandler.Instance.IsSpawnSafe) return;
        SpawnMinions();
    }


    private void SpawnMinions()
    {
        for (int i = 0; i < amount; i++)
        {
            Instantiate(spiderSpawn, transform.position, Quaternion.identity);
        }
    }
}
