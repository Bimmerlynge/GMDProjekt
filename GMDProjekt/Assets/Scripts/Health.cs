using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public delegate void DamageTakenAction();

    public static event DamageTakenAction OnDamageTaken;
    
    [SerializeField] private float maxHealth = 50;
    
    [SerializeField]
    private float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
            Die();
        if (OnDamageTaken != null) OnDamageTaken();
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    public float GetHealthPercentage()
    {
        return currentHealth / maxHealth;
    }
}
