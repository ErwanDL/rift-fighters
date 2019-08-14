using UnityEngine;

abstract public class ProjectileSpell : Spell
{
    [Header("ProjectileSpell parameters")]
    [SerializeField]
    protected float range = 10f;

    [SerializeField]
    protected float projectileSpeed = 10f;

    [SerializeField]
    protected bool stopsOnHit = false;

    [Header("Projectile instantiation")]
    [SerializeField]
    protected GameObject projectilePrefab = null;

    [SerializeField]
    protected Vector3 positionOffset = default;

    [SerializeField]
    protected Vector3 rotationOffset = default;
    protected Projectile instantiatedProjectile = null;

    override protected void OnIncantationEnd()
    {
        Vector2 direction = transform.rotation.eulerAngles.y < 180 ? Vector2.right : Vector2.left;
        instantiatedProjectile = Instantiate(projectilePrefab, Utils.GetInstantiationPosition(transform, positionOffset),
            Utils.GetInstantiationRotation(transform, rotationOffset)).GetComponent<Projectile>();
        instantiatedProjectile.GetComponent<Rigidbody2D>().velocity = direction * projectileSpeed;
        instantiatedProjectile.caster = this;
        instantiatedProjectile.enemyLayer = enemyLayer;
        Invoke("OnReachMaxRange", range / projectileSpeed);
    }

    virtual protected void OnReachMaxRange()
    {
        Destroy(instantiatedProjectile.gameObject);
    }
}