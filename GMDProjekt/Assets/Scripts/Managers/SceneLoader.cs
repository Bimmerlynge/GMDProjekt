using System;
using System.Collections;
using System.Collections.Generic;
using Managers;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        Invoke("InvokeStage", 3f);
    }

    private void InvokeStage()
    {
        StageManager.Instance.BeginStage();
    }

    public void LoadNextScene()
    {
        var stageManager = StageManager.Instance;
        SceneManager.LoadScene($"stage{(stageManager.CurrentStage < 9 ? "0" + ++stageManager.CurrentStage : ++stageManager.CurrentStage)}");
        
    }

    public void LoadFirstStage()
    {
        SceneManager.LoadScene("stage01");
    }

    public void LoadSettingsMenu()
    {
        
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
