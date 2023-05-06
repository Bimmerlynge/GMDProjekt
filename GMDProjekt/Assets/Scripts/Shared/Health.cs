using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    //public delegate void DamageTakenAction();

    //public static event DamageTakenAction OnDamageTaken;
    [SerializeField] private float maxHealth = 50;
    
    [SerializeField]
    private float currentHealth;

    public delegate void OnDeathAction(GameObject thisObj);

    public static event OnDeathAction OnDeathEvent;
    public event Action<float> OnHealthChanged;
    private void Start()
    {
        currentHealth = maxHealth;
        FireHealthChange();
    }

    private void FireHealthChange()
    {
        if (OnHealthChanged != null) OnHealthChanged.Invoke(GetHealthPercentage());
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
            Die();
        FireHealthChange();
       // if (OnDamageTaken != null) OnDamageTaken();
    }

    public void AddHealth(float amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth) currentHealth = maxHealth;
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
