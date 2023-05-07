using GameData;
using UnityEngine;

namespace State.Player
{
    public class DashState : IPlayerState
    {
        private PlayerStateContext _context;
        private Animator _animator;
        private PlayerAbilityState _abilityState;

        public DashState(PlayerStateContext context, Animator animator, PlayerAbilityState abilityState)
        {
            _context = context;
            _animator = animator;
            
        }
        
        public void Enter()
        {
            Debug.Log("We in da dash state yeet");
        }
    }
}