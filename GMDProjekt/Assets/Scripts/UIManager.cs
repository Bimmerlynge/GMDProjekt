using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject gameHUD;
    [SerializeField] private GameObject interactablePanel;
    [SerializeField] private GameObject runeSelectionPanel;

    private void Start()
    {
        SetUIInteractableState(false);
        runeSelectionPanel.SetActive(false);
        RuneSelector.RuneSelectedEvent += OnRuneSelected;
    }

    private void OnRuneSelected()
    {
        runeSelectionPanel.SetActive(false);
    }

    public void EnableRuneSelectionPanel()
    {
        runeSelectionPanel.SetActive(true);
    }

    public void SetInteractablePanel(bool state, string text = "")
    {
        SetUIInteractableState(state);
        if (!string.IsNullOrEmpty(text))
            SetUIInteractableText(text);
    }
    
    private void SetUIInteractableState(bool value)
    {
        interactablePanel.SetActive(value);
    }

    private void SetUIInteractableText(string text)
    {
       var textObject = interactablePanel.GetComponentInChildren<TextMeshProUGUI>();
       textObject.text = text;
    }

    
}
    

