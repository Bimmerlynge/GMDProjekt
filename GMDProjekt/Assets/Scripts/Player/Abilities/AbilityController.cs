using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityController : MonoBehaviour
{
    private DashAbility _dashAbility;
    private AttackAbility _attackAbility;
    private SpecialAbility _specialAbility;
    private Animator _animator;
    

    private void Awake()
    {
        _animator = GetComponentInParent<Animator>();
        _dashAbility = GetComponentInChildren<DashAbility>();
        _attackAbility = GetComponentInChildren<AttackAbility>();
        _specialAbility = GetComponentInChildren<SpecialAbility>();
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
        _specialAbility.Use();
    }

    void OnDashEvent()
    {
        _dashAbility.Use();
    }

    public void TriggerSpecialDamage()
    {
        _specialAbility.TriggerDamage();
    }
}
