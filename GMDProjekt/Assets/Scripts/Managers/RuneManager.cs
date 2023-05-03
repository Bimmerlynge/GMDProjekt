using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using Random = UnityEngine.Random;


public class RuneManager : MonoBehaviour
{
    public static RuneManager Instance;
    [SerializeField] private List<GameObject> runeObjects;
    
    [SerializeField] private List<RuneSO> allRunes;
    [SerializeField] private List<RuneSO> activeRunes;
    
    

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        GetAllRunesObjects();
    }
    private void Start()
    {
        RuneSelector.RuneSelectedEvent += SetRuneActive;

    }

    private void OnDestroy()
    {
        RuneSelector.RuneSelectedEvent -= SetRuneActive;
    }

    private void SetRuneActive(RuneSO rune)
    {
        EnableRuneObject(rune);
        AddToActiveList(rune);
    }

    private void EnableRuneObject(RuneSO rune)
    {
        foreach (var runeObject in runeObjects)
        {
            var trimmed = rune.name.Replace(" ", "");
            if (!trimmed.Equals(runeObject.name)) continue;
            runeObject.SetActive(true);
            return;
        }
    }

    private void AddToActiveList(RuneSO rune)
    {
        activeRunes.Add(rune);
    }

    private void GetAllRunesObjects()
    {
        foreach (Transform child in transform)
        {
            runeObjects.Add(child.gameObject);
        }
    }

    public RuneSO GetRandomRune()
    {
        var runeList = GetRuneRewardOptions();
        var randomIndex = Random.Range(0, runeList.Count);
        var rune = runeList[randomIndex];
        runeList.Remove(rune);
        return rune;
    }

    private List<RuneSO> GetRuneRewardOptions()
    {
        var toReturn = allRunes;
        foreach (var rune in activeRunes)
        {
            toReturn.Remove(rune);
        }

        return toReturn;
    }


}
