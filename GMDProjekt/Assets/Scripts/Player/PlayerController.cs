using GameData;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    private Movement _movement;
    private Attacking _attacking;
    private Health _health;
    private Animator _animator;
    private AbilityController _abilityController;
    private PlayerInputController _input;

    [SerializeField] private PlayerAbilityState _abilityState;
    [SerializeField] private HealthData healthData;

    private void Awake()
    {
        _input = GetComponent<PlayerInputController>();
        _animator = GetComponent<Animator>();
        _movement = GetComponent<Movement>();
        _health = GetComponent<Health>();
        _abilityController = GetComponentInChildren<AbilityController>();
        _health.OnHealthChanged += UpdateHealthUI;
        Health.OnDeathEvent += HandleDeath;
    }
    
    private void OnDestroy()
    {
        RuneManager.Instance.SetPlayerTransform(null);
        healthData.Value = _health.CurrentHealth;
        _health.OnHealthChanged -= UpdateHealthUI;
        Health.OnDeathEvent -= HandleDeath;
    }
    

    private void OnEnable()
    {
        LoadHealth();
    }

    private void Start()
    {
        RuneManager.Instance.SetPlayerTransform(transform);
        
    }

    private void LoadHealth()
    {
        var data = healthData.Value;
        if (data > 0f) _health.SetHealth(data);
    }

    private void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        var input = _input.MoveDirection;
        SetMovingState(input != Vector2.zero);
        _movement.SetMoveDirection(input);
    }

    public void AnimationStarted()
    {
        _movement.enabled = false;
    }

    public void AnimationFinished()
    {
        _movement.enabled = true;
    }

    private void UpdateHealthUI(float value)
    {
        UIManager.Instance.SetHealthBarValue(value);
        healthData.Value = _health.CurrentHealth;
    }
    
    // Used by unity animation events
    void AxeSpecialTrigger()
    {
        _abilityController.TriggerSpecialDamage();
    }

    

    private void HandleDeath(GameObject obj)
    {
        print("obj : " + obj);
        if (!(obj == gameObject)) return;
        if (obj == null) return;
        if (_health.CurrentHealth <= 0f)
            UIManager.Instance.OpenEndGameMenu();
        else
            Destroy(gameObject);
        
    }

    private void SetMovingState(bool state)
    {
        if (_abilityState.currentState == PlayerAbilityState.AbilityState.Busy) return;
        _animator.SetBool("isMoving", state);
    }
    

    public void AimDirection(Vector3 input, bool isMouse = false)
    {
        _attacking.SetAimDirection(input, isMouse);
    }

    
}
