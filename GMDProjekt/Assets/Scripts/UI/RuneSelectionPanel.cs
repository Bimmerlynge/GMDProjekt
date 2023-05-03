using UnityEngine;


public class RuneSelectionPanel : MonoBehaviour
{
    public delegate void RuneSelected();

    public static event RuneSelected RuneSelectedEvent;


    private void OnEnable()
    {
        FreezeTime();
        RollOptions();
    }

    private void FreezeTime()
    {
        Time.timeScale = 0f;
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
