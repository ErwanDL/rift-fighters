using UnityEngine;

public class YasuoQ : MeleeAttack
{
    private int consecutiveHits = 0;


    override protected void Update()
    {
        base.Update();
        if (spellState == SpellState.Ready)
        {
            if (Input.GetKeyDown("a") && status.canUseQ)
            {
                anim.animator.SetTrigger("basicQ");
                LaunchAttack();
            }
        }
    }

    override protected void OnHitEnemy(CharacterManager hitEnemy)
    {
        base.OnHitEnemy(hitEnemy);
        consecutiveHits += 1;
    }

}

