using System;
using UnityEngine;

public class InteractableUI : MonoBehaviour, IInteractable
{   
    [SerializeField] private string interactText;
    
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
        var manager = UIManager.Instance;
        if (manager == null) return;
        manager.SetInteractablePanel(false);
    }
}
