using System;
using Enemies.Spider.States;
using GameData;
using State;
using UnityEngine;
using UnityEngine.AI;

namespace Enemies
{
    public class EnemyAI : MonoBehaviour
    {
        private Animator _anim;
        private Transform _player;
        [SerializeField] private string statename;
        
        private IEnemyState _state;
        private NavMeshAgent _agent;

        private void Awake()
        {
            _anim = GetComponent<Animator>();
            _player = GameObject.FindGameObjectWithTag("Player").transform;
            _agent = GetComponent<NavMeshAgent>();
        }

        private void Start()
        {
            _state = new SpiderIdle(this, gameObject, _anim, _player, _agent);
        }

        private void Update()
        {
            _state.Process();
            statename = _state.ToString();
        }

        public void SetState(IEnemyState state)
        {
            _state = state;
        }
    }
}