using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public delegate void EnemyDefeated();

    public static event EnemyDefeated EnemyDefeatedEvent;
    private Health _health;
    private Slider _healthBar;

    private void Awake()
    {
        _health = GetComponent<Health>();
        _healthBar = GetComponentInChildren<Slider>();
    }

    private void Start()
    {
        UpdateHealthUI();
        Health.OnDamageTaken += UpdateHealthUI;
    }

    private void OnDestroy()
    {
        if (EnemyDefeatedEvent != null) EnemyDefeatedEvent();
    }

    private void UpdateHealthUI()
    {
        _healthBar.value = _health.GetHealthPercentage();
    }
    
}
