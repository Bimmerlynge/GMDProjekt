using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Rune : MonoBehaviour
{
    private UIManager _uiManager;

    void Start()
    {
        transform.position = new Vector3(0, 1, 10);
        _uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        
    }

    private void OnTriggerEnter(Collider other)
    {
        _uiManager.SetUIInteractableState(true);
    }

    private void OnTriggerExit(Collider other)
    {
        _uiManager.SetUIInteractableState(true);
        _uiManager.SetUIInteractableText("Accept");
    }
    
}
