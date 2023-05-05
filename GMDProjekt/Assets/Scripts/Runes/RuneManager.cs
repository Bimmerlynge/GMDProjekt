using System;
using System.Collections.Generic;
using System.Reflection;
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
    }

    private void Update()
    {
        transform.position = playerObject.position;
    }

    private void OnDestroy()
    {
        RuneSelector.RuneSelectedEvent -= SetRuneActive;
    }

    public void SetPlayerTransform(Transform player)
    {
        playerObject = player;
    }

    private void SetRuneActive(RuneSO rune)
    {
        EnableRuneObject(rune);
        AddToActiveList(rune);
        _runeRoller.UpdateRunePool(activeRunes);
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

    public RuneSO[] GetRandomRunes()
    {
        return _runeRoller.GetRandomRunes();
    }
    


}
