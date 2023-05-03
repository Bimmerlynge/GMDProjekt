using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneSelector : MonoBehaviour
{
    public delegate void RuneSelected(RuneSO rune);

    public static event RuneSelected RuneSelectedEvent;
    
    [SerializeField] private RuneOption option1, option2, option3;
    [SerializeField] private RuneSO[] options = new RuneSO[3];

    private void Awake()
    {
        gameObject.SetActive(false);
    }


    private void OnEnable()
    {
        FreezeTime();
        RollOptions();
        UpdateUI();
    }

    private void FreezeTime()
    {
        Time.timeScale = 0f;
    }
    

    private void RollOptions()
    {
        options[0] = RuneManager.Instance.GetRandomRune();
        options[1] = RuneManager.Instance.GetRandomRune();
        options[2] = RuneManager.Instance.GetRandomRune();
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
    }

    private void OnDisable()
    {
        Time.timeScale = 1f;
    }
}
