using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Runes
{
    public class RuneRoller : MonoBehaviour
    {
        [SerializeField] private List<RuneSO> allRunes;
        private List<RuneSO> currentPool;

        private void Start()
        {
            currentPool = new List<RuneSO>(allRunes);
        }

        public void UpdateRunePool(List<RuneSO> activeRunes)
        {
            foreach (var rune in activeRunes)
            {
                currentPool.Remove(rune);
            }
        }

        public RuneSO[] GetRandomRunes()
        {
            var randomRunes = new RuneSO[3];
            var buffer = new List<RuneSO>(currentPool);
            for (int i = 0; i < randomRunes.Length; i++)
            {
                randomRunes[i] = GetRandomRune(buffer);
            }
            return randomRunes;
        }

        private RuneSO GetRandomRune(List<RuneSO> list)
        {
            var rand = Random.Range(0, list.Count);
            var rune = list[rand];
            list.Remove(rune);
            return rune;
        }

    }
}