using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(Movement))]
public class Attacking : MonoBehaviour
{
    private Movement _movement;
    private WeaponManager _weaponManager;
    private Vector3 _aimDirection;
    private bool _isAttacking;
    private Rigidbody _rb;

    private void Awake()
    {
        _movement = GetComponent<Movement>();
        _weaponManager = GetComponentInChildren<WeaponManager>();
        _rb = GetComponent<Rigidbody>();
    }

    public void SetAimDirection(Vector3 aimInput, bool isMouse)
    {
        if (aimInput == Vector3.zero) return;
        if (isMouse)
        {
            _aimDirection = aimInput;
        }
        else
        {
            var matrix = Matrix4x4.Rotate(Quaternion.Euler(0, -45, 0));
            _aimDirection = matrix.MultiplyPoint3x4(aimInput);
        }
    }

    private void Update()
    {
        
    }

    private void Rotate()
    {
        Debug.DrawRay(transform.position, _aimDirection * 10, Color.magenta);
        var aimRotation = Quaternion.LookRotation(_aimDirection, Vector3.up);
        _rb.MoveRotation(aimRotation);
    }

    public void PrimAtk()
    {
        StartCoroutine(AttackCoroutine());
    }

    private IEnumerator AttackCoroutine()
    {
        ToggleMovement(false);
        Rotate();
        yield return new WaitForSeconds(1.5f);
        ToggleMovement(true);
    }

    private void ToggleMovement(bool value)
    {
        _movement.enabled = value;
    }
}
