using UnityEngine;

namespace Abilities
{
    public class Particles : MonoBehaviour, IParticleSystem
    {
        [SerializeField]
        private ParticleSystem particleSystem;
        
        
        public void StartParticleSystem()
        {
            var emission = particleSystem.emission;
            emission.enabled = true;
            particleSystem.Play();
        }

        public void StopParticleSystem()
        {
            particleSystem.Stop();
        }
    }
}