using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputManager : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    private PlayerInputActions _actions;
    
    
    private void OnEnable()
    {
        _actions = new PlayerInputActions();
        _actions.Enable();
        
        _actions.Player.Enable();
        _actions.Player.Move.performed += Move;
        _actions.Player.Move.canceled += Move;
        
        _actions.Player.Dash.Enable();
        _actions.Player.Dash.performed += Dash;

        _actions.Player.PrimaryAtk.performed += PrimAtk;
        
        _actions.Player.PrimaryAtk.Enable();
    }

    private void OnDisable()
    {
        _actions.Player.Move.performed -= Move;
        _actions.Player.Move.canceled -= Move;
        
        _actions.Player.Dash.performed -= Dash;
        _actions.Player.PrimaryAtk.performed -= PrimAtk;
        
        _actions.Disable();
    }

    private void PrimAtk(InputAction.CallbackContext context)
    {
        playerController.PrimaryAttack();
    }

    private void Dash(InputAction.CallbackContext context)
    {
        playerController.Dash();
    }

    private void Move(InputAction.CallbackContext context)
    {
        Vector2 value = context.ReadValue<Vector2>();
        playerController.SetMoveDirection(value);
    }
}
