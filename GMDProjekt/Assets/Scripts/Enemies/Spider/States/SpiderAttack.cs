using System;
using State;
using UnityEngine;
using UnityEngine.AI;
using Event = GameData.Event;

namespace Enemies.Spider.States
{
    public class SpiderAttack : IEnemyState
    {
        private EnemyAI _context;
        private IEnemyState _nextState;
        private Event _stage;
        private GameObject _enemy;
        private Animator _anim;
        private Transform _player;
        private NavMeshAgent _agent;

        private bool animationPlayed;
        public SpiderAttack(EnemyAI context, GameObject enemy, Animator anim, Transform player, NavMeshAgent agent)
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
            _anim.SetTrigger("attack");
            _stage = Event.Update;
        }

        public void Update()
        {
            var animStateInfo = _anim.GetCurrentAnimatorStateInfo(0);
            AnimationStartedFlagCheck(animStateInfo);

            if (!animationPlayed) return;
            if (AnimationDone(animStateInfo))
            {
                _nextState = new SpiderChase(_context, _enemy, _anim, _player, _agent);
                _stage = Event.Exit;
                return;
            }

            _stage = Event.Update;
        }

        public void Exit()
        {
            _anim.ResetTrigger("attack");
            _stage = Event.Exit;
        }

        private void AnimationStartedFlagCheck(AnimatorStateInfo info)
        {
            if (info.IsName("attack")) animationPlayed = true;
        }

        private bool AnimationDone(AnimatorStateInfo info)
        {
            return animationPlayed && !info.IsName("attack");
        }

    }
}