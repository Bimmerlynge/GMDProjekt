using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StageOption : MonoBehaviour
{
   
   [SerializeField] private GameObject reward;
   [SerializeField] private bool playerInRange;

   public delegate void StageOptionAction(GameObject rewardPrefab);

   public static event StageOptionAction OnStageOptionChosen;
   
   private void Start()
   {
      PlayerInputController.InteractEvent += OnInteract;
   }

   private void OnInteract()
   {
      if (!playerInRange) return;
      if (OnStageOptionChosen != null) OnStageOptionChosen.Invoke(reward);
   }


   private void OnTriggerEnter(Collider other)
   {
      playerInRange = true;
   }
   

   private void OnTriggerExit(Collider other)
   {
      playerInRange = false;
   }

   private void OnDestroy()
   {
      PlayerInputController.InteractEvent -= OnInteract;
   }
}
