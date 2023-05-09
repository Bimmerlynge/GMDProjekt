using Managers;
using Player;
using UnityEngine;

namespace Stage
{
    public class FinalStage : MonoBehaviour, IStage
    {
        private Wave wave;

        private void Awake()
        {
            wave = GetComponent<Wave>();

        }
        public void Start()
        {
            Wave.OnFinalWaveCompleted += EndGame;
            PlayerInputController.OnEscape += OpenSettingsMenu;

            Invoke("BeginStage", 3f);
        }
        public void BeginStage()
        {
            wave.SpawnNextWave();
        }
    
        private void OpenSettingsMenu()
        {
            UIManager.Instance.OpenSettingsMenu();
        }
    
        private void EndGame()
        {
            UIManager.Instance.OpenEndGameMenu();
            GameStateHandler.Instance.StopTimer();
        }

        private void OnDestroy()
        {
            Wave.OnFinalWaveCompleted -= EndGame;
            PlayerInputController.OnEscape -= OpenSettingsMenu;
        }
    
    
    }
}
