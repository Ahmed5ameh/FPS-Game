using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DieAnimation : StateMachineBehaviour
{
    int countBullets = 0;
    Rigidbody rb;
    GameObject E;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rb = animator.GetComponent<Rigidbody>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Input.GetButtonDown("Fire1")) 
        {
            countBullets++;
        }

        if (EnemyHealth.FindObjectOfType<Slider>().value == 0)
        {
            animator.SetTrigger("Die");
            //animator.SetLayer("Dead");
            //rb.freezeRotation = true;
            //Destroy(this);
            //E = GameObject.Find("")
        }
        
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rb.freezeRotation = true;
    }


}
