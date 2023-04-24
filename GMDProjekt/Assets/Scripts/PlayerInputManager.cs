using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputManager : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    private PlayerInputActions _actions;

    public delegate void MoveAction(Vector2 direction);
    public static event MoveAction MoveEvent;

    public delegate void DashAction();
    public static event DashAction DashEvent;
    
    public delegate void PrimaryAttack();

    public static event PrimaryAttack PrimaryAttackEvent;

    public delegate void SpecialAttackAction(); 
    public static event SpecialAttackAction OnSpecialAttackEvent;

    public delegate void Interact();

    public static event Interact InteractEvent;

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
        
        _actions.Player.Special.Enable();
        _actions.Player.Special.performed += SpecialAtk;
        
        _actions.Player.Aim.Enable();
        //_actions.Player.Aim.performed += Aim;
        
        _actions.Player.Interact.Enable();
        _actions.Player.Interact.performed += OnInteract;


    }

    private void OnDisable()
    {
        _actions.Player.Move.performed -= Move;
        _actions.Player.Move.canceled -= Move;
        
        _actions.Player.Dash.performed -= Dash;
        _actions.Player.PrimaryAtk.performed -= PrimAtk;
        _actions.Player.Interact.performed -= OnInteract;
        
        _actions.Disable();
    }

    private void SpecialAtk(InputAction.CallbackContext context)
    {
        if (OnSpecialAttackEvent != null) OnSpecialAttackEvent.Invoke();
    }

    private void OnInteract(InputAction.CallbackContext context)
    {
        if (InteractEvent != null) InteractEvent();
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
        if (PrimaryAttackEvent != null) PrimaryAttackEvent();
    }

    private void Dash(InputAction.CallbackContext context)
    {
        if (DashEvent != null) DashEvent();
    }

    private void Move(InputAction.CallbackContext context)
    {
        Vector2 value = context.ReadValue<Vector2>();
        if (MoveEvent != null) MoveEvent(value);
    }
}
