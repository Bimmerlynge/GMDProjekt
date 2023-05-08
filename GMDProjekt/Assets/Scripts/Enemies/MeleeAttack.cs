using System;
using UnityEngine;

namespace Enemies
{
    public class MeleeAttack : MonoBehaviour
    {
        [SerializeField] private float radius;
        [SerializeField] private Transform hitCenter;
        [SerializeField] private float damage;

        public void Attack()
        {
            var enemies = GetEnemiesInRange();
            DamageEnemies(enemies);
        }
        public void Use()
        {
            
        }

        private Collider[] GetEnemiesInRange()
        {
            return Physics.OverlapSphere(hitCenter.position, radius, 1 << LayerMask.NameToLayer("Player"));
        }
        
        private void DamageEnemies(Collider[] enemies)
        {
            foreach (var e in enemies)
            {
                e.gameObject.GetComponent<Health>().TakeDamage(damage);
            }
        }
    }
}