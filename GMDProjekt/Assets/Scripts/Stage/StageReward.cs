using System.Collections;
using System.Collections.Generic;
using DefaultNamespace.Stage;
using UnityEngine;

public class StageReward : MonoBehaviour
{
    [SerializeField] private StageRewardSO reward;

    public void Instantiate()
    {
        Invoke("InstantiateReward", 1f);
    }

    private void InstantiateReward()
    {
        Instantiate(reward.prefab, new Vector3(0, 1, 10), Quaternion.identity);

    }
}
