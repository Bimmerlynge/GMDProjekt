using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RuneOption : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI title;
    [SerializeField] private TextMeshProUGUI description;
    [SerializeField] private TextMeshProUGUI rarity;
    [SerializeField] private TextMeshProUGUI effect;
    [SerializeField] private TextMeshProUGUI effectNumber;

    public void SetData(RuneSO rune)
    {
        title.text = rune.name;
        description.text = rune.description;
        rarity.text = rune.rarity.ToString();
        effect.text = rune.effect;
        effectNumber.text = rune.effectNumber.ToString();
    }
}
