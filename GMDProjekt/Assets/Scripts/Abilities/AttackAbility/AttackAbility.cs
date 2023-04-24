using System;
using System.Collections;
using System.Collections.Generic;
using Abilities.AttackAbility;
using UnityEngine;

public class AttackAbility : MonoBehaviour, IAbility
{
    private enum State
    {
        Ready,
        OnCooldown
    }
    
    [SerializeField] private float damage;
    [SerializeField] private float castRate;
    [SerializeField] private State currentState;
    [SerializeField] private Transform hitZone;
    [SerializeField] private float hitRadius;
    
    private AttackAnimation _animation;
    private void Awake()
    {
        _animation = GetComponentInChildren<AttackAnimation>();
    }
    private void Start()
    {
        currentState = State.Ready;
    }
    public void Use()
    {
        if (currentState != State.Ready) return;
        _animation.Trigger();
        var enemies = GetEnemiesInRange();
        DamageEnemies(enemies);
        StartCoroutine("Cooldown");
    }

    private Collider[] GetEnemiesInRange()
    {
        return Physics.OverlapSphere(hitZone.position, hitRadius, 1 << LayerMask.NameToLayer("Enemy"));
    }

    private void DamageEnemies(Collider[] enemies)
    {
        foreach (var e in enemies)
        {
            e.gameObject.GetComponent<Health>().TakeDamage(damage);
        }
    }
    
    public IEnumerator Cooldown()
    {
        currentState = State.OnCooldown;
        yield return new WaitForSeconds(1.0f / castRate);
        ResetCooldown();
    }

    public void ResetCooldown()
    {
        currentState = State.Ready;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.black;
        var position = hitZone == null ? Vector3.zero : hitZone.transform.position;
        Gizmos.DrawWireSphere(position, hitRadius);
    }
}
