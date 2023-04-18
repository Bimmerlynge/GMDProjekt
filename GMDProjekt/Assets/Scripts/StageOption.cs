using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StageOption : MonoBehaviour
{
   private UIManager _uiManager;

   private void Start()
   {
      _uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
   }

   private void OnTriggerEnter(Collider other)
   {
      if (!other.CompareTag("Player")) return;
      _uiManager.SetInteractablePanel(true, "Proceed");
   }

   private void OnTriggerExit(Collider other)
   {
      if (!other.CompareTag("Player")) return;
      _uiManager.SetInteractablePanel(false);
   }
}
