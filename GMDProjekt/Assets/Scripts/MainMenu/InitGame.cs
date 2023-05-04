using System;
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
        LoadPlayerPrefs();
        InitStageReward();
        StartMusic();
    }

    private void StartMusic()
    {
        AudioManager.Instance.PlayMusic(music);
    }

    private void InitStageReward()
    {
        stageReward.prefab = rewardPrefab;
    }

    private void LoadPlayerPrefs()
    {
        var handler = PlayerPrefsHandler.Instance;
        AudioManager.Instance.SetMusicVolume(handler.MusicVolume);
        AudioManager.Instance.SetMusicMute(handler.MusicMute);
        AudioManager.Instance.SetMusicVolume(handler.EffectsVolume);
        AudioManager.Instance.SetMusicMute(handler.EffectsMute);
    }
}
