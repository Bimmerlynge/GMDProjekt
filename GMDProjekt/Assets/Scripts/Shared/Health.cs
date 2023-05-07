using System;
using GameData;
using UnityEngine;


public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth = 50;
    [SerializeField] private float currentHealth;
    [SerializeField]
    private HealthData _healthData;

    public delegate void OnDeathAction(GameObject thisObj);

    public static event OnDeathAction OnDeathEvent;
    public event Action<float> OnHealthChanged;
    private void Start()
    {
        LoadHealth();
        FireHealthChange();
    }

    private void LoadHealth()
    {
        var data = _healthData.GetHealth(gameObject);
        if ( data == -1)
        {
            UpdateHealthData(maxHealth);
            return;
        }
        currentHealth = data;
    }

    private void UpdateHealthData(float value)
    {
        currentHealth = value;
        _healthData.SetHealth(gameObject, value);
    }

    private void FireHealthChange()
    {
        if (OnHealthChanged != null) OnHealthChanged.Invoke(GetHealthPercentage());
    }

    public void TakeDamage(float amount)
    {
        var newValue = currentHealth - amount;
        UpdateHealthData(newValue);
        if (currentHealth <= 0)
            Die();
        FireHealthChange();
    }

    public void AddHealth(float amount)
    {
        var newValue = currentHealth + amount;
        UpdateHealthData(newValue);
        if (currentHealth > maxHealth)
        {
            UpdateHealthData(maxHealth);
        }
        FireHealthChange();
    }

    private void Die()
    {
        _healthData.RemoveEntry(gameObject);
        if (OnDeathEvent != null) OnDeathEvent.Invoke(gameObject);
    }
    
    private float GetHealthPercentage()
    {
        return currentHealth / maxHealth;
    }
}
