using UnityEngine;

public class YasuoTornado : ProjectileSpell
{
    [Header("Tornado-specific parameters")]
    [SerializeField]
    private float knockupDuration = 1f;
    override protected void OnReachMaxRange()
    {
        instantiatedProjectile.GetComponent<ParticleSystem>().Stop();
        instantiatedProjectile.GetComponent<Rigidbody2D>().velocity = default;
        instantiatedProjectile.GetComponent<BoxCollider2D>().enabled = false;
        Destroy(instantiatedProjectile.gameObject, 2f);
    }

    override public void OnHitEnemy(CharacterManager hitEnemy)
    {
        base.OnHitEnemy(hitEnemy);
        hitEnemy.GetComponent<CharacterStatus>().Knockup(knockupDuration);
    }
}