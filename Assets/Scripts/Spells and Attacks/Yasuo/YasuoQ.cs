using UnityEngine;

public class YasuoQ : MeleeAttack
{
    private int consecutiveHits = 0;

    private void Start()
    {
        charAnim = GetComponent<CharacterAnimation>();
        coll.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown("a") && canUseSpell)
        {
            charAnim.animator.SetTrigger("basicQ");
        }
    }

    override public void OnHitEnemy(Collider2D other)
    {
        base.OnHitEnemy(other);
        consecutiveHits += 1;
    }

}

