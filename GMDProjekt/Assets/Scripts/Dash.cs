using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Movement))]
public class Dash : MonoBehaviour
{
    [SerializeField] private float dashSpeed = 10f;
    [SerializeField] private float dashTime = 2f;
    private Movement _movement;

    private void Awake()
    {
        _movement = GetComponent<Movement>();
    }

    public void Dashing()
    {
        StartCoroutine(DashCoroutine());
    }

    IEnumerator DashCoroutine()
    {
        _movement.ToggleDash();
        _movement.SetMoveDirection();
        _movement.SetMoveSpeed(dashSpeed);
    
        yield return new WaitForSeconds(dashTime);
        
        _movement.ToggleDash();
        _movement.SetMoveDirection();
        _movement.ResetMoveSpeed();
    }
}
