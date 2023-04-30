using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityController : MonoBehaviour
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
        PlayerInputController.PrimaryAttackEvent += OnPrimaryAttack;
        PlayerInputController.OnSpecialAttackEvent += OnSpecialAttack;
        PlayerInputController.DashEvent += OnDashEvent;
    }

    private void OnDestroy()
    {
        PlayerInputController.PrimaryAttackEvent -= OnPrimaryAttack;
        PlayerInputController.OnSpecialAttackEvent -= OnSpecialAttack;
        PlayerInputController.DashEvent -= OnDashEvent;
    }

    void OnPrimaryAttack()
    {
        _attackAbility.Use();
    }

    void OnSpecialAttack()
    {
        _animator.SetTrigger("AxeSpecial");
    }

    void OnDashEvent()
    {
        _dashAbility.Use();
    }
}
