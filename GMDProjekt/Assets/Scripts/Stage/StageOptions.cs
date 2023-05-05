using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace DefaultNamespace.Stage
{
    public class StageOptions : MonoBehaviour
    {
        [SerializeField]
        private GameObject option1, option2;
        private BoxCollider trigger1, trigger2;
        [SerializeField] private List<GameObject> optionTypes;
        [SerializeField] private List<Transform> spawnPoints;
        private List<GameObject> optionPool;

        private void Awake()
        {
            GenerateStageOptions();
            SetCollidersRefs();
        }

        private void Start()
        {
            StageOption.OnStageOptionChosen += OnOptionChosen;
            
        }

        private void SetCollidersRefs()
        {
            trigger1 = option1.GetComponentInChildren<BoxCollider>();
            trigger2 = option2.GetComponentInChildren<BoxCollider>();
        }

        private void GenerateStageOptions()
        {
            optionPool = new List<GameObject>(optionTypes);
            foreach (var spawn in spawnPoints)
            {
                SpawnOptionPrefab(spawn);
            }

        }

        private void SpawnOptionPrefab(Transform spawnPoint)
        {
            var option = GetRandomOption();
            print(option.name);
            Instantiate(option, spawnPoint);
        }


        private GameObject GetRandomOption()
        {
            var rand = Random.Range(0, optionPool.Count);
            var toReturn = optionPool[rand];
            optionPool.Remove(toReturn);
            return toReturn;
        }

        public void EnableOptions()
        {
            trigger1.enabled = true;
            trigger2.enabled = true;
        }

        private void OnOptionChosen()
        {
            SceneLoader.Instance.LoadNextScene();
        }

        private void OnDestroy()
        {
            StageOption.OnStageOptionChosen -= OnOptionChosen;
        }
    }
}