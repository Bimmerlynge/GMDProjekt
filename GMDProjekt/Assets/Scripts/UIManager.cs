using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject gameHUD;
    [SerializeField] private GameObject interactablePanel;

    private void Start()
    {
        SetUIInteractableState(false);
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
    

