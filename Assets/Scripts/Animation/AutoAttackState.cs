using UnityEngine;

public class AutoAttackState : StateMachineBehaviour
{
    private CharacterRun charRun;
    private CharacterJump charJump;
    private CharacterCrouch charCrouch;

    private YasuoE yasE;
    private BoxCollider2D coll;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (charRun == null)
            charRun = animator.GetComponent<CharacterRun>();
        if (charJump == null)
            charJump = animator.GetComponent<CharacterJump>();
        if (charCrouch == null)
            charCrouch = animator.GetComponent<CharacterCrouch>();
        if (coll == null)
            coll = animator.GetComponent<CharacterAutoAttack>().coll;
        if (yasE == null)
            yasE = animator.GetComponent<YasuoE>();
        canDoOtherActions(false);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        canDoOtherActions(true);
    }

    void canDoOtherActions(bool b)
    {
        charRun.canRun = b;
        charJump.canJump = b;
        charCrouch.canCrouch = b;
        yasE.canDash = b;
        coll.enabled = !b;
    }

}
