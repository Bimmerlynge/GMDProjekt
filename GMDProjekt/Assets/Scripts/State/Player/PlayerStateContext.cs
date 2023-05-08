using System;
using GameData;
using Player.Abilities;
using UnityEngine;

namespace State.Player
{
    public class PlayerStateContext : MonoBehaviour
    {
        public IdleState IdleState;
        public ReadyState ReadyState;
        public AttackState AttackState;
        public SpecialState SpecialState;
        public DashState DashState;
        public RageState RageState;
        private IPlayerState _currentState;

        private Movement _movement;
        private AbilityController _abilityController;
        private Animator _animator;

        [SerializeField] private PlayerAbilityState _abilityState;
        private void Awake()
        {
            _movement = GetComponent<Movement>();
            _animator = GetComponent<Animator>();
            IdleState = new IdleState();
            ReadyState = new ReadyState(this, _movement, _animator);
            //DashState = new DashState();
        }

        private void Start()
        {
            _currentState = ReadyState;
            _currentState.Enter();
        }

        public void SetState(IPlayerState state)
        {
            _currentState = state;
            _currentState.Enter();
        }
    }
}