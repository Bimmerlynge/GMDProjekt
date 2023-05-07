using System;
using System.Collections;
using System.Collections.Generic;
using GameData;
using UnityEngine;

public class AbilityController : MonoBehaviour
{
    private DashAbility _dashAbility;
    private AttackAbility _attackAbility;
    private SpecialAbility _specialAbility;
    private RageAbility _rageAbility;

    private Dictionary<AbilityType, Action> abilityMap;

    private Animator _animator;
    
    [SerializeField] private PlayerAbilityState _abilityState;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _dashAbility = GetComponentInChildren<DashAbility>();
        _attackAbility = GetComponentInChildren<AttackAbility>();
        _specialAbility = GetComponentInChildren<SpecialAbility>();
        _rageAbility = GetComponentInChildren<RageAbility>();

        InitAbilityMap();
    }

    private void InitAbilityMap()
    {
        abilityMap = new Dictionary<AbilityType, Action>
        {
            { AbilityType.Attack, () => _attackAbility.Use() },
            { AbilityType.Special, () => _specialAbility.Use() },
            { AbilityType.Dash, () => _dashAbility.Use() },
            { AbilityType.Rage, () => {} }
        };
    }


    private void Start()
    {
        PlayerInputController.OnAbilityInput += HandleInput;
    }
    private void OnDestroy()
    {
        PlayerInputController.OnAbilityInput -= HandleInput;
    }

    private void HandleInput(AbilityType type)
    {
        _abilityState.currentState = PlayerAbilityState.AbilityState.Busy;

        if (abilityMap.TryGetValue(type, out var action))
        {
            action.Invoke();
        }
    }

    public void AnimationFinished()
    {
        _abilityState.currentState = PlayerAbilityState.AbilityState.Ready;
    }

    public void TriggerSpecialDamage()
    {
        _specialAbility.TriggerDamage();
    }

    
}
