using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class FinalStage : MonoBehaviour
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
