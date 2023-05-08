using System;
using GameData;
using TMPro;
using UnityEngine;

namespace UI
{
    public class EndGame : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI runtime;
        [SerializeField] private TimerData timerData;


        private void Start()
        {
            FreezeTime();
            SetRuntimeText();
            
        }

        private void OnDisable()
        {
            Time.timeScale = 1f;
        }

        private void SetRuntimeText()
        {
            runtime.text = $"Time: {Minutes()}:{Seconds()}:{Millis()}";
        }

        public void MainMenu()
        {
            gameObject.SetActive(false);
            SceneLoader.Instance.LoadMainMenu();
        }
        
        private void FreezeTime()
        {
            Time.timeScale = 0f;
        }


        private string Minutes()
        {
            var minutes = timerData.Value.Minutes;
            return $"{(minutes > 9 ? minutes : "0" + minutes)}";
        }

        private string Seconds()
        {
            var seconds = timerData.Value.Seconds;
            return $"{(seconds > 9 ? seconds : "0" + seconds)}";
        }

        private string Millis()
        {
            var millis = MathF.Round(timerData.Value.Milliseconds / 10f);
            return $"{(millis > 9 ? millis : "0" + millis)}";
        }

    }
}