using UnityEngine;

namespace Shared
{
    public class Anim : MonoBehaviour, IAnimation
    {
        [SerializeField] private string triggerName;
        private Animator _animator;
        public void Awake()
        {
            _animator = GetComponentInParent<Animator>();
        }

        public void Trigger()
        {
            _animator.SetTrigger(triggerName);
        }

        public void SetState(bool value)
        {
            _animator.SetBool(triggerName, value);
        }
    }
}