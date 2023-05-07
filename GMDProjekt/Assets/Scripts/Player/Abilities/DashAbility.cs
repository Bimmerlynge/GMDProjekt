using System;
using System.Collections;
using System.Collections.Generic;
using Abilities;
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
    [SerializeField] private float duration = 1f;

    //private DashAnimation _animation;
    //private DashParticles _particles;

    private Anim _animation;
    private Particles _particles;

    private void Awake()
    {
        _rb = GetComponentInParent<Rigidbody>();
        _animation = GetComponent<Anim>();
        _particles = GetComponent<Particles>();
    }

    private void Start()
    {
        currentStacks = maxStacks;
        currentState = State.Ready;
    }

    public void Use()
    {
        if (currentState != State.Ready) return;


        StartCoroutine(Dash());
        StartCoroutine("Cooldown");
    }

    private IEnumerator Dash()
    {
        SetPlayerLayer("Dash");
        _animation.Trigger();
        _particles.StartParticleSystem();
        if (DashEvent != null) DashEvent();
        ApplyForce();

        yield return new WaitForSeconds(duration);
        SetPlayerLayer("Player");
    }

    private void SetPlayerLayer(string layerName)
    {
        int index = LayerMask.NameToLayer(layerName);
        _rb.gameObject.layer = index;
    }

    private void ApplyForce()
    {
        print("applying force");
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
