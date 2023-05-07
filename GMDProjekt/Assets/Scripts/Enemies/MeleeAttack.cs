using System;
using UnityEngine;

namespace Enemies
{
    public class MeleeAttack : MonoBehaviour
    {
        [SerializeField] private float radius;
        [SerializeField] private Transform hitCenter;
        [SerializeField] private float damage;


        public void Use()
        {
            var enemies = GetEnemiesInRange();
            DamageEnemies(enemies);
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
        

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.black;
            var position = hitCenter == null ? Vector3.zero : hitCenter.position;
            Gizmos.DrawWireSphere(position, radius);
        }
    }
}