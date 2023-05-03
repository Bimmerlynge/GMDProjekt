using System;
using UnityEngine;

public class Interactable : MonoBehaviour, IInteractable
{   
    [SerializeField] private string interactText;
    [SerializeField] private bool playerInRange;

    public delegate void InteractableAction();

    public static event InteractableAction InteractableEvent;

    private void Start()
    {
        PlayerInputController.InteractEvent += OnInteract;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        playerInRange = true;
        UIManager.Instance.SetInteractablePanel(true, interactText);
    }

    public void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        playerInRange = false;
        UIManager.Instance.SetInteractablePanel(false, interactText);
    }

    public void OnInteract()
    {
        if (InteractableEvent != null) InteractableEvent();
        if (InteractableEvent != null) InteractableEvent.Invoke();
    }

    private void OnDestroy()
    {
        PlayerInputController.InteractEvent -= OnInteract;
    }
}
