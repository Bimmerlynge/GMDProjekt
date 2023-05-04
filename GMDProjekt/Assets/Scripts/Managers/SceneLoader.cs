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
    
    public void LoadNextScene()
    {
        var stageNumberString = $"{(currentStage < 9 ? "0" + ++currentStage : ++currentStage)}";
        SceneManager.LoadScene($"stage{stageNumberString}");
        
    }
}
