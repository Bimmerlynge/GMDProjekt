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
        RuneSelector.RuneSelectedEvent += OnRuneSelected;
    }
    
    private void OnRuneSelected(RuneSO rune)
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

    public void SetGameHudPanel(bool state)
    {
        gameHUD.SetActive(state);
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

    private void OnDestroy()
    {
        RuneSelector.RuneSelectedEvent -= OnRuneSelected;
    }
}
    

