using System;
using System.Collections.Generic;
using System.Reflection;
using Packages.Rider.Editor.UnitTesting;
using Runes;
using UnityEngine;
using Random = UnityEngine.Random;


public class RuneManager : MonoBehaviour
{
    public static RuneManager Instance;
    [SerializeField] private List<GameObject> runeObjects;
    [SerializeField] private List<RuneSO> activeRunes;

    private Transform playerObject;
    private RuneRoller _runeRoller;
    

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

        _runeRoller = GetComponent<RuneRoller>();
        GetAllRunesObjects();

    }
    private void Start()
    {
        RuneSelector.RuneSelectedEvent += SetRuneActive;
        DashAbility.DashEvent += Test;
    }

    private void Test()
    {
        if (activeRunes.Count > 0)
        {
            print(activeRunes[0].runeLvl);
        }
    }

    private void OnDestroy()
    {
        RuneSelector.RuneSelectedEvent -= SetRuneActive;
    }

    private void Update()
    {
        transform.position = playerObject.position;
    }

    public void SetPlayerTransform(Transform player)
    {
        playerObject = player;
    }

    private void SetRuneActive(RuneSO rune)
    {
        EnableRuneObject(rune);
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

    public void AddToActiveList(RuneSO rune)
    {
        activeRunes.Add(rune);
        _runeRoller.UpdateRunePool(activeRunes);
    }

    public void RemoveFromActiveList(RuneSO rune)
    {
        activeRunes.Remove(rune);
        _runeRoller.UpdateRunePool(activeRunes);
    }

    private void GetAllRunesObjects()
    {
        foreach (Transform child in transform)
        {
            runeObjects.Add(child.gameObject);
        }
    }

    public RuneSO[] GetRandomRunes()
    {
        return _runeRoller.GetRandomRunes();
    }
    


}
