using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public delegate void EnemyDefeated();

    public static event EnemyDefeated EnemyDefeatedEvent;
    private Health _health;

    private void Awake()
    {
        _health = GetComponent<Health>();
    }

    private void OnDestroy()
    {
        if (EnemyDefeatedEvent != null) EnemyDefeatedEvent();
    }
}
