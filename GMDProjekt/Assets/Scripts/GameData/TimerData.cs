using System;
using UnityEngine;

namespace GameData
{
    [CreateAssetMenu]
    public class TimerData : ScriptableObject
    {
        public TimeSpan Value;
    }
}