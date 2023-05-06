using System;
using System.Collections;
using System.Collections.Generic;
using Abilities;
using UnityEngine;

public class SpecialAbility : MonoBehaviour
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
        if (SpecialEvent != null) SpecialEvent();
        var enemies = GetEnemiesInRange();
        DamageEnemies(enemies);
    }

    public void ResetCooldown()
    {
        currentState = State.Ready;
    }
    
    private Collider[] GetEnemiesInRange()
    {
        return Physics.OverlapSphere(transform.position, abilityRadius, 1 << LayerMask.NameToLayer("Enemy"));
    }

    private void DamageEnemies(Collider[] enemies)
    {
        foreach (var c in enemies)
        {
            c.gameObject.GetComponent<Health>().TakeDamage(damage);
        }
    }
}
