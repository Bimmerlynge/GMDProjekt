using System;
using System.Collections;
using System.Collections.Generic;
using Managers;
using UnityEngine;
using UnityEngine.EventSystems;

public class RuneSelector : MonoBehaviour
{
    public delegate void RuneSelected(RuneSO rune);

    public static event RuneSelected RuneSelectedEvent;
    
    [SerializeField] private RuneOption option1, option2, option3;
    [SerializeField] private RuneSO[] options = new RuneSO[3];
    

    private void OnEnable()
    {
        FreezeTime();
        SetFirstSelected();
        RollOptions();
        UpdateUI();
    }

    private void SetFirstSelected()
    {
        var eventSystem = EventSystem.current;
        eventSystem.SetSelectedGameObject(option1.gameObject);
    }

    private void FreezeTime()
    {
        Time.timeScale = 0f;
    }
    

    private void RollOptions()
    {
        var runes = RuneManager.Instance.GetRandomRunes();
        options[0] = runes[0];
        options[1] = runes[1];
        options[2] = runes[2];
    }

    private void UpdateUI()
    {
        option1.SetData(options[0]);
        option2.SetData(options[1]);
        option3.SetData(options[2]);
    }

    public void SelectOption1()
    {
        FireRuneSelectedEvent(options[0]);
    }
    public void SelectOption2()
    {
        FireRuneSelectedEvent(options[1]);
    }
    public void SelectOption3()
    {
        FireRuneSelectedEvent(options[2]);
    }

    private void FireRuneSelectedEvent(RuneSO rune)
    {
        if (RuneSelectedEvent != null) RuneSelectedEvent.Invoke(rune);
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        Time.timeScale = 1f;
    }
}
