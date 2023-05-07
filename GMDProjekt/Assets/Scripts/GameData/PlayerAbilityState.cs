using UnityEngine;

namespace GameData
{
    [CreateAssetMenu]
    public class PlayerAbilityState : ScriptableObject
    {
        public AbilityState currentState;
        public enum AbilityState
        {
            Ready,
            Busy
        }
        
    }
}