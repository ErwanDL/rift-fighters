using UnityEngine;

public class AutoAttackState : StateMachineBehaviour
{
    private CharacterStatus status;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (status == null)
            status = animator.GetComponent<CharacterStatus>();
        SetAbilities(false);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        SetAbilities(true);
    }

    void SetAbilities(bool b)
    {
        status.canRun = b;
        status.canJump = b;
        status.canCrouch = b;
        status.canUseQ = b;
        status.canUseE = b;
    }

}
