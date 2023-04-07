using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5f;
    
    private Rigidbody _rb;
    private Vector3 _moveDirection;
    private Vector3 _orientation;

    private bool _canMove = true;

    public delegate void IsMovingAction(bool state);
    public static event IsMovingAction IsMovingEvent;
    
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        PlayerInputManager.MoveEvent += HandleMoveInput;
    }
    void FixedUpdate()
    {
        if (!_canMove) return;
        Rotation();
        Move();
    }
    

    private void Rotation()
    {
        var lookRotation = Quaternion.LookRotation(_orientation, Vector3.up);
        _rb.MoveRotation(lookRotation);
    }

    private void Move()
    {
        var moveDelta = _moveDirection * (moveSpeed * Time.deltaTime);
        _rb.MovePosition(transform.position + moveDelta);
    }

    private void HandleMoveInput(Vector2 input)
    {
        if (IsMovingEvent != null)
        {
            IsMovingEvent(input != Vector2.zero);
        }

        SetMoveDirection(input);
        SetOrientation();
    }

    private void SetOrientation()
    {
        if (_moveDirection == Vector3.zero)
            _orientation = transform.forward;
        else
            _orientation = _moveDirection;
    }

    private void SetMoveDirection(Vector2 input)
    {
        _moveDirection = input.GetIsometricVector3();
    }
    

}
