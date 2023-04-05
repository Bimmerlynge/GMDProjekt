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

    

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _movement = GetComponent<Movement>();
        _dashing = GetComponent<Dashing>();
        _attacking = GetComponent<Attacking>();
        //_weapon = GetComponent<WeaponManager>();
    }

    private void Start()
    {
        Movement.IsMovingEvent += SetMovingState;
        
    }

    private void SetMovingState(bool state)
    {
        _animator.SetBool("isMoving", state);
    }

    public void PrimaryAttack()
    {
        _attacking.PrimAtk();
    }

    public void AimDirection(Vector3 input, bool isMouse = false)
    {
        _attacking.SetAimDirection(input, isMouse);
    }

    
}
