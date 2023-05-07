using System.Collections.Generic;
using System.Net.NetworkInformation;
using GameData;
using UnityEngine;

namespace State.Player
{
    public class ReadyState : IPlayerState
    {
        private PlayerStateContext _context;
        private Movement _movement;
        private Animator _animator;

        public ReadyState(PlayerStateContext context, Movement movement, Animator animator)
        {
            _context = context;
            _movement = movement;
            _animator = animator;
        }

        public void Enter()
        {
            _movement.enabled = true;
            PlayerInputController.OnAbilityInput += HandleAbility;
        }

        private void HandleAbility(AbilityType type)
        {
            IPlayerState nextState = type switch
            {
                AbilityType.Attack => _context.AttackState,
                AbilityType.Special => _context.SpecialState,
                AbilityType.Dash => _context.DashState,
                AbilityType.Rage => _context.RageState
            };
            
            
            _movement.enabled = false;
            _context.SetState(nextState);
        }


    }
}