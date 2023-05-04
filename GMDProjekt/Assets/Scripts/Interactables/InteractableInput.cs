using UnityEngine;

namespace DefaultNamespace.Interactables
{
    public class InteractableInput : MonoBehaviour, IInteractable
    {
        [SerializeField] private bool _takesInput = false;
        public bool TakesInput { get => _takesInput; private set => _takesInput = value; }
        public void OnTriggerEnter(Collider other)
        {
            print("interactable input onTrigger enter");
            PlayerInputController.InteractEvent += ToggleTakesInput;
        }

        public void OnTriggerExit(Collider other)
        {
            print("interactable input onTrigger exit");
            PlayerInputController.InteractEvent -= ToggleTakesInput;
        }

        private void ToggleTakesInput()
        {
            TakesInput = !TakesInput;
        }
    }
}