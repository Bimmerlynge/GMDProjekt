using System;
using UnityEngine;
using UnityEngine.UI;

namespace Enemies
{
    public class EnemyUI : MonoBehaviour
    {
        private Health _health;
        private Slider healthBar;

        private void Awake()
        {
            healthBar = GetComponentInChildren<Slider>();
            _health = GetComponent<Health>();
            _health.OnHealthChanged += UpdateUI;
        }

        private void OnDestroy()
        {
            _health.OnHealthChanged -= UpdateUI;
        }

        private void UpdateUI(float value)
        {
            healthBar.value = value;
        }
    }
    
    
}