using System;
using UnityEngine;

namespace DefaultNamespace.Stage
{
    public class StageOptions : MonoBehaviour
    {
        [SerializeField] private BoxCollider option1, option2;

        private void Start()
        {
            StageOption.OnStageOptionChosen += OnOptionChosen;
        }

        public void EnableOptions()
        {
            option1.enabled = true;
            option2.enabled = true;
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