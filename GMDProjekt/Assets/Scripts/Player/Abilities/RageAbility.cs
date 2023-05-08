using System;
using System.Collections;
using System.Collections.Generic;
using Abilities;
using UnityEngine;

public class RageAbility : MonoBehaviour
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
        FireOnRage();
    }

    private void FireOnRage()
    {
        if (OnRage != null) OnRage();
    }
}
