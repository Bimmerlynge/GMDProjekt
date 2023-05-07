using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UI;
using UnityEngine;
using UnityEngine.UI;

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

    public void UpdateRunePanel(RuneSO rune)
    {
        var runePanel = gameHUD.GetComponentInChildren<RunePanel>();
        runePanel.SetRuneIcon(rune);
    }

    public void SetGameHudPanel(bool state)
    {
        gameHUD.SetActive(state);
    }
    
    public void SetInteractablePanel(bool state, string text = "")
    {
        SetUIInteractableState(state);
        if (state == false) return;
        SetUIInteractableText(text);
    }

    public void EnableRuneSelectionPanel()
    {
        runeSelectionPanel.SetActive(true);
    }

    public void OpenSettingsMenu()
    {
        settingsPanel.SetActive(true);
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

    public void SetHealthBarValue(float value)
    {
        gameHUD.GetComponentInChildren<Slider>().value = value;
    }
}
    

