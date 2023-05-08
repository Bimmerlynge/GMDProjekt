using System.Collections;
using Abilities;
using UnityEngine;

namespace Player.Abilities
{
    public class RageAbility : MonoBehaviour, IAbility
    {
        public delegate void RageAction();
        public static event RageAction OnRage;
    
        private Anim _anim;

        private void Awake()
        {
            _anim = GetComponent<Anim>();
        }

        public void Use()
        {
            _anim.Trigger();
            FireEvent();
        }

        public IEnumerator Cooldown() { yield return null;}

        public void ResetCooldown() { }

        public void FireEvent()
        {
            if (OnRage != null) OnRage();
        }
        
    }
}
