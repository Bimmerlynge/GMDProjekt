using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AxeAttackSO", menuName = "AxeAttack")]
public class AxeAttack : ScriptableObject
{
    public double Damage { get; set; } = 10.0;
}
