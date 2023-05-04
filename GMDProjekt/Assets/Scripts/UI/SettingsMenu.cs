using System;
using GameData;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class SettingsMenu : MonoBehaviour
    {
        [SerializeField] private Toggle musicToggle;
        [SerializeField] private Slider musicSlider;

        [SerializeField] private Toggle effectsToggle;
        [SerializeField] private Slider effectsSlider;

        private void OnEnable()
        {
            LoadCurrentSettings();
            FreezeTime();
        }
        private void FreezeTime()
        {
            Time.timeScale = 0f;
        }

        public void OnMusicValueChange(float value)
        {
            PlayerPrefsHandler.Instance.MusicVolume = value;
            AudioManager.Instance.SetMusicVolume(value);
        }

        public void OnMusicMute(bool value)
        {
            PlayerPrefsHandler.Instance.MusicMute = value;
            AudioManager.Instance.SetMusicMute(value);
        }

        public void OnEffectsValueChange(float value)
        {
            PlayerPrefsHandler.Instance.EffectsVolume = value;
            AudioManager.Instance.SetEffectsVolume(value);
        }

        public void OnEffectsMute(bool value)
        {
            PlayerPrefsHandler.Instance.EffectsMute = value;
            AudioManager.Instance.SetEffectsMute(value);
        }

        public void Resume()
        {
            UIManager.Instance.SetSettingsPanelState(false);
        }

        private void OnDisable()
        {
            SaveSettings();
            Time.timeScale = 1f;
        }

        private void SaveSettings()
        {
            PlayerPrefsHandler.Instance.Save();
        }

        private void LoadCurrentSettings()
        {
            var handler = PlayerPrefsHandler.Instance;
            musicSlider.value = handler.MusicVolume;
            musicToggle.isOn = handler.MusicMute;
            effectsSlider.value = handler.EffectsVolume;
            effectsToggle.isOn = handler.EffectsMute;
        }

    }
}