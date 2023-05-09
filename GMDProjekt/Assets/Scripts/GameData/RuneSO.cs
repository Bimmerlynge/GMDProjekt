using UnityEngine;

[CreateAssetMenu(menuName = "Rune")]
public class RuneSO : ScriptableObject
{
    public Sprite icon;
    public string name;
    public Type type;
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

    public enum Type
    {
        Attack,
        Special,
        Dash,
        Rage,
        Other
    }
}
