using System;
using UnityEngine;


public class RuneReward : MonoBehaviour, IPickup
{
    private void Start()
    {
        Interactable.InteractableEvent += ApplyReward;
    }

    public void ApplyReward()
    {
        OpenRuneSelector();
        
    }

    private void OpenRuneSelector()
    {
        UIManager.Instance.EnableRuneSelectionPanel();
    }

    private void OnDestroy()
    {
        Interactable.InteractableEvent -= ApplyReward;
    }
}
