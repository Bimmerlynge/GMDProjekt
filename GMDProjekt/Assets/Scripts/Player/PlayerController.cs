using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using GameData;
using State;
using State.Player;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Movement _movement;
    private Attacking _attacking;
    private Health _health;
    private Animator _animator;
    private AbilityController _abilityController;
    private PlayerInputController _input;

    [SerializeField] private PlayerAbilityState _abilityState;
    private void Awake()
    {
        _input = GetComponent<PlayerInputController>();
        _animator = GetComponent<Animator>();
        _movement = GetComponent<Movement>();
        _health = GetComponent<Health>();
        _abilityController = GetComponentInChildren<AbilityController>();
        _health.OnHealthChanged += UpdateHealthUI;
    }
    
    private void Start()
    {
        RuneManager.Instance.SetPlayerTransform(transform);
        //Movement.IsMovingEvent += SetMovingState;
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
    }
    
    // Used by unity animation events
    void AxeSpecialTrigger()
    {
        _abilityController.TriggerSpecialDamage();
    }

    private void OnDestroy()
    {
        //Movement.IsMovingEvent -= SetMovingState;
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
