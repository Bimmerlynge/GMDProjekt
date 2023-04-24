using UnityEngine;

namespace Abilities.AttackAbility
{
    public class AttackAnimation : MonoBehaviour, IAnimation
    {
        
        private Animator _animator;

        public void Awake()
        {
            _animator = GetComponentInParent<Animator>();
        }

        public void Trigger()
        {
            _animator.SetTrigger("MeleePrimAtk");
        }
    }
}