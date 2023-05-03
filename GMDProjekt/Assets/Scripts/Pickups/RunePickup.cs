using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RunePickup : MonoBehaviour, IInteractable
{
    private UIManager _uiManager;
    private bool _canPickup;

    void Start()
    {
        transform.position = new Vector3(0, 1, 10);
        _uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        PlayerInputController.InteractEvent += OnInteract;
        RuneSelector.RuneSelectedEvent += OnRuneSelected;
    }

    private void OnRuneSelected(RuneSO rune)
    {
        Destroy(gameObject);
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

    public void OnInteract()
    {
        _uiManager.EnableRuneSelectionPanel();
    }

    private void ApplyReward()
    {
        
    }

    private void OnDestroy()
    {
        PlayerInputController.InteractEvent -= OnInteract;
        RuneSelector.RuneSelectedEvent -= OnRuneSelected;
        _uiManager.SetInteractablePanel(false);
    }
}
