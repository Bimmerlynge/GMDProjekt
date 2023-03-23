using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.XR.GoogleVr;
using UnityEngine;

[RequireComponent(typeof(Movement))]
public class Dashing : MonoBehaviour
{
    [SerializeField] private float dashDuration = 2f;
    [SerializeField] private float dashDistance = 2f;

    private float dashTimer = 0.0f;
    
    private Movement _movement;
    private Rigidbody _rb;
    private bool _isDashing;

    private void Awake()
    {
        _movement = GetComponent<Movement>();
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (!_isDashing) return;

        HandleDash();
        
        
    }

    private void HandleDash()
    {
        if (dashTimer < dashDuration)
        {
            var targetPosition = GetDashLocation();
            var targetDirection = (targetPosition - transform.position);
            var dashSpeed = targetDirection.magnitude / dashDuration;
            var moveDelta = targetDirection.normalized * dashSpeed * Time.deltaTime;
            _rb.MovePosition(transform.position + moveDelta);
            dashTimer += Time.deltaTime;
        }
        else
        {
            _isDashing = false;
            _movement.enabled = true;
        }
    }
    

    public void Dash()
    {
        print("DASH");
        _movement.enabled = false;
        _isDashing = true;
        dashTimer = 0.0f;
    }
    

    private Vector3 GetDashLocation()
    {
        Vector3 targetPosition = transform.position + transform.forward * dashDistance;
        return targetPosition;
    }
    
}
