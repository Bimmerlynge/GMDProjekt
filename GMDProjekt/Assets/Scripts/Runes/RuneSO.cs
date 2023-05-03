using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Rune")]
public class RuneSO : ScriptableObject
{
    public string name;
    public string description;
    public Rarity rarity;
    public string effect;
    public float effectNumber;
    public int runeLvl;
    
    public enum Rarity
    {
        Common,
        Rare,
        Epic
    }
}
