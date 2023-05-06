using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    private static int EnemyCount = 0;
    public delegate void LastEnemyDefeatedAction();

    public static event LastEnemyDefeatedAction OnLastEnemyDefeated;
    private Health _health;

    private NavMeshAgent _agent;
    private Transform _target;
    private Slider healthBar;
    private Animator _animator;
    
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _health = GetComponent<Health>();
        _agent = GetComponent<NavMeshAgent>();
        healthBar = GetComponentInChildren<Slider>();
       _target = GameObject.Find("PlayerObject").transform;
       _health.OnHealthChanged += UpdateUI;
       Health.OnDeathEvent += OnDeath;
    }
    
    private void Start()
    {
        EnemyCount++;
    }

    private void UpdateUI(float value)
    {
        healthBar.value = value;
    }

    private void Update()
    {
        //_agent.destination = _target.position;
    }

    private void OnDeath(GameObject deadObj)
    {
        if (deadObj == gameObject)
        {
            _animator.SetTrigger("death");
            Invoke("Die", 0.05f);
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }


    private void OnDestroy()
    {
        
        CheckIfLastEnemy();
        EnemyCount--;
        _health.OnHealthChanged -= UpdateUI;
        Health.OnDeathEvent -= OnDeath;
    }

    private void CheckIfLastEnemy()
    {
        if (EnemyCount > 1) return;
        if (OnLastEnemyDefeated != null) OnLastEnemyDefeated.Invoke();
    }

   
    
}
