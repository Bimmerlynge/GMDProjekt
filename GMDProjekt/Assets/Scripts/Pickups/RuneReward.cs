using System;
using DefaultNamespace.Interactables;
using UnityEngine;


public class RuneReward : MonoBehaviour, IPickup
{
    [SerializeField] private bool playerInRange;
    [SerializeField] private bool canTake;

    private void Start()
    {
        PlayerInputController.InteractEvent += ApplyReward;
    }

    public void ApplyReward()
    {
        if (!canTake) return;
        OpenRuneSelector();
        Destroy(gameObject);
    }

    private void OpenRuneSelector()
    {
        UIManager.Instance.EnableRuneSelectionPanel();
    }

    private void OnTriggerEnter(Collider other)
    {
        canTake = true;
    }

    private void OnTriggerExit(Collider other)
    {
        canTake = false;
    }

    private void OnDestroy()
    {
        PlayerInputController.InteractEvent -= ApplyReward;
    }

    
}
