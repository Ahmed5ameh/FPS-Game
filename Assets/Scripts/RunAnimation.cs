using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunAnimation : StateMachineBehaviour
{
    public float speed = 0.25f;
    public float attackRange = 5f;
    Transform player;
    Rigidbody rb;
    
    

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; //player ref
        rb = animator.GetComponent<Rigidbody>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        Vector3 target = new Vector3(player.position.x, rb.position.y, player.position.z);
        Vector3 newPos = Vector3.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
        rb.MovePosition(newPos);

        if (Input.GetButtonDown("Fire1"))
        {
            animator.SetTrigger("Attack");  //ATTACK
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");
    }
}
