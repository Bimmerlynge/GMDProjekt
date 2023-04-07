using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] private GameObject playerGameObject;
    private GameObject currentWeapon;
    private bool isAttacking = false;
    private Vector3 atkDirection;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        SetCurrentWeapon();
    }

    private void SetCurrentWeapon()
    {
        currentWeapon = transform.GetChild(0).gameObject;
        currentWeapon.transform.GetChild(0).gameObject.SetActive(false);
    }

    private void ToggleAtkCollider(bool value)
    {
        currentWeapon.transform.GetChild(0).gameObject.SetActive(value);
        
    }

    public void PrimAtk()
    {
        StartCoroutine(PrimAtkCoroutine());
        //Test();
    }

    private void Test()
    {
        print(currentWeapon.name);
    }

    private IEnumerator PrimAtkCoroutine()
    {
        ToggleAtkCollider(true);
        yield return new WaitForSeconds(2f);
        ToggleAtkCollider(false);
    }

    private void SetAttackDirection(Vector3 direction)
    {
        transform.rotation = quaternion.LookRotation(direction, Vector3.up);
    }

    private void OnTriggerEnter(Collider other)
    {
        print("Trigger");
    }
}
