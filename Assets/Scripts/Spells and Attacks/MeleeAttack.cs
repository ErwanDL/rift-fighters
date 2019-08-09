using UnityEngine;

public abstract class MeleeAttack : Spell
{
    protected CharacterAnimation charAnim;
    public BoxCollider2D coll;

    [SerializeField]
    protected int attackDamage = 10;

    virtual public void OnHitEnemy(Collider2D other)
    {
        Player hitPlayer = other.GetComponent<Player>();
        if (hitPlayer != null)
            hitPlayer.TakeDamage(attackDamage);
    }
}
