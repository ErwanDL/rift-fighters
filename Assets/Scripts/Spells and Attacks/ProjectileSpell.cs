using UnityEngine;

public class ProjectileSpell : Spell
{
    [Header("ProjectileSpell-specific parameters")]
    [SerializeField]
    protected float range = 10f;

    [SerializeField]
    protected float projectileSpeed = 10f;

    [SerializeField]
    protected int attackDamage = 10;

    [SerializeField]
    protected bool stopsOnHit = false;

    [Header("Projectile specifications")]
    [SerializeField]
    protected GameObject projectilePrefab = null;

    [SerializeField]
    protected Vector3 positionOffset = default;

    [SerializeField]
    protected Vector3 rotationOffset = default;

    protected Projectile instantiatedProjectile = null;

    public void LaunchProjectile(Vector2 normalizedDirection)
    {
        instantiatedProjectile = Instantiate(projectilePrefab, Utils.GetInstantiationPosition(transform, positionOffset),
            Utils.GetInstantiationRotation(transform, rotationOffset)).GetComponent<Projectile>();
        instantiatedProjectile.GetComponent<Rigidbody2D>().velocity = normalizedDirection * projectileSpeed;
        instantiatedProjectile.caster = this;
        instantiatedProjectile.enemyLayer = enemyLayer;
        Destroy(instantiatedProjectile.gameObject, range / projectileSpeed);
    }

    virtual public void OnProjectileHitEnemy(CharacterManager hitEnemy)
    {
        Debug.Log("Enemy hit");
    }
}