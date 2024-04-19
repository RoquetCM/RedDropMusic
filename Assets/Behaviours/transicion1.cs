using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transicion1 : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        CombatManager.instance.SetPuederecibirInput(true);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (CombatManager.instance.GetInputRecibido())
        {
            CombatManager.instance.SetPermitirMovimiento(false);
            animator.SetTrigger("ataque2");
            CombatManager.instance.inputManager();
            CombatManager.instance.SetInputRecibido(false);

        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
   // public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    CombatManager.instance.SetPermitirMovimiento(true);
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
