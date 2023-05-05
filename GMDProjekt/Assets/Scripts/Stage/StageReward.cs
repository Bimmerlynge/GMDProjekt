using System.Collections;
using DefaultNamespace.Stage;
using GameData;
using UnityEngine;

public class StageReward : MonoBehaviour
{
    [SerializeField] private StageRewardData stageReward;
    public delegate void RewardPickupAction();
    public static event RewardPickupAction OnRewardPickedUp;
    
    private GameObject instantiatedObj;
    public void Instantiate()
    {
        Invoke("InstantiateReward", 1f);
    }

    private void InstantiateReward()
    {
        instantiatedObj = Instantiate(stageReward.Prefab, new Vector3(0, 1, 10), Quaternion.identity);
        StartCoroutine(WaitForRewardPickup());
    }
    private IEnumerator WaitForRewardPickup()
    {
        while (instantiatedObj != null)
        {
            yield return null;
        }

        if (OnRewardPickedUp != null) OnRewardPickedUp();
    }
}
