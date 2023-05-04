using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Movement _movement;
    private Attacking _attacking;
    private Health _health;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _movement = GetComponent<Movement>();
        _health = GetComponent<Health>();
        //_weapon = GetComponent<WeaponManager>();
        _health.OnHealthChanged += UpdateHealthUI;
    }
    
    private void Start()
    {
        Movement.IsMovingEvent += SetMovingState;
        
        
    }

    private void UpdateHealthUI(float value)
    {
        print("player update health");
        UIManager.Instance.GetComponentInChildren<Slider>().value = value;
    }

    // Used by unity animation events
    void AbilityStarted()
    {
        _movement.enabled = false;
    }
    // Used by unity animation events
    void AbilityEnded()
    {
        _movement.enabled = true;
    }

    private void OnDestroy()
    {
        Movement.IsMovingEvent -= SetMovingState;
    }

    

    private void SetMovingState(bool state)
    {
        _animator.SetBool("isMoving", state);
    }
    

    public void AimDirection(Vector3 input, bool isMouse = false)
    {
        _attacking.SetAimDirection(input, isMouse);
    }

    
}
