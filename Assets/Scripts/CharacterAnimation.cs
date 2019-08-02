using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown("right") || Input.GetKeyDown("left"))
        {
            anim.CrossFade("Running", 0.2f);
        }

        if (Input.GetKey("right") || Input.GetKey("left"))
        {
            anim.SetBool("isIdle", false);
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isIdle", true);
            anim.SetBool("isRunning", false);
        }
    }
}
