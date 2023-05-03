using System;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public static StageManager Instance;
    public delegate void BeginStageAction();

    public int CurrentStage { get; set; } = 1;
    public static event BeginStageAction OnBeginStage;
    [SerializeField] private GameObject currentReward;
    [SerializeField] private AudioClip _stageMusic;

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
    }

    private void Start()
    {
        Wave.OnFinalWaveCompleted += OnStageCompleted;
        
        
        
        Invoke("BeginStage", 3f);
    }

    public void BeginStage()
    {
        if (OnBeginStage != null) OnBeginStage();
        else print("No one listening for OnBeingStage");
    }

    private void OnStageCompleted()
    {
        SpawnReward();
        GenerateNextStageRewardOptions();
    }

    private void OnDisable()
    {
        Wave.OnFinalWaveCompleted -= OnStageCompleted;
    }
    

    private void GenerateNextStageRewardOptions()
    {
        
    }

    private void SpawnReward()
    {
        Invoke("InstantiateReward", 1f);
    }

    private void InstantiateReward()
    {
        Instantiate(currentReward, Vector3.zero, Quaternion.identity);
    }

   
}
