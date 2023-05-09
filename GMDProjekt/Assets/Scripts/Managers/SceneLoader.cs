using System.Collections;
using GameData;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers
{
    public class SceneLoader : Singleton<SceneLoader>
    {
        [SerializeField]
        private int currentStage = 0;

        private readonly float loadBuffer = 1f;

        public void LoadNextScene()
        {
            var stageNumberString = $"{(currentStage < 9 ? "0" + ++currentStage : ++currentStage)}";
            SceneManager.LoadScene($"stage{stageNumberString}");
            StartCoroutine(LoadTime());
        }

        public void LoadMainMenu()
        {
            SceneManager.LoadScene("MainMenu");
            currentStage = 0;
            StartCoroutine(LoadTime());
        }

        private IEnumerator LoadTime()
        {
            yield return new WaitForSeconds(loadBuffer);
            GameStateHandler.Instance.CurrentState = GameState.Running;
        }


    }
}
