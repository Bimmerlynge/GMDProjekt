using System;
using Abilities;
using UnityEngine;

namespace Projectiles
{
    public class LightningBolt : MonoBehaviour
    {
        public float Damage { get; set; }
        [SerializeField] private float speed;
        private Rigidbody _rb;
        [SerializeField]
        private Particles streak, bolts;
        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
            
        }

        private void Start()
        {
            streak.StartParticleSystem();
            bolts.StartParticleSystem();
            _rb.velocity = transform.forward * speed;
        }

        private void OnTriggerEnter(Collider other)
        {
            print("bolt hit something");
            var health = other.GetComponent<Health>();
            if (health == null) return;
            health.TakeDamage(Damage);
            Destroy(gameObject);
        }

       

    }
}