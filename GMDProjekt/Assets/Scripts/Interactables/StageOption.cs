using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StageOption : MonoBehaviour
{
   private UIManager _uiManager;
   private bool _playerInRange;

   private void Start()
   {
      _uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
      PlayerInputController.InteractEvent += OnStageOptionChosen;
   }

   private void OnStageOptionChosen()
   {
      if (!_playerInRange) return;
      SceneLoader.Instance.LoadNextScene();
   }

   private void OnTriggerEnter(Collider other)
   {
      if (!other.CompareTag("Player")) return;
      _playerInRange = true;
      _uiManager.SetInteractablePanel(true, "Proceed");
   }

   private void OnTriggerExit(Collider other)
   {
      if (!other.CompareTag("Player")) return;
      _playerInRange = false;
      _uiManager.SetInteractablePanel(false);
   }
}
