using System.Collections.Generic;
using Runes;
using UnityEngine;

namespace Managers
{
    public class RuneManager : Singleton<RuneManager>
    {
        [SerializeField] private List<GameObject> runeObjects;
        private List<RuneSO> activeRunes = new();

        private Transform playerObject;
        private RuneRoller _runeRoller;
        

        private void OnEnable()
        {
            GetAllRunesObjects();
            _runeRoller = GetComponent<RuneRoller>();
        }

        private void Start()
        {
            RuneSelector.RuneSelectedEvent += SetRuneActive;
        }
    

        private void OnDestroy()
        {
            RuneSelector.RuneSelectedEvent -= SetRuneActive;
        }

        private void Update()
        {
            if (playerObject == null) return;
            transform.position = playerObject.position;
        }

        public void SetPlayerTransform(Transform player)
        {
            playerObject = player;
        }

        private void SetRuneActive(RuneSO rune)
        {
            EnableRuneObject(rune);
        }

        private void EnableRuneObject(RuneSO rune)
        {
            foreach (var runeObject in runeObjects)
            {
                var trimmed = rune.name.Replace(" ", "");
                if (!trimmed.Equals(runeObject.name)) continue;
                runeObject.SetActive(true);
                return;
            }
        }

        public void AddToActiveList(RuneSO rune)
        {
            activeRunes.Add(rune);
            _runeRoller.UpdateRunePool(activeRunes);
        }

        public void RemoveFromActiveList(RuneSO rune)
        {
            activeRunes.Remove(rune);
            _runeRoller.UpdateRunePool(activeRunes);
        }

        private void GetAllRunesObjects()
        {
            foreach (Transform child in transform)
            {
                runeObjects.Add(child.gameObject);
            }
        }
        
        public RuneSO[] GetRandomRunes()
        {
            return _runeRoller.GetRandomRunes();
        }
    }
}
