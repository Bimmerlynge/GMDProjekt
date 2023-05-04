using System;
using UnityEngine;

public class StandardStage : MonoBehaviour, IStage
{
    [SerializeField] private Wave wave;
    [SerializeField] private StageReward reward;
    [SerializeField] private StageOption option1, option2;

    private void Awake()
    {
        UIManager.Instance.SetGameHudPanel(true);
    }

    public void Start()
    {
        Wave.OnFinalWaveCompleted += SpawnReward;
        StageOption.OnStageOptionChosen += OnNextStageOptionChosen;
        StageReward.OnRewardPickedUp += ActivateStageOptions;
        RuneManager.Instance.SetPlayerTransform();
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

    private void OnNextStageOptionChosen(GameObject rewardPrefab)
    {
        print("OnNeXtStage");
        reward.SetCurrentStageReward(rewardPrefab);
        SceneLoader.Instance.LoadNextScene();
    }
    

    private void SpawnReward()
    {
        print("spawn reward");
        reward.Instantiate();
    }
    

    private void ActivateStageOptions()
    {
        print("activateStageoptiosn");
        option1.GetComponentInChildren<BoxCollider>().enabled = true;
        option2.GetComponentInChildren<BoxCollider>().enabled = true;
    }



    private void OnDestroy()
    {
        Wave.OnFinalWaveCompleted -= SpawnReward;
        StageOption.OnStageOptionChosen -= OnNextStageOptionChosen;
        StageReward.OnRewardPickedUp -= ActivateStageOptions;
    }
}
