using UnityEngine;

namespace State.MeleeAI
{
    public class MeleeIdle : StateMachineBehaviour
    {
        private Transform player;
        private Transform enemy;

        private float chillRange = 7f;
        
        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (animator == null) return;
            player = GameObject.FindWithTag("Player").transform;
            enemy = animator.transform;
        
        }
        
        override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (animator == null) return;
            if (PlayerInRange())
            {
                animator.SetBool("isChasing", true);
            }
        }
        override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
        
        }
        
        private bool PlayerInRange()
        {
            if (player == null) Destroy(enemy.gameObject);
            var distance = Vector3.Distance(enemy.position, player.position);
            return distance < chillRange;
        }
    }
}
