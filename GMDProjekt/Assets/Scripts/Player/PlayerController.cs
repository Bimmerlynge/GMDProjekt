using GameData;
using Managers;
using Player.Abilities;
using Shared;
using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {

        private Movement _movement;
        private Health _health;
        private Animator _animator;
        private AbilityController _abilityController;
        private PlayerInputController _input;

        [SerializeField] private PlayerAbilityState abilityState;
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

        private void UpdateHealthUI(float value)
        {
            UIManager.Instance.SetHealthBarValue(value);
            healthData.Value = _health.CurrentHealth;
        }
        
        private void HandleDeath(GameObject obj)
        {
            if (!(obj == gameObject)) return;
            if (_health.CurrentHealth <= 0f)
            {
                GameStateHandler.Instance.CurrentState = GameState.Quitting;
                UIManager.Instance.OpenEndGameMenu();
                Invoke("Die", 0.5f);
            }
        }

        private void Die()
        {
            Destroy(gameObject);
        }

        private void SetMovingState(bool state)
        {
            print("animator null? " + (_animator == null));
            print("abilitState null? " + (abilityState == null));
            if (abilityState.currentState == PlayerAbilityState.AbilityState.Busy) return;
            _animator.SetBool("isMoving", state);
        }
        
        // Unity animation event
        public void AnimationStarted()
        {
            _movement.enabled = false;
        }
        // Unity animation event
        public void AnimationFinished()
        {
            _movement.enabled = true;
        }
        
        // Used by unity animation events
        void AxeSpecialTrigger()
        {
            _abilityController.TriggerSpecialDamage();
        }
    }
}
