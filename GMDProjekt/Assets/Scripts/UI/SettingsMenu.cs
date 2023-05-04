using System;
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
            AudioManager.Instance.SetMusicVolume(value);
        }

        public void OnMusicMute(bool value)
        {
            AudioManager.Instance.SetMusicMute(value);
        }

        public void OnEffectsValueChange(float value)
        {
            AudioManager.Instance.SetEffectsVolume(value);
        }

        public void OnEffectsMute(bool value)
        {
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
            PlayerPrefs.SetFloat("musicSlider", musicSlider.value);
            PlayerPrefs.SetInt("musicToggle", musicToggle.isOn ? 1 : 0);
            PlayerPrefs.SetFloat("effectsSlider", effectsSlider.value);
            PlayerPrefs.SetInt("effectsToggle", effectsToggle.isOn ? 1 : 0);
        }

        private void LoadCurrentSettings()
        {
            musicSlider.value = PlayerPrefs.GetFloat("musicSlider");
            musicToggle.isOn = PlayerPrefs.GetInt("musicToggle") == 1;
            effectsSlider.value = PlayerPrefs.GetFloat("effectsSlider");
            effectsToggle.isOn = PlayerPrefs.GetInt("effectsToggle") == 1;
        }

    }
}