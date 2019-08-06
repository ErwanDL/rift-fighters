using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    [HideInInspector]
    public Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        /* foreach (AnimatorControllerParameter parameter in anim.parameters)
            if (anim.GetBool(parameter.name))
                Debug.Log(parameter.name); */
    }
    public void setParameterToTrueAndOthersToFalse(string parameterToSet)
    {
        foreach (AnimatorControllerParameter parameter in animator.parameters)
        {
            if (parameter.type == AnimatorControllerParameterType.Bool)
            {
                animator.SetBool(parameter.name, false);
            }
        }
        animator.SetBool(parameterToSet, true);
    }
}
