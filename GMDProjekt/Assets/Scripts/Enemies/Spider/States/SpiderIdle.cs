using GameData;
using State;
using UnityEngine;
using UnityEngine.AI;
using Event = GameData.Event;

namespace Enemies.Spider.States
{
    public class SpiderIdle : IEnemyState
    {
        private EnemyAI _context;
        private IEnemyState _nextState;
        private Event _stage;
        private GameObject _enemy;
        private Animator _anim;
        private Transform _player;
        private NavMeshAgent _agent;

        private float _dist = 7f;
        
        public SpiderIdle(EnemyAI context, GameObject enemy, Animator anim, Transform player, NavMeshAgent agent)
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
            _agent.isStopped = true;
            _anim.SetTrigger("isIdle");
            
            _stage = Event.Update;
        }

        public void Update()
        {
            if (InAttackRange())
            {
                _nextState = new SpiderAttack(_context, _enemy, _anim, _player, _agent);
                _stage = Event.Exit;
                return;
            }

            if (NoticedPlayer())
            {
                _nextState = new SpiderChase(_context, _enemy, _anim, _player, _agent);
                _stage = Event.Exit;
                return;
            }

            _stage = Event.Update;
        }

        public void Exit()
        {
            _anim.ResetTrigger("isIdle");
            _stage = Event.Exit;
        }

        private bool NoticedPlayer()
        {
            var distance = Vector3.Distance(_enemy.transform.position, _player.position);
            return distance < _dist;
        }

        private bool InAttackRange()
        {
            var distance = Vector3.Distance(_enemy.transform.position, _player.position);
            return distance < 3f;
        }
    }
}