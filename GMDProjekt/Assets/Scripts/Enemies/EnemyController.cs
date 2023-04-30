using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    private static int EnemyCount = 0;
    public delegate void EnemyDefeated();

    public static event EnemyDefeated EnemyDefeatedEvent;

    public delegate void LastEnemyDefeatedAction();

    public static event LastEnemyDefeatedAction OnLastEnemyDefeated;
    private Health _health;
    private Slider _healthBar;

    private NavMeshAgent _agent;
    private Transform _target;

    private void Awake()
    {
        _health = GetComponent<Health>();
        _healthBar = GetComponentInChildren<Slider>();
        _agent = GetComponent<NavMeshAgent>();
        _target = GameObject.Find("PlayerObject").transform;
    }

    private void Start()
    {
        UpdateHealthUI();
        Health.OnDamageTaken += UpdateHealthUI;
        EnemyCount++;
    }

    private void Update()
    {
        _agent.destination = _target.position;
    }

    private void OnDisable()
    {
        Health.OnDamageTaken -= UpdateHealthUI;
    }

    private void OnDestroy()
    {
        CheckIfLastEnemy();
        EnemyCount--;
    }

    private void CheckIfLastEnemy()
    {
        if (EnemyCount > 1) return;
        if (OnLastEnemyDefeated != null) OnLastEnemyDefeated.Invoke();
    }

    private void UpdateHealthUI()
    {
        _healthBar.value = _health.GetHealthPercentage();
    }
    
}
