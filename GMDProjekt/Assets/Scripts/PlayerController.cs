using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Movement _movement;
    private Dash _dash;
    private Weapon _weapon;

    

    private void Awake()
    {
        _movement = GetComponent<Movement>();
        _dash = GetComponent<Dash>();
        _weapon = GetComponent<Weapon>();
    }

    public void PrimaryAttack()
    {
        _weapon.PrimaryAttack();
    }



    public void SetMoveDirection(Vector2 input)
    {
        _movement.MoveVector = new Vector3(input.x, 0, input.y);
    }
    
    
    public void Dash()
    {
        _dash.Dashing();
    }
}
