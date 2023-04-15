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
      print("har vi en UIManger: " + _uiManager);
   }

   private void OnTriggerEnter(Collider other)
   {
      _uiManager.SetUIInteractableState(true);
      _uiManager.SetUIInteractableText("Proceed");
   }

   private void OnTriggerExit(Collider other)
   {
      _uiManager.SetUIInteractableState(true);
   }
}
