using System.Collections.Generic;
using Interactables;
using Managers;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Stage
{
    public class StageOptions : MonoBehaviour
    {
        [SerializeField] private List<GameObject> optionPoints;
        
        [SerializeField] private List<GameObject> optionPool;
        
        private void Start()
        {
            StageOption.OnStageOptionChosen += OnOptionChosen;
            StageReward.OnRewardPickedUp += GenerateStageOptions;

        }
        private void OnDestroy()
        {
            StageOption.OnStageOptionChosen -= OnOptionChosen;
            StageReward.OnRewardPickedUp -= GenerateStageOptions;
        }
        
        private void GenerateStageOptions()
        {
            foreach (var point in optionPoints)
            {
                SpawnOptionPrefab(point.transform);
            }
        }
        
        private void SpawnOptionPrefab(Transform spawnPoint)
        {
            var option = GetRandomOption();
            Instantiate(option, spawnPoint);
            option.GetComponentInChildren<BoxCollider>().enabled = true;
        }


        private GameObject GetRandomOption()
        {
            var rand = Random.Range(0, optionPool.Count);
            var toReturn = optionPool[rand];
            optionPool.Remove(toReturn);
            return toReturn;
        }

        private void OnOptionChosen()
        {
            SceneLoader.Instance.LoadNextScene();
        }
    }
}