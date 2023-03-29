using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Movement _movement;
    private Dashing _dashing;
    private Attacking _attacking;
    [SerializeField]
    private WeaponManager _weapon;

    

    private void Awake()
    {
        _movement = GetComponent<Movement>();
        _dashing = GetComponent<Dashing>();
        _attacking = GetComponent<Attacking>();
        //_weapon = GetComponent<WeaponManager>();
    }

    public void PrimaryAttack()
    {
        _attacking.PrimAtk();
    }

    public void AimDirection(Vector3 input, bool isMouse = false)
    {
        _attacking.SetAimDirection(input, isMouse);
    }



    public void SetMoveDirection(Vector2 input)
    {
        _movement.MoveVector = new Vector3(input.x, 0, input.y);
    }
    
    
    public void Dash()
    {
        _dashing.Dash();
    }
}
