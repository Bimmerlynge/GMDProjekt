using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    [SerializeField] private GameObject gameHUD;
    [SerializeField] private GameObject interactablePanel;
    [SerializeField] private GameObject runeSelectionPanel;
    [SerializeField] private GameObject settingsPanel;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        DisablePanels();
        RuneSelector.RuneSelectedEvent += OnRuneSelected;
    }

    private void DisablePanels()
    {
        gameHUD.SetActive(false);
        interactablePanel.SetActive(false);
        runeSelectionPanel.SetActive(false);
        settingsPanel.SetActive(false);
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

    public void SetSettingsPanelState(bool state)
    {
        settingsPanel.SetActive(state);
    }


}
    

