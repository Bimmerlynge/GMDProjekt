using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace.Stage;
using UnityEngine;

public class StageReward : MonoBehaviour
{
    public delegate void RewardPickupAction();

    public static event RewardPickupAction OnRewardPickedUp;
    
    
    [SerializeField] private StageRewardSO currentStageReward;
    private GameObject instantiatedObj;
    public void Instantiate()
    {
        Invoke("InstantiateReward", 1f);
    }

    private void InstantiateReward()
    {
        instantiatedObj = Instantiate(currentStageReward.prefab, new Vector3(0, 1, 10), Quaternion.identity);
        StartCoroutine(WaitForRewardPickup());
    }

    public void SetCurrentStageReward(GameObject rewardPrefab)
    {
        currentStageReward.prefab = rewardPrefab;
    }

    private IEnumerator WaitForRewardPickup()
    {
        print("starting wait for pickup");
        while (instantiatedObj != null)
        {
            print("not picked up");
            yield return null;
        }

        if (OnRewardPickedUp != null) OnRewardPickedUp();
    }


}
