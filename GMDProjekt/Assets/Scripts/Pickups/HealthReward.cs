using UnityEngine;

namespace DefaultNamespace.Pickups
{
    public class HealthReward : MonoBehaviour, IPickup
    {
        [SerializeField] private bool playerInRange;
        [SerializeField] private float amount = 20f;
        
        private void Start()
        {
            PlayerInputController.InteractEvent += ApplyReward;
        }

        public void ApplyReward()
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

        private void OnDestroy()
        {
            PlayerInputController.InteractEvent -= ApplyReward;
        }
    }
}