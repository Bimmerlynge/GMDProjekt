using GameData;
using UnityEngine;

public class StageOption : MonoBehaviour
{
   
   [SerializeField] private GameObject reward;
   [SerializeField] private StageRewardData rewardData;
   [SerializeField] private bool playerInRange;

   public delegate void StageOptionAction();
   public static event StageOptionAction OnStageOptionChosen;
   
   private void Start()
   {
      PlayerInputController.InteractEvent += OnInteract;
   }

   private void OnInteract()
   {
      if (!playerInRange) return;
      SetStageRewardData();
      NotifyListeners();
   }

   private void SetStageRewardData()
   {
      rewardData.SetCurrentPrefab(reward);
   }

   private void NotifyListeners()
   {
      if (OnStageOptionChosen != null) OnStageOptionChosen();
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
