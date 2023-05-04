using System;
using System.Collections;
using DefaultNamespace.Stage;
using GameData;
using UnityEngine;


public class InitGame : MonoBehaviour
{
    [SerializeField] private AudioClip music;
    [SerializeField] private StageRewardSO stageReward;
    [SerializeField] private GameObject rewardPrefab;

   

    private void Start()
    {
        SetAudioManager();
        StartMusic();
        InitStageReward();
    }
    
    private void SetAudioManager()
    {
        var handler = PlayerPrefsHandler.Instance;
        AudioManager.Instance.SetMusicVolume(handler.MusicVolume);
        AudioManager.Instance.SetMusicMute(handler.MusicMute);
        AudioManager.Instance.SetEffectsVolume(handler.EffectsVolume);
        AudioManager.Instance.SetEffectsMute(handler.EffectsMute);
    }
    private void StartMusic()
    {
        AudioManager.Instance.PlayMusic(music);
    }
    
    private void InitStageReward()
    {
        stageReward.prefab = rewardPrefab;
    }
}
