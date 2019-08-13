using UnityEngine;
using System.Collections;

public abstract class MeleeAttack : Spell
{
    [Header("MeleeAttack-specific parameters")]
    [SerializeField]
    private BoxCollider2D associatedCollider = null;

    [SerializeField]
    protected int attackDamage = 10;

    [SerializeField]
    private float delayBeforeHitScan = 0f;

    private IEnumerator AttackCoroutine()
    {
        Collider2D[] collidedEnemies = new Collider2D[2];
        yield return new WaitForSeconds(delayBeforeHitScan);

        int nb = associatedCollider.OverlapCollider(contactFilter, collidedEnemies);
        if (nb == 1)
        {
            CharacterManager hitEnemy = collidedEnemies[0].GetComponentInParent<CharacterManager>();
            if (hitEnemy != null)
                OnHitEnemy(hitEnemy);
            else
                Debug.LogWarning("Warning : what was hit was not a character");
        }

        else if (nb > 1)
        {
            Debug.LogWarning("Warning : more than one enemy were hit");
            foreach (Collider2D c in collidedEnemies)
                if (c != null)
                    Debug.LogWarning(c.name);
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
