using System;
using System.Collections;
using System.Collections.Generic;
using Managers;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader Instance;
    [SerializeField]
    private int currentStage = 0;
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
        SceneManager.LoadScene($"stage{(currentStage < 9 ? "0" + ++currentStage : ++currentStage)}");
        
    }

    public void LoadFirstStage()
    {
        LoadNextScene();
    }
    

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
