using System.Collections;
using Abilities;
using Managers;
using UnityEngine;

namespace Player.Abilities
{
    public class SpecialAbility : MonoBehaviour, IAbility
    {
        private enum State
        {
            Ready,
            OnCooldown
        }
        [SerializeField] private State currentState;
    
        [SerializeField] private float damage;
        [SerializeField] private float castRate;
        [SerializeField] private float abilityRadius;

        [SerializeField] private float particleDelay;

        public delegate void SpecialAction();

        public static event SpecialAction SpecialEvent;
    
        private Anim _animation;
        private Particles _particles;
    
        private void Awake()
        {
            _animation = GetComponent<Anim>();
            _particles = GetComponent<Particles>();
        }
    
        private void Start()
        {
            currentState = State.Ready;
        }
        public void Use()
        {
            if (currentState != State.Ready) return;
            _animation.Trigger();
            Invoke("Playparticles", particleDelay);
            StartCoroutine("Cooldown");
        }

        private void Playparticles()
        {
            _particles.StartParticleSystem();
        }

        public IEnumerator Cooldown()
        {
            currentState = State.OnCooldown;
            yield return new WaitForSeconds(1.0f / castRate);
            ResetCooldown();
        }

        public void TriggerDamage()
        {
            FireEvent();
            var enemies = GetEnemiesInRange();
            DamageEnemies(enemies);
        }

        public void ResetCooldown()
        {
            currentState = State.Ready;
        }

        public void FireEvent()
        {
            if (SpecialEvent != null) SpecialEvent();
        }

        private Collider[] GetEnemiesInRange()
        {
            return Physics.OverlapSphere(transform.position, abilityRadius, 1 << LayerMask.NameToLayer("Enemy"));
        }

        private void DamageEnemies(Collider[] enemies)
        {
            UIManager.Instance.IncrementRage();
            foreach (var c in enemies)
            {
                c.gameObject.GetComponent<Health>().TakeDamage(damage);
            }
        }
    }
}
