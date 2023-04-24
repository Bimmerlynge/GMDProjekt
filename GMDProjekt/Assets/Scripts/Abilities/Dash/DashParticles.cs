using UnityEngine;

namespace Abilities.Dash
{
    public class DashParticles : MonoBehaviour, IParticleSystem
    {
        private ParticleSystem _particleSystem;
        public void Start()
        {
            _particleSystem = GetComponentInChildren<ParticleSystem>();
        }

        public void StartParticleSystem()
        {
            var emission = _particleSystem.emission;
            emission.enabled = true;
            _particleSystem.Play();
        }

        public void StopParticleSystem()
        {
            _particleSystem.Stop();
        }
    }
}