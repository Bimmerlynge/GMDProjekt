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
        UIManager.Instance.SetGameHudPanel(true);
    }

    public void Start()
    {
        Wave.OnFinalWaveCompleted += SpawnReward;
        StageReward.OnRewardPickedUp += ActivateStageOptions;
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
    
    private void SpawnReward()
    {
        reward.Instantiate();
    }
    
    private void ActivateStageOptions()
    {
        options.EnableOptions();
    }
    
    private void OnDestroy()
    {
        Wave.OnFinalWaveCompleted -= SpawnReward;
        StageReward.OnRewardPickedUp -= ActivateStageOptions;
        PlayerInputController.OnEscape -= OpenSettingsMenu;
    }
}
