using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5f;
    
    private Rigidbody _rb;
    public Vector3 MoveVector { get; set; }
    private Vector3 _moveDirection;
    
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }
    

    private void Update()
    {
        SetMoveDirection();
    }
    
    void FixedUpdate()
    {
        //HandleDash();
        Rotation();
        Move();
    }
    

    private void Rotation()
    {
        if (MoveVector == Vector3.zero) return;
        var lookRotation = Quaternion.LookRotation(_moveDirection, Vector3.up);
        _rb.MoveRotation(lookRotation);
    }

    private void Move()
    {
        var moveDelta = _moveDirection * moveSpeed * Time.deltaTime;
        _rb.MovePosition(transform.position + moveDelta);
    }
    

    public void SetMoveDirection()
    {
        var matrix = Matrix4x4.Rotate(Quaternion.Euler(0, -45, 0));
        _moveDirection = matrix.MultiplyPoint3x4(MoveVector);
    }
    

}
