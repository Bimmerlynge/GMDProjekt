using Interactables;
using Managers;
using UnityEngine;


public class RuneReward : MonoBehaviour, IInteractable
{
    [SerializeField] private bool playerInRange;

    public void Start()
    {
        PlayerInputController.InteractEvent += OnInteract;
    }

    public void OnInteract()
    {
        if (!playerInRange) return;
        OpenRuneSelector();
        Destroy(gameObject);
    }

    private void OpenRuneSelector()
    {
        UIManager.Instance.EnableRuneSelectionPanel();
    }

    public void OnTriggerEnter(Collider other)
    {
        playerInRange = true;
    }

    public void OnTriggerExit(Collider other)
    {
        playerInRange = false;
    }

    public void OnDestroy()
    {
        PlayerInputController.InteractEvent -= OnInteract;
    }

    
}
