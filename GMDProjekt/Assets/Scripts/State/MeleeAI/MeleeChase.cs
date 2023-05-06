using UnityEngine;
using UnityEngine.AI;

namespace State.MeleeAI
{
    public class MeleeChase : StateMachineBehaviour
    {
        private Transform player;
        private Transform enemy;

        private NavMeshAgent agent;

        private float attackRange = 3f;
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo,
            int layerIndex)
        {
            if (animator == null) return;
            player = GameObject.FindWithTag("Player").transform;
            enemy = animator.transform;

            agent = animator.GetComponent<NavMeshAgent>();
            agent.isStopped = false;
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo,
            int layerIndex)
        {
            if (animator == null) return;
            agent.isStopped = true;
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo,
            int layerIndex)
        {
            if (animator == null) return;
            
            agent.SetDestination(player.position);
            if (InAttackRange())
            {
                animator.SetTrigger("attack");
            }
        }

        private bool InAttackRange()
        {
            var distance = Vector3.Distance(enemy.position, player.position);
            return distance < attackRange;
        }

    }
}