using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MeleeIdle : StateMachineBehaviour
{
    private Transform player;
    private Transform enemy;

    private float chillRange = 7f;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (animator == null) return;
        player = GameObject.FindWithTag("Player").transform;
        enemy = animator.transform;

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (animator == null) return;
        if (PlayerInRange())
        {
            animator.SetBool("isChasing", true);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }


    private bool PlayerInRange()
    {
        var distance = Vector3.Distance(enemy.position, player.position);
        return distance < chillRange;
    }
}
