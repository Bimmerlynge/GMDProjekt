using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class RageMeter : MonoBehaviour
    {
        public delegate void RageMeterFullAction(bool value);

        public static event RageMeterFullAction OnRageMeterFull;
        private Slider _slider;

        private void Awake()
        {
            _slider = GetComponent<Slider>();
        }

        public void UpdateValue(float value)
        {
            if (value >= 1f)
                FireEvent(true);
            else
                FireEvent(false);
        }

        private void FireEvent(bool value)
        {
            if (OnRageMeterFull != null) OnRageMeterFull.Invoke(value);
        }


    }
}