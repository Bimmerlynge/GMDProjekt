using System;
using GameData;
using TMPro;
using UnityEngine;

namespace UI
{
    public class TimerUI : MonoBehaviour
    {
        [SerializeField] private TimerData timerData;
        [SerializeField] private TextMeshProUGUI text;
        private void LateUpdate()
        {
            text.text = $"Time: {Minutes()}:{Seconds()}:{Millis()}";
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