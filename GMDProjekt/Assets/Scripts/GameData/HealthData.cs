using System.Collections.Generic;
using UnityEngine;

namespace GameData
{
    [CreateAssetMenu]
    public class HealthData : ScriptableObject
    {
        private Dictionary<GameObject, float> healthDictionary = new();

        public float GetHealth(GameObject gameObject)
        {
            if (!healthDictionary.TryGetValue(gameObject, out float value))
            {
                return -1;
            }

            return value;
        }

        public void SetHealth(GameObject gameObject, float value)
        {
            if (!healthDictionary.ContainsKey(gameObject))
            {
                healthDictionary.Add(gameObject, value);
            }

            healthDictionary[gameObject] = value;
        }

        public void RemoveEntry(GameObject gameObject)
        {
            healthDictionary.Remove(gameObject);
        }
    }
}