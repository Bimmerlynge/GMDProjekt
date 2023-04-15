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
        _dashing = GetComponent<Dashing>();
        _attacking = GetComponent<Attacking>();
        _primaryAttack = GetComponent<PrimaryAttack>();
        //_weapon = GetComponent<WeaponManager>();
    }

    private void Start()
    {
        Movement.IsMovingEvent += SetMovingState;
        Dashing.IsDashingEvent += SetDashingState;
        PlayerInputManager.PrimaryAttackEvent += PrimaryAttack;

    }

    private void PrimaryAttack()
    {
        _attacking.PrimAtk();
        _primaryAttack.Activate();
        _animator.SetTrigger("MeleePrimAtk");
    }

    private void SetDashingState(bool state)
    {
        _animator.SetTrigger("Dash");
        //SetDashParticles(state);
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
