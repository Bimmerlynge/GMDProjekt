using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseAbility : MonoBehaviour, IAbility
{
    [SerializeField] private double damage;

    [SerializeField] private int castRate;

    public abstract void Use();
    public IEnumerator Cooldown()
    {
        throw new System.NotImplementedException();
    }


    public abstract void ResetCooldown();
}
