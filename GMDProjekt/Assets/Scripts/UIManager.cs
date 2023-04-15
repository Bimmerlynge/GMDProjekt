using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject uiInteractableTextObject;

    private void Start()
    {
        print("start");
        SetUIInteractableState(false);
        print("bøgse burde være fucking inaktiv");
    }

    public void SetUIInteractableText(string text)
    {
        var textObject = uiInteractableTextObject.GetComponentInChildren<TextMeshProUGUI>();
        textObject.text = text;
    }

    public void SetUIInteractableState(bool value)
    {
        uiInteractableTextObject.SetActive(value);
    }
}
    

