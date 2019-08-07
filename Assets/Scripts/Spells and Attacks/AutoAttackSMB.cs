using UnityEngine;

public class AutoAttackSMB : StateMachineBehaviour
{
    private CharacterRun charRun;
    private CharacterJump charJump;
    private CharacterCrouch charCrouch;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (charRun == null)
            charRun = animator.GetComponent<CharacterRun>();
        if (charJump == null)
            charJump = animator.GetComponent<CharacterJump>();
        if (charCrouch == null)
            charCrouch = animator.GetComponent<CharacterCrouch>();
        charRun.canRun = false;
        charJump.canJump = false;
        charCrouch.canCrouch = false;
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        charRun.canRun = true;
        charJump.canJump = true;
        charCrouch.canCrouch = true;
    }

}
