using System;
using System.Diagnostics;
using UnityEngine;

namespace GameData
{
    public class RunTimer : MonoBehaviour
    {
        [SerializeField] private TimerData data;
        private bool _paused = false;
        private Stopwatch timer;

        private void Start()
        {
            timer = new Stopwatch();
        }

        private void Update()
        {
            data.Value = timer.Elapsed;

        }

        public void StartTimer()
        {
            timer.Start();
        }

        public void StopTimer()
        {
            timer.Stop();
        }

        public void ResetTimer()
        {
            timer.Reset();
        }

    }
}