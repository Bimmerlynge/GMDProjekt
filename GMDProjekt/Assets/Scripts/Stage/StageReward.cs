using System.Collections;
using GameData;
using Managers;
using UnityEngine;

namespace Stage
{
    public class StageReward : MonoBehaviour
    {
        [SerializeField] private StageRewardData stageReward;
        public delegate void RewardPickupAction();
        public static event RewardPickupAction OnRewardPickedUp;
    
        private GameObject instantiatedObj;
        public void Instantiate()
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
            UIManager.Instance.SetInteractablePanel(false);
            if (OnRewardPickedUp != null) OnRewardPickedUp();
        }
    }
}
