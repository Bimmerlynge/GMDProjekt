using Abilities;
using UnityEngine;

public class LightningDash : MonoBehaviour
{
    [SerializeField] private RuneSO originalRune;
    [SerializeField] private float radius;
    [SerializeField] private Transform hitZone;
    
    private RuneSO activeRune;
    private Particles _particles;
    private Audio _audio;

    public void Awake()
    {
        _particles = GetComponent<Particles>();
        _audio = GetComponent<Audio>();
        activeRune = Instantiate(originalRune);
        gameObject.SetActive(false);
    }

    private void Start()
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
        return Physics.OverlapSphere(hitZone.position, radius, 1 << LayerMask.NameToLayer("Enemy"));
    }

    private void DamageEnemies(Collider[] enemies)
    {
        foreach (var c in enemies)
        {
            c.gameObject.GetComponent<Health>().TakeDamage(activeRune.effectNumber);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.black;
        var position = hitZone == null ? Vector3.zero : hitZone.position;
        Gizmos.DrawWireSphere(position, radius);
    }
}
