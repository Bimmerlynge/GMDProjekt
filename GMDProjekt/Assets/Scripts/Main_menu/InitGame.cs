using Audio;
using DefaultNamespace;
using GameData;
using Managers;
using UnityEngine;

namespace Main_menu
{
    public class InitGame : MonoBehaviour
    {
        private Music music;
        [SerializeField] private StageRewardData stageRewardData;
        [SerializeField] private HealthData healthData;
        private void Awake()
        {
            music = GetComponent<Music>();
        }

        private void Start()
        {
            SetAudioManager();
            StartMusic();
            InitStageRewardData();
            InitHeathData();
            ResetTimer();
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

        private void InitHeathData()
        {
            healthData.Value = 0;
        }

        private void ResetTimer()
        {
            GameStateHandler.Instance.ResetTimer();
        }

    }
}
