using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimaryAttack : MonoBehaviour
{
    [SerializeField] private float damage = 10f;
    
    [SerializeField]
    private float _cooldown = 0.5f;

    [SerializeField] private GameObject atkPoint;
    private float _timer;

    private void Start()
    {
        atkPoint.SetActive(false);
    }

    public void Activate()
    {
        StartCoroutine(PerformAbility());
    }

    public IEnumerator PerformAbility()
    {
        atkPoint.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        atkPoint.SetActive(false);
        
    }

    private void Update()
    {
        _timer += _timer + Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            var enemy = other.GetComponent<Health>();
            enemy.TakeDamage(damage);
        }
    }
}
