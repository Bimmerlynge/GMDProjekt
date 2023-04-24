using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;


public class Dashing : MonoBehaviour
{

    [SerializeField] private int dashStacks = 2;
    [SerializeField] private bool canDash = true;
    [SerializeField] private float cooldown = 2f;
    [SerializeField] private int currentDashStacks;
    [SerializeField] private float dashForce = 50f;
    [SerializeField] private ParticleSystem dashParticles;
    [SerializeField]
    private Rigidbody _rb;

    public delegate void DashAction(bool state);

    public static event DashAction IsDashingEvent;
    

    private void Start()
    {
        PlayerInputManager.DashEvent += Activate;
        currentDashStacks = dashStacks;
    }

    private void Activate()
    {
        if (!canDash) return;
        HandleAbility();
    }

    private void HandleAbility()
    {
        StopCoroutine(ResetAbility());
        ModifyCurrentDashStacks();
        PerformAbility();
        StartCoroutine(ResetAbility());
    }

    private void PerformAbility()
    {
        if (IsDashingEvent == null) return;
        IsDashingEvent(true);
        _rb.AddForce(transform.forward * dashForce, ForceMode.Impulse);
        StartParticles();
        IsDashingEvent(false);
    }

    private void StartParticles()
    {
        var emission = dashParticles.emission;
        emission.enabled = true;
        dashParticles.Play();
    }

    private IEnumerator ResetAbility()
    {
        yield return new WaitForSeconds(cooldown);
        currentDashStacks = dashStacks;
        canDash = true;
    }

    private void ModifyCurrentDashStacks()
    {
        currentDashStacks--;
        if (currentDashStacks == 0) canDash = false;
    }
    

    // [SerializeField] private float dashDuration = 2f;
    // [SerializeField] private float dashDistance = 2f;
    // [SerializeField] private float dashCooldown = 3f;
    // [SerializeField] private int dashStacks = 2;
    // private float dashTimer = 0.0f;
    //
    // private Rigidbody _rb;
    // private bool _isDashing = false;
    // private bool _canDash = true;
    // [SerializeField]
    // private int _currentDashCount;
    //
    // private Vector3 _dashDirection;
    //
    // private void Awake()
    // {
    //     _rb = GetComponent<Rigidbody>();
    // }
    //
    // private void Start()
    // {
    //     PlayerInputManager.MoveEvent += SetDashDirection;
    //     PlayerInputManager.DashEvent += Dash;
    //
    //     _currentDashCount = dashStacks;
    //
    // }
    // private void FixedUpdate()
    // {
    //     if (!_isDashing) return;
    //     HandleDash();
    // }
    //
    // private void SetDashDirection(Vector2 input)
    // {
    //     if (input == Vector2.zero)
    //         _dashDirection = transform.forward;
    //     else
    //         _dashDirection = input.GetIsometricVector3();
    // }
    // private void Dash()
    // {
    //     if (!_canDash) return;
    //     _isDashing = true;
    //     _canDash = UseDashStack();
    //     dashTimer = 0.0f;
    // }
    //
    // private bool UseDashStack()
    // {
    //     _currentDashCount -= 1;
    //     return _currentDashCount != 0;
    // }
    //
    // private IEnumerator DashCooldownCoroutine()
    // {
    //     yield return new WaitForSeconds(dashCooldown);
    //     _currentDashCount = dashStacks;
    //     _canDash = true;
    // }
    //
    //
    //
    //
    //
    //
    //
    //
    //
    // private Vector3 GetDashLocation()
    // {
    //     Vector3 targetPosition = transform.position + _dashDirection * dashDistance;
    //     return targetPosition;
    // }
    //
    // private void HandleDash()
    // {
    //     if (dashTimer < dashDuration)
    //     {
    //         var targetPosition = GetDashLocation();
    //         var targetDirection = (targetPosition - transform.position);
    //         var dashSpeed = targetDirection.magnitude / dashDuration;
    //         var moveDelta = targetDirection.normalized * (dashSpeed * Time.deltaTime);
    //         _rb.MovePosition(transform.position + moveDelta);
    //         dashTimer += Time.deltaTime;
    //     }
    //     else
    //     {
    //         _isDashing = false;
    //         
    //     }
    // }

}
