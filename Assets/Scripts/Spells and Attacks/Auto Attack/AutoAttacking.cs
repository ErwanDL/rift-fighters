using UnityEngine;

public class AutoAttacking : MeleeAttack
{

    override protected void Start()
    {
        base.Start();
        coll.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown("q") && status.canAutoAttack)
        {
            anim.animator.SetTrigger("autoAttack");
        }
    }
}
