using UnityEngine;
using System.Collections;

public abstract class MeleeAttack : Spell
{
    public BoxCollider2D associatedCollider;

    [SerializeField]
    protected int attackDamage = 10;

    [SerializeField]
    private float delayBeforeHitScan = 0f;
    private string enemyLayer;
    private ContactFilter2D contactFilter;

    override protected void Start()
    {
        base.Start();
        contactFilter = new ContactFilter2D();
        string parentLayer = LayerMask.LayerToName(gameObject.layer);
        enemyLayer = parentLayer == "Red side" ? "Blue Side" : "Red Side";
        contactFilter.SetLayerMask(LayerMask.GetMask(enemyLayer));
        contactFilter.useTriggers = true;
    }

    private IEnumerator AttackCoroutine()
    {
        Collider2D[] collidedEnemies = new Collider2D[2];
        Debug.Log("bite1");
        yield return new WaitForSeconds(delayBeforeHitScan);
        Debug.Log("bite2");
        int nb = associatedCollider.OverlapCollider(contactFilter, collidedEnemies);
        if (nb == 1)
        {
            CharacterManager hitEnemy = collidedEnemies[0].GetComponentInParent<CharacterManager>();
            if (hitEnemy != null)
                OnHitEnemy(hitEnemy);
            else
                Debug.Log("Warning : what was hit was not a character");
        }
        else if (nb > 1)
        {
            Debug.Log("Warning : more than one enemy were hit");
            foreach (Collider2D c in collidedEnemies)
                if (c != null)
                    Debug.Log(c.name);
        }
        GoInCooldown();
        yield return null;
    }

    protected void LaunchAttack()
    {
        StartCoroutine("AttackCoroutine");
    }

    protected virtual void OnHitEnemy(CharacterManager hitEnemy)
    {
        hitEnemy.TakeDamage(attackDamage);
    }
}
