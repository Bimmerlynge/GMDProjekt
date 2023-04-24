using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Movement _movement;
    private Dashing _dashing;
    private Attacking _attacking;
    [SerializeField]
    private WeaponManager _weapon;

    private Animator _animator;
    private PrimaryAttack _primaryAttack;
    
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _movement = GetComponent<Movement>();
        //_weapon = GetComponent<WeaponManager>();
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

    private void Start()
    {
        Movement.IsMovingEvent += SetMovingState;
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
