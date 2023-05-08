using System;
using Abilities;
using UnityEngine;

namespace Projectiles
{
    public class LightningStrike : MonoBehaviour
    {
        private Particles _particles;

        private void Awake()
        {
            _particles = GetComponent<Particles>();
        }

        private void Start()
        {
            _particles.StartParticleSystem();
            Invoke("Die", 1.5f);
        }

        private void Die()
        {
            Destroy(gameObject);
        }
    }
}