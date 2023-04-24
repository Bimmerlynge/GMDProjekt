using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RunePickup : MonoBehaviour
{
    private UIManager _uiManager;
    private bool _canPickup;

    void Start()
    {
        transform.position = new Vector3(0, 1, 10);
        _uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        PlayerInputManager.InteractEvent += OnPickupItem;
        RuneSelector.RuneSelectedEvent += OnRuneSelected;
    }

    private void OnRuneSelected()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        _canPickup = true;
        _uiManager.SetInteractablePanel(true, "Accept");
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        _canPickup = false;
        _uiManager.SetInteractablePanel(false);
    }

    private void OnPickupItem()
    {
        OpenRuneSelectionPanel();
    }

    private void OpenRuneSelectionPanel()
    {
        _uiManager.EnableRuneSelectionPanel();
    }

    private void ApplyReward()
    {
        
    }

    private void OnDestroy()
    {
        PlayerInputManager.InteractEvent -= OnPickupItem;
        RuneSelector.RuneSelectedEvent -= OnRuneSelected;
        _uiManager.SetInteractablePanel(false);
    }
}
