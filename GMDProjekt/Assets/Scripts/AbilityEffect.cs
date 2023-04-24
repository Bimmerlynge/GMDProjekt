using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="RuneEffect", menuName = "RuneEffect")]
public class AbilityEffect : ScriptableObject
{
    public IRune Rune { get; set; }
    

}
