using System.Collections;

namespace Player.Abilities
{
    public interface IAbility
    {
        void Use();

        IEnumerator Cooldown();
        void ResetCooldown();
        void FireEvent();
    }
}
