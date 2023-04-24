using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningDash : MonoBehaviour
{
    [SerializeField] private float duration;
    [SerializeField] private float damage;
    [SerializeField] private float radius;

    [SerializeField] private ParticleSystem particleEffect;
    [SerializeField] private Transform hitZone;
    
    private void Start()
    {
        DashAbility.DashEvent += ApplyEffect;
    }

    private void ApplyEffect()
    {
        StartParticleSystem();
        var enemies = GetEnemiesInRange();
        DamageEnemies(enemies);
    }

    private void StartParticleSystem()
    {
        var emission = particleEffect.emission;
        emission.enabled = true;
        particleEffect.Play();
    }

    private Collider[] GetEnemiesInRange()
    {
        return Physics.OverlapSphere(hitZone.position, radius, 1 << LayerMask.NameToLayer("Enemy"));
    }

    private void DamageEnemies(Collider[] enemies)
    {
        foreach (var c in enemies)
        {
            c.gameObject.GetComponent<Health>().TakeDamage(damage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.black;
        var position = hitZone == null ? Vector3.zero : hitZone.position;
        Gizmos.DrawWireSphere(position, radius);
    }
}
