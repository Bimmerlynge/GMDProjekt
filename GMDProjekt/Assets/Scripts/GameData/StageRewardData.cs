using DefaultNamespace.Stage;
using UnityEngine;

namespace GameData
{
    [CreateAssetMenu(fileName = "StageRewardData",menuName = "Stage Reward Data")]
    public class StageRewardData : ScriptableObject
    {
        [SerializeField] private GameObject defaultPrefab;
        [SerializeField] private GameObject currentPrefab;

        public GameObject Prefab => currentPrefab == null ? defaultPrefab : currentPrefab;

        public void SetCurrentPrefab(GameObject prefab)
        {
            currentPrefab = prefab;
        }
    }
}