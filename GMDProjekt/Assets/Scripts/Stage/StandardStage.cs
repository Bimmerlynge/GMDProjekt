using DefaultNamespace;
using DefaultNamespace.Stage;
using UnityEngine;

public class StandardStage : MonoBehaviour, IStage
{
    private Wave wave;
    private StageReward reward;
    private StageOptions options;

    private void Awake()
    {
        reward = GetComponent<StageReward>();
        wave = GetComponent<Wave>();
        options = GetComponent<StageOptions>();
        
    }

    public void Start()
    {
        Wave.OnFinalWaveCompleted += SpawnReward;
        PlayerInputController.OnEscape += OpenSettingsMenu;
        UIManager.Instance.SetGameHudPanel(true);
        
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
    
    private void SpawnReward()
    {
        if (!GameStateHandler.Instance.IsSpawnSafe) return;
        reward.Instantiate();
    }

    private void OnDestroy()
    {
        Wave.OnFinalWaveCompleted -= SpawnReward;
        PlayerInputController.OnEscape -= OpenSettingsMenu;
    }
}
