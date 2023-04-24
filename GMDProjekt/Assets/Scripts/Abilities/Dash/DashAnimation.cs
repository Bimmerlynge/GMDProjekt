using UnityEngine;

namespace Abilities.Dash
{
    public class DashAnimation : MonoBehaviour, IAnimation
    {
        private Animator _animator;

        public void Awake()
        {
            _animator = GetComponentInParent<Animator>();
        }

        public void Trigger()
        {
            _animator.SetTrigger("Dash");
        }
    }
}