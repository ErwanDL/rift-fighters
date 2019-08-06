using UnityEngine;

public class AutoAttackSMB : StateMachineBehaviour
{
    [SerializeField]
    private CharacterMovement characterMovement = null;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (characterMovement == null)
            characterMovement = animator.gameObject.GetComponentInParent<CharacterMovement>();
        characterMovement.canMove = false;
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        characterMovement.canMove = true;
    }

}
