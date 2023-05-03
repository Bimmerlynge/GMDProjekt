using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardStage : MonoBehaviour, IStage
{
    [SerializeField] private Wave wave;
    [SerializeField] private StageReward reward;
    
    public void Start()
    {
        Wave.OnFinalWaveCompleted += SpawnReward;
        Invoke("BeginStage", 3f);
    }
    public void BeginStage()
    {
        wave.SpawnNextWave();
    }

    private void SpawnReward()
    {
        reward.Instantiate();
    }

    private void OnDestroy()
    {
        Wave.OnFinalWaveCompleted -= SpawnReward;
    }
}
