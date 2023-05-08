using GameData;
using UnityEngine;

namespace Interactables
{
   public class StageOption : MonoBehaviour, IInteractable
   {
   
      [SerializeField] private GameObject reward;
      [SerializeField] private StageRewardData rewardData;
      private bool playerInRange;

      public delegate void StageOptionAction();
      public static event StageOptionAction OnStageOptionChosen;
   
      public void Start()
      {
         PlayerInputController.InteractEvent += OnInteract;
      }
      public void OnDestroy()
      {
         PlayerInputController.InteractEvent -= OnInteract;
      }
      public void OnInteract()
      {
         if (!playerInRange) return;
         SetStageRewardData();
         NotifyListeners();
      }
      
      public void OnTriggerEnter(Collider other)
      {
         playerInRange = true;
      }
      
      public void OnTriggerExit(Collider other)
      {
         playerInRange = false;
      }
      

      private void SetStageRewardData()
      {
         rewardData.SetCurrentPrefab(reward);
      }

      private void NotifyListeners()
      {
         if (OnStageOptionChosen != null) OnStageOptionChosen();
      }
   }
}
