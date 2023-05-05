using Abilities;
using UnityEngine;
using UnityEngine.Serialization;

public class LightningDash : MonoBehaviour
{
    [SerializeField] private RuneSO originalSO;
    [SerializeField] private float radius;
    
    
    private RuneSO activeRune;
    private Particles _particles;
    private SoundEffect _audio;

    public void Awake()
    {
        _particles = GetComponent<Particles>();
        _audio = GetComponent<SoundEffect>();
        activeRune = Instantiate(originalSO);
        //gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        DashAbility.DashEvent += ApplyEffect;
    }

    private void OnDisable()
    {
        DashAbility.DashEvent -= ApplyEffect;
    }

    private void ApplyEffect()
    {
        _audio.PlayClip();
        _particles.StartParticleSystem();
        var enemies = GetEnemiesInRange();
        DamageEnemies(enemies);
    }

    private Collider[] GetEnemiesInRange()
    {
        return Physics.OverlapSphere(transform.position, radius, 1 << LayerMask.NameToLayer("Enemy"));
    }

    private void DamageEnemies(Collider[] enemies)
    {
        foreach (var c in enemies)
        {
            c.gameObject.GetComponent<Health>().TakeDamage(activeRune.effectNumber);
        }
    }
    
}
