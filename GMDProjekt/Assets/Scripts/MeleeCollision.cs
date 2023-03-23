using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        print("Collision with " + other.gameObject.name);
    }
}
