using UnityEngine;

public abstract class MeleeAttack : Spell
{
    public BoxCollider2D coll;

    [SerializeField]
    protected int attackDamage = 10;

    virtual public void OnHitEnemy(Collider2D other)
    {
        CharacterManager hitEnemy = other.GetComponent<CharacterManager>();
        if (hitEnemy != null)
            hitEnemy.TakeDamage(attackDamage);
    }
}
