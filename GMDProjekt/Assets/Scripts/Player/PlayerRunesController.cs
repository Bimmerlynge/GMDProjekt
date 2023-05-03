using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunesController : MonoBehaviour
{
    [SerializeField] private GameObject lightningDash;

    [SerializeField] private GameObject thunderSlam;

    [SerializeField] private GameObject arcingFury;
    // Start is called before the first frame update
    void Start()
    {
        RuneSelector.RuneSelectedEvent += OnRuneSelected;
    }

    private void OnRuneSelected(RuneSO rune)
    {
        EnableRuneObject(rune.name);
    }

    private void EnableRuneObject(string objectName)
    {
        var toActivate = transform.Find("LightningDash");
        toActivate.gameObject.SetActive(true);
    }

}
