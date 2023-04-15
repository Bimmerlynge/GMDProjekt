using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimaryAttack : MonoBehaviour
{
    [SerializeField] private float damage = 10f;
    
    [SerializeField]
    private float _cooldown = 0.5f;

    private float _timer;

   

    public void Activate()
    {
        print("Attacking");
    }

    private void Update()
    {
        _timer += _timer + Time.deltaTime;
    }
}
