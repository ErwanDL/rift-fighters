using UnityEngine;

public class CharacterAutoAttack : MeleeAttack
{

    void Start()
    {
        charAnim = GetComponent<CharacterAnimation>();
        coll.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown("q") && canUseSpell)
        {
            charAnim.animator.SetTrigger("autoAttack");
        }
    }
}
