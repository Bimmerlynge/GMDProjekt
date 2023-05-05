using State;
using UnityEngine;
using UnityEngine.AI;
using Event = GameData.Event;

namespace Enemies.Spider.States
{
    public class SpiderChase : IEnemyState
    {
        private EnemyAI _context;
        private IEnemyState _nextState;
        private Event _stage;
        private GameObject _enemy;
        private Animator _anim;
        private Transform _player;
        private NavMeshAgent _agent;

        public SpiderChase(EnemyAI context, GameObject enemy, Animator anim, Transform player, NavMeshAgent agent)
        {
            _context = context;
            _enemy = enemy;
            _anim = anim;
            _player = player;
            _agent = agent;
            _stage = Event.Enter;
        }
        
        public void Process()
        {
            if (_stage == Event.Enter) Enter();
            if (_stage == Event.Update) Update();
            if (_stage == Event.Exit)
            {
                Exit();
                _context.SetState(_nextState);
            }
        }

        public void Enter()
        {
            _agent.isStopped = false;
            _anim.SetTrigger("isChasing");
            _stage = Event.Update;
        }

        public void Update()
        {
            _agent.SetDestination(_player.position);
            if (InAttackRange())
            {
                _nextState = new SpiderAttack(_context, _enemy, _anim, _player, _agent);
                _stage = Event.Exit;
                return;
            }

            _stage = Event.Update;
        }

        public void Exit()
        {
            _anim.ResetTrigger("isChasing");
            _stage = Event.Exit;
        }

        private bool InAttackRange()
        {
            var distance = Vector3.Distance(_enemy.transform.position, _player.position);
            return distance < 3f;
        }

    }
}