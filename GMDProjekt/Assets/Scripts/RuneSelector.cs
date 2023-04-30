using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneSelector : MonoBehaviour
{
    public delegate void RuneSelected();

    public static event RuneSelected RuneSelectedEvent;
    
    
    private void OnEnable()
    {
        RollOptions();
    }

    private void RollOptions()
    {
        print("Rolling selection options");
    }

    public void SelectOption1()
    {
        FireRuneSelectedEvent();
    }
    public void SelectOption2()
    {
        FireRuneSelectedEvent();
    }
    public void SelectOption3()
    {
        FireRuneSelectedEvent();
    }

    private void FireRuneSelectedEvent()
    {
        if (RuneSelectedEvent != null) RuneSelectedEvent();
    }
}
