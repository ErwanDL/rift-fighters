using UnityEngine;

public class SpellStateMachine : StateMachineBehaviour
{
    private CharacterStatus status;

    [Header("Actions performable while this action is playing")]
    [SerializeField]
    private bool canRun = false;

    [SerializeField]
    private bool canJump = false;

    [SerializeField]
    private bool canCrouch = false;

    [SerializeField]
    private bool canAutoAttack = false;

    [SerializeField]
    private bool canUseQ = false;

    [SerializeField]
    private bool canUseE = false;

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
        status.canRun = b || canRun;
        status.canJump = b || canJump;
        status.canCrouch = b || canCrouch;
        status.canAutoAttack = b || canAutoAttack;
        status.canUseQ = b || canUseQ;
        status.canUseE = b || canUseE;
    }

}
