using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Ability : MonoBehaviour
{
    [SerializeField]
    private AxeAttack _abilityScriptableObject;

    [SerializeField] private GameObject meleeHitBox;
    private Animator _animator;
    
    private void Awake()
    {
        _animator = GetComponentInParent<Animator>();
    }

    private void Start()
    {
        
    }

    public void Cast()
    {
        meleeHitBox.SetActive(true);
        _animator.SetTrigger("MeleePrimAtk");
        
    }
    
    
    
}
