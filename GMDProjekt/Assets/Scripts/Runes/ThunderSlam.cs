using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderSlam : MonoBehaviour
{
    [SerializeField] private RuneSO originalRune;
    [SerializeField] private float effectRadius;

    private RuneSO activeRune;
    // Start is called before the first frame update
    void Start()
    {
        activeRune = Instantiate(originalRune);
    }

    private void OnEnable()
    {
        SpecialAbility.SpecialEvent += ActivateRune;
    }

    private void ActivateRune()
    {

        var enemies = GetEnemiesInRange();
        DamageEnemies(enemies);
    }


    private Collider[] GetEnemiesInRange()
    {
        return Physics.OverlapSphere(transform.position, effectRadius, 1 << LayerMask.NameToLayer("Enemy"));
    }

    private void DamageEnemies(Collider[] enemies)
    {
        foreach (var c in enemies)
        {
            c.gameObject.GetComponent<Health>().TakeDamage(activeRune.effectNumber);
        }
    }
}
