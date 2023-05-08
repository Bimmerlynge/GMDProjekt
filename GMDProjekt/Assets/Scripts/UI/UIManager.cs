using DefaultNamespace.UI;
using TMPro;
using UI;
using UnityEngine;


public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    [SerializeField] private GameHUD gameHUD;
    [SerializeField] private GameObject interactablePanel;
    [SerializeField] private GameObject runeSelectionPanel;
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject endGameMenu;

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
    

    public void IncrementRage()
    {
        gameHUD.IncrementRage();
    }

    public void SetGameHudPanel(bool state)
    {
        gameHUD.gameObject.SetActive(state);
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
        gameHUD.SetHealthBar(value);
    }

    public void EnableRageMeter()
    {
        gameHUD.EnableRageMeter();
    }

    public void OpenEndGameMenu()
    {
        endGameMenu.SetActive(true);
    }
}
    

