using System;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace.UI
{
    public class GameHUD : MonoBehaviour
    {
        [SerializeField] private Slider playerHealth;
        [SerializeField] private Slider rageMeter;

        private void Start()
        {
            RageAbility.OnRage += ResetRageMeter;
        }

        private void OnDestroy()
        {
            RageAbility.OnRage += ResetRageMeter;
        }

        private void ResetRageMeter()
        {
            rageMeter.value = 0f;
        }

        public void SetHealthBar(float value)
        {
            playerHealth.value = value;
        }

        public void EnableRageMeter()
        {
            rageMeter.gameObject.SetActive(true);
        }

        public void IncrementRage()
        {
            if (rageMeter.enabled == false) return;
            rageMeter.value += 0.1f;
        }
        
        
    }
}