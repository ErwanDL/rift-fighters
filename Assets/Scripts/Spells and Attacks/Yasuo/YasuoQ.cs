using UnityEngine;

public class YasuoQ : MeleeAttack
{
    private int consecutiveHits = 0;

    override protected void Start()
    {
        base.Start();
        anim = GetComponent<CharacterAnimation>();
        status = GetComponent<CharacterStatus>();
        coll.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown("a") && status.canUseQ)
        {
            anim.animator.SetTrigger("basicQ");
        }
    }

    override public void OnHitEnemy(Collider2D other)
    {
        base.OnHitEnemy(other);
        consecutiveHits += 1;
    }

}

