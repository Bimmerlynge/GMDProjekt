using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Health _health;

    private void Awake()
    {
        _health = GetComponent<Health>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerAtk"))
        {
            
        }
    }
}
