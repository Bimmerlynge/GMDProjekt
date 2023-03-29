using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputManager : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    private PlayerInputActions _actions;
    [SerializeField]
    private bool _liiigeFix;
    
    private void OnEnable()
    {
        _actions = new PlayerInputActions();
        _actions.Enable();
        
        _actions.Player.Enable();
        _actions.Player.Move.performed += Move;
        _actions.Player.Move.canceled += Move;
        
        _actions.Player.Dash.Enable();
        _actions.Player.Dash.performed += Dash;
    
        _actions.Player.PrimaryAtk.Enable();
        _actions.Player.PrimaryAtk.performed += PrimAtk;
        
        _actions.Player.Aim.Enable();
        _actions.Player.Aim.performed += Aim;


    }

    private void OnDisable()
    {
        _actions.Player.Move.performed -= Move;
        _actions.Player.Move.canceled -= Move;
        
        _actions.Player.Dash.performed -= Dash;
        _actions.Player.PrimaryAtk.performed -= PrimAtk;
        
        _actions.Disable();
    }

    private void Aim(InputAction.CallbackContext context)
    {
       
            if (context.control.device.name == "Mouse")
            {
                Vector3 mousePos = default;
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                {
                    mousePos = hit.point;
                }

                Vector3 aimVector = (mousePos - transform.position).normalized;
                aimVector.y = 0;
                Debug.DrawRay(transform.position, aimVector * 15, Color.blue);
                playerController.AimDirection(aimVector, true);
            }
            else
            {
                Vector2 aimVector = context.ReadValue<Vector2>();
                playerController.AimDirection(new Vector3(aimVector.x, 0, aimVector.y));
            }
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
