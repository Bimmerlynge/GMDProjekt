using System;
using GameData;
using UnityEngine;
using UnityEngine.EventSystems;
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
            SetFirstSelected();
            LoadCurrentSettings();
            FreezeTime();
        }

        private void SetFirstSelected()
        {
            var eventSystem = EventSystem.current;
            eventSystem.SetSelectedGameObject(musicSlider.gameObject);
        }

        private void OnDisable()
        {
            SaveSettings();
            Time.timeScale = 1f;
            GameStateHandler.Instance.StartTimer();
        }
        private void FreezeTime()
        {
            Time.timeScale = 0f;
            GameStateHandler.Instance.StopTimer();
        }

        public void MainMenu()
        {
            gameObject.SetActive(false);
            SceneLoader.Instance.LoadMainMenu();
        }

        public void ExitGame()
        {
            Application.Quit();
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