using Interactables;
using Managers;
using UnityEngine;

namespace UI
{
    public class InteractableUI : MonoBehaviour, IInteractable
    {   
        [SerializeField] private string interactText;

        public void Start() { }

        public void OnDestroy() { }

        public void OnInteract() { }

        public void OnTriggerEnter(Collider other)
        {
            UIManager.Instance.SetInteractablePanel(true, interactText);
        }

        public void OnTriggerExit(Collider other)
        {
            UIManager.Instance.SetInteractablePanel(false);
        }

        private void OnDisable()
        {
            UIManager.Instance.SetInteractablePanel(false);
        }
    }
}
