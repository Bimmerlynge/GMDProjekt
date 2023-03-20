using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5f;

    private float currentSpeed;
    private Rigidbody _rb;
    public Vector3 MoveVector { get; set; }
    private Vector3 _moveDirection;

    private bool _isDashing = false;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        currentSpeed = moveSpeed;
    }

    private void Update()
    {
        SetMoveDirection();
    }
    
    void FixedUpdate()
    {
        HandleDash();
        Rotation();
        Move();
    }

    private void Rotation()
    {
        if (_isDashing) return;
        if (MoveVector == Vector3.zero) return;
        var lookRotation = Quaternion.LookRotation(_moveDirection, Vector3.up);
        _rb.MoveRotation(lookRotation);
    }

    private void Move()
    {
        var moveDelta = _moveDirection * currentSpeed * Time.deltaTime;
        _rb.MovePosition(transform.position + moveDelta);
    }

    public void HandleDash()
    {
        if (!_isDashing) return;
        _moveDirection = transform.forward;
    }

    public void SetMoveDirection()
    {
        if (_isDashing) return;
        var matrix = Matrix4x4.Rotate(Quaternion.Euler(0, -45, 0));
        _moveDirection = matrix.MultiplyPoint3x4(MoveVector);
    }
    

    public void SetMoveSpeed(float value)
    {
        currentSpeed = value;
    }

    public void ResetMoveSpeed()
    {
        currentSpeed = moveSpeed;
    }

    public void ToggleDash()
    {
        _isDashing = !_isDashing;
    }


}
