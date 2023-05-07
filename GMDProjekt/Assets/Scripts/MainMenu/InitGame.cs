using System;
using System.Collections;
using Audio;
using DefaultNamespace.Stage;
using GameData;
using UnityEngine;


public class InitGame : MonoBehaviour
{
    private Music music;
    [SerializeField] private StageRewardData stageRewardData;
    private void Awake()
    {
        music = GetComponent<Music>();
    }

    private void Start()
    {
        SetAudioManager();
        StartMusic();
        InitStageRewardData();
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
        music.PlaySong();
    }

    private void InitStageRewardData()
    {
        stageRewardData.SetCurrentPrefab(null);
    }

}
