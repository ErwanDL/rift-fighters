using UnityEngine;

public class AutoAttacking : MeleeAttack
{

    override protected void Update()
    {
        base.Update();

        if (spellState == SpellState.Ready)
        {
            if (Input.GetKeyDown("q") && status.canAutoAttack)
            {
                anim.animator.SetTrigger("autoAttack");
                CastSpell();
            }
        }
    }
}
