using System;
using UnityEngine;

namespace Shared
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private float maxHealth = 50;
        [SerializeField] private float currentHealth;

        public float CurrentHealth => currentHealth;
        public delegate void OnDeathAction(GameObject thisObj);

        public static event OnDeathAction OnDeathEvent;
        public event Action<float> OnHealthChanged;
    

        private void Start()
        {
            if (currentHealth == 0)
                SetHealth(maxHealth);
        }

        public void SetHealth(float value)
        {
            currentHealth = value;
            FireHealthChange();
        }

        private void FireHealthChange()
        {
            if (OnHealthChanged != null) OnHealthChanged.Invoke(GetHealthPercentage());
        }

        public void TakeDamage(float amount)
        {
            var newValue = currentHealth - amount;
            SetHealth(newValue);
            if (currentHealth <= 0)
                Die();
        
        }

        public void AddHealth(float amount)
        {
            var newValue = currentHealth + amount;
            SetHealth(newValue);
            if (currentHealth > maxHealth)
            {
                SetHealth(maxHealth);
            }
        }

        private void Die()
        {
            if (OnDeathEvent != null) OnDeathEvent.Invoke(gameObject);
        }
    
        private float GetHealthPercentage()
        {
            return currentHealth / maxHealth;
        }
    }
}
