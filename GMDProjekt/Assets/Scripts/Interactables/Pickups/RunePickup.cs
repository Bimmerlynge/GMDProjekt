using Managers;
using Player;
using UI;
using UnityEngine;

namespace Interactables.Pickups
{
    public class RunePickup : MonoBehaviour, IInteractable
    {
        private UIManager _uiManager;
        private bool _canPickup;

        public void Start()
        {
            transform.position = new Vector3(0, 1, 10);
            _uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
            PlayerInputController.InteractEvent += OnInteract;
            RuneSelector.RuneSelectedEvent += OnRuneSelected;
        }
        public void OnDestroy()
        {
            PlayerInputController.InteractEvent -= OnInteract;
            RuneSelector.RuneSelectedEvent -= OnRuneSelected;
            _uiManager.SetInteractablePanel(false);
        }
        
        public void OnInteract()
        {
            _uiManager.EnableRuneSelectionPanel();
        }
        public void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player")) return;
            _canPickup = true;
            _uiManager.SetInteractablePanel(true, "Accept");
        }

        public void OnTriggerExit(Collider other)
        {
            if (!other.CompareTag("Player")) return;
            _canPickup = false;
            _uiManager.SetInteractablePanel(false);
        }
        

        private void OnRuneSelected(RuneSO rune)
        {
            Destroy(gameObject);
        }
        

        
        
    }
}
