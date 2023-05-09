using System.Collections;
using Audio;
using Shared;
using UnityEngine;

namespace Player.Abilities
{
    public class RageAbility : MonoBehaviour, IAbility
    {
        public delegate void RageAction();
        public static event RageAction OnRage;
    
        private Anim _anim;
        private SoundEffect _sfx;
        private void Awake()
        {
            _anim = GetComponent<Anim>();
            _sfx = GetComponent<SoundEffect>();
        }

        public void Use()
        {
            _anim.Trigger();
            _sfx.PlayClip();
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
