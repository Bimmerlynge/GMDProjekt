using System;
using System.Collections;
using System.Collections.Generic;
using Managers;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private AudioClip music;
    private void Start()
    {
        LoadPlayerPref();
        AudioManager.Instance.PlayMusic(music);
    }

    public void StartGame()
    {
        SceneLoader.Instance.LoadFirstStage();
    }

    public void Settings()
    {
        //menuUI.SetActive(false);
        UIManager.Instance.SetSettingsPanelState(true);
    }

    public void Exit()
    {
        Application.Quit();
    }

    private void LoadPlayerPref()
    {
        var musicVolume = PlayerPrefs.GetFloat("musicSlider");
        AudioManager.Instance.SetMusicVolume(musicVolume);
        
        var musicMute  = PlayerPrefs.GetInt("musicToggle") == 1;
        AudioManager.Instance.SetMusicMute(musicMute);
        
        var effectsVolume = PlayerPrefs.GetFloat("effectsSlider");
        AudioManager.Instance.SetMusicVolume(effectsVolume);
        
        var effectsMute = PlayerPrefs.GetInt("effectsToggle") == 1;
        AudioManager.Instance.SetMusicMute(musicMute);
    }
}
