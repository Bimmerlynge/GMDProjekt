using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    private GameObject currentWeapon;
    private bool isAttacking = false;

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

    private void OnTriggerEnter(Collider other)
    {
        print("Trigger");
    }
}
