using GameData;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerInputController : MonoBehaviour
    {
        private PlayerInputActions _actions;
    
        public Vector2 MoveDirection { get; private set; }
        
        public delegate void Interact();
        public static event Interact InteractEvent;

        public delegate void EscapeAction();
        public static event EscapeAction OnEscape;

        public delegate void AbilityAction(AbilityType type);
        public static event AbilityAction OnAbilityInput;

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
        
            _actions.Player.Rage.Enable();
            _actions.Player.Rage.performed += Rage;

            _actions.Player.Interact.Enable();
            _actions.Player.Interact.performed += OnInteract;
        
            _actions.Player.Esc.Enable();
            _actions.Player.Esc.performed += Escape;
        }
        
        private void OnDisable()
        {
            _actions.Player.Move.performed -= Move;
            _actions.Player.Move.canceled -= Move;
        
            _actions.Player.Dash.performed -= Dash;
            
            _actions.Player.PrimaryAtk.performed -= PrimAtk;
            
            _actions.Player.Special.performed -= SpecialAtk;
            
            _actions.Player.Interact.performed -= OnInteract;
            
            _actions.Player.Esc.performed -= Escape;
            
            _actions.Player.Rage.performed -= Rage;
        
            _actions.Disable();
        }

        private void Escape(InputAction.CallbackContext context)
        {
            if (OnEscape != null) OnEscape();
        }
        private void PrimAtk(InputAction.CallbackContext context)
        {
            if (OnAbilityInput != null) OnAbilityInput.Invoke(AbilityType.Attack);
        }

        private void SpecialAtk(InputAction.CallbackContext context)
        {
            if (OnAbilityInput != null) OnAbilityInput.Invoke(AbilityType.Special);
        }
    
        private void Dash(InputAction.CallbackContext context)
        {
            if (OnAbilityInput != null) OnAbilityInput.Invoke(AbilityType.Dash);
        }

        private void Rage(InputAction.CallbackContext context)
        {
            if (OnAbilityInput != null) OnAbilityInput.Invoke(AbilityType.Rage);
        }

        private void OnInteract(InputAction.CallbackContext context)
        {
            if (InteractEvent != null) InteractEvent();
        }
        
        private void Move(InputAction.CallbackContext context)
        {
            MoveDirection = context.ReadValue<Vector2>();
        }
    }
}
