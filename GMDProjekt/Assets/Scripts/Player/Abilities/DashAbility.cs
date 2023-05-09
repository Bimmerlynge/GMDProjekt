using System.Collections;
using Player.Abilities;
using Shared;
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
    [SerializeField] private State currentState;
    [SerializeField] private int castRate;
    [SerializeField] private float cooldown = 1f;
    

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
        FireEvent();
        ApplyForce();

        yield return new WaitForSeconds(cooldown);
        SetPlayerLayer("Player");
    }

    private void SetPlayerLayer(string layerName)
    {
        int index = LayerMask.NameToLayer(layerName);
        _rb.gameObject.layer = index;
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

    public void FireEvent()
    {
        if (DashEvent != null) DashEvent();
    }
}
