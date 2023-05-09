using System;
using System.Collections.Generic;
using GameData;
using Managers;
using UI;
using UnityEngine;

namespace Player.Abilities
{
    public class AbilityController : MonoBehaviour
    {
        private DashAbility _dashAbility;
        private AttackAbility _attackAbility;
        private SpecialAbility _specialAbility;
        private RageAbility _rageAbility;

        private Dictionary<AbilityType, Action> abilityMap;

        private bool _canRage;
        [SerializeField]
        private PlayerAbilityState abilityState;
        private void Awake()
        {
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
                { AbilityType.Attack, Attack },
                { AbilityType.Special, Special },
                { AbilityType.Dash, Dash },
                { AbilityType.Rage, Rage }
            };
        }
    
        private void Start()
        {
            PlayerInputController.OnAbilityInput += HandleInput;
            RageMeter.OnRageMeterFull += CanRage;
        }
        private void OnDestroy()
        {
            PlayerInputController.OnAbilityInput -= HandleInput;
            RageMeter.OnRageMeterFull -= CanRage;
        }

        private void CanRage(bool value)
        {
            _canRage = value;
        }

        private void HandleInput(AbilityType type)
        {
            if (abilityMap.TryGetValue(type, out var action))
            {
                action.Invoke();
            }
        }

        private void SetBusyState()
        {
            abilityState.currentState = PlayerAbilityState.AbilityState.Busy;
        }

        private void Attack()
        {
            SetBusyState();
            _attackAbility.Use();
        }

        private void Special()
        {
            SetBusyState();
            _specialAbility.Use();
        }

        private void Dash()
        {
            SetBusyState();
            _dashAbility.Use();
        }

        private void Rage()
        {
            if (!GetRageValue()) return;
            SetBusyState();
            _rageAbility.Use();
        }

        private bool GetRageValue()
        {
            return UIManager.Instance.GetRageValue();
        }

        // Unity animation event
        public void AnimationFinished()
        {
            abilityState.currentState = PlayerAbilityState.AbilityState.Ready;
        }

        public void TriggerSpecialDamage()
        {
            _specialAbility.TriggerDamage();
        }

    
    }
}
