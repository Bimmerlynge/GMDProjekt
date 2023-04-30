using UnityEngine;
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

    private void Awake()
    {
        _health = GetComponent<Health>();
        _healthBar = GetComponentInChildren<Slider>();
    }

    private void Start()
    {
        UpdateHealthUI();
        Health.OnDamageTaken += UpdateHealthUI;
        EnemyCount++;
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
