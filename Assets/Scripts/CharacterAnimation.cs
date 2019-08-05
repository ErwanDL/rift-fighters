using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    private Animator anim;

    [SerializeField]
    private CharacterMovement movementScript = null;
    private Status previousStatus;

    void Start()
    {
        anim = GetComponent<Animator>();
        previousStatus = Status.idle;
    }

    void Update()
    {
        Status newStatus = movementScript.status;
        if (newStatus == previousStatus)
            return;
        else
        {
            setParameterToTrueAndOthersToFalse(movementScript.status);
            if (newStatus == Status.running)
                anim.CrossFade("Running", 0.1f);
            else if (newStatus == Status.jumping)
                anim.CrossFade("Jumping", 0.1f);
            else if (newStatus == Status.falling)
                anim.CrossFade("Falling", 0.5f);
            else if (newStatus == Status.crouching)
                anim.CrossFade("Crouching", 0.1f);
            else
                anim.CrossFade("Idle", 0.3f);

            previousStatus = newStatus;
        }
    }

    void setParameterToTrueAndOthersToFalse(Status status)
    {
        string statusName = status.ToString();
        string parameterToSet = "is" + statusName.Substring(0, 1).ToUpper() + statusName.Substring(1);
        foreach (AnimatorControllerParameter parameter in anim.parameters)
        {
            if (parameter.type == AnimatorControllerParameterType.Bool)
            {
                anim.SetBool(parameter.name, false);
            }
        }
        anim.SetBool(parameterToSet, true);
    }
}
