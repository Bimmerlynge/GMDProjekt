using System;
using System.Collections;
using System.Collections.Generic;
using Abilities;
using Unity.Mathematics;
using UnityEngine;

public class ThunderSlam : MonoBehaviour
{
    
    [SerializeField] private RuneSO originalRune;
    [SerializeField] private float effectRadius;
    [SerializeField] private GameObject particleObj;
    private Particles _particles;
    private GameObject _effectObj;
    
    private RuneSO activeRune;

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        activeRune = Instantiate(originalRune);
    }

    private void OnEnable()
    {
        SpecialAbility.SpecialEvent += ApplyEffect;
    }

    private void ApplyEffect()
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
            Instantiate(particleObj, c.transform.position + Vector3.up * 10f, quaternion.identity);
            DealDamage(c.GetComponent<Health>());
        }
    }


    private void DealDamage(Health enemy)
    {
        enemy.TakeDamage(activeRune.effectNumber);
    }
}
