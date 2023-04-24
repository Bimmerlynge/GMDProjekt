using System;
using System.Collections;
using System.Collections.Generic;
using Abilities.Dash;
using UnityEngine;

public class DashAbility : MonoBehaviour, IAbility
{
    public delegate void DashAction();

    public static event DashAction DashEvent;
    
    private enum State
    {
        Ready,
        OnCooldown
    }
    private Rigidbody _rb;
    [SerializeField] private float dashForce;
    [SerializeField] private int maxStacks = 2;
    [SerializeField] private int currentStacks;
    [SerializeField] private State currentState;
    [SerializeField] private int castRate;

    private DashAnimation _animation;
    private DashParticles _particles;

    private void Awake()
    {
        _rb = GetComponentInParent<Rigidbody>();
        _animation = GetComponent<DashAnimation>();
        _particles = GetComponent<DashParticles>();
    }

    private void Start()
    {
        currentStacks = maxStacks;
        currentState = State.Ready;
    }

    public void Use()
    {
        if (currentState != State.Ready) return;
        _animation.Trigger();
        _particles.StartParticleSystem();
        if (DashEvent != null) DashEvent();
        ApplyForce();
        //_particles.StopParticleSystem();
        StartCoroutine("Cooldown");
    }

    private void ApplyForce()
    {
        _rb.AddForce(transform.forward * dashForce, ForceMode.Impulse);
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
}
