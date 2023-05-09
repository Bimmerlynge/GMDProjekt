using Managers;
using Player;
using UnityEngine;

namespace Stage
{
    public class StandardStage : MonoBehaviour, IStage
    {
        private Wave wave;
        private StageReward reward;

        private void Awake()
        {
            reward = GetComponent<StageReward>();
            wave = GetComponent<Wave>();
        }

        public void Start()
        {
            Wave.OnFinalWaveCompleted += SpawnReward;
            PlayerInputController.OnEscape += OpenSettingsMenu;
            UIManager.Instance.SetGameHudPanel(true);
        
            Invoke("BeginStage", 3f);
        }
        private void OnDestroy()
        {
            Wave.OnFinalWaveCompleted -= SpawnReward;
            PlayerInputController.OnEscape -= OpenSettingsMenu;
        }
    
        public void BeginStage()
        {
            wave.SpawnNextWave();
        }

        private void OpenSettingsMenu()
        {
            UIManager.Instance.OpenSettingsMenu();
        }
    
        private void SpawnReward()
        {
            if (!GameStateHandler.Instance.IsSpawnSafe) return;
            reward.Instantiate();
        }
    }
}
