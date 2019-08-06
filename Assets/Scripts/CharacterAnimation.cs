using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    [HideInInspector]
    public Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        /* foreach (AnimatorControllerParameter parameter in anim.parameters)
            if (anim.GetBool(parameter.name))
                Debug.Log(parameter.name); */
    }
    public void setParameterToTrueAndOthersToFalse(string parameterToSet)
    {
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
