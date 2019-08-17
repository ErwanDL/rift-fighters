using UnityEngine;

public abstract class MeleeAttack : Spell
{
    [Header("MeleeAttack parameters")]
    [SerializeField]
    protected Collider2D associatedCollider = null;

    override protected void OnIncantationEnd()
    {
        Collider2D[] collidedEnemies = new Collider2D[2];
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
    }
}
