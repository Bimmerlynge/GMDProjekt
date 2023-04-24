using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityManager : MonoBehaviour
{
    private DashAbility _dashAbility;
    private AttackAbility _attackAbility;
    private Animator _animator;
    

    private void Awake()
    {
        _animator = GetComponentInParent<Animator>();
        _dashAbility = GetComponentInChildren<DashAbility>();
        _attackAbility = GetComponentInChildren<AttackAbility>();
    }
    

    private void Start()
    {
        PlayerInputManager.PrimaryAttackEvent += OnPrimaryAttack;
        PlayerInputManager.OnSpecialAttackEvent += OnSpecialAttack;
        PlayerInputManager.DashEvent += OnDashEvent;
    }

    void OnPrimaryAttack()
    {
        
        print("Attack");
        _attackAbility.Use();
    }

    void OnSpecialAttack()
    {
        
        print("AxeSpecial");
        _animator.SetTrigger("AxeSpecial");
    }

    void OnDashEvent()
    {
        _dashAbility.Use();
        //_animator.SetTrigger("Dash");
    }
}
