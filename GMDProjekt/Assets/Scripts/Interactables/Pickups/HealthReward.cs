using Player;
using Shared;
using UnityEngine;

namespace Interactables.Pickups
{
    public class HealthReward : MonoBehaviour, IInteractable
    {
        [SerializeField] private bool playerInRange;
        [SerializeField] private float amount = 20f;
        
        public void Start()
        {
            PlayerInputController.InteractEvent += OnInteract;
        }
        
        public void OnDestroy()
        {
            PlayerInputController.InteractEvent -= OnInteract;
        }

        public void OnInteract()
        {
            if (!playerInRange) return;
            var playerHealth = GameObject.Find("PlayerObject").GetComponent<Health>();
            playerHealth.AddHealth(amount);
            Destroy(gameObject);
        }

        public void OnTriggerEnter(Collider other)
        {
            playerInRange = true;
        }

        public void OnTriggerExit(Collider other)
        {
            playerInRange = false;
        }
    }
}