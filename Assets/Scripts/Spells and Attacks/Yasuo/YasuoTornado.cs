using UnityEngine;

public class YasuoTornado : ProjectileSpell
{
    override protected void OnReachMaxRange()
    {
        instantiatedProjectile.GetComponent<ParticleSystem>().Stop();
        instantiatedProjectile.GetComponent<Rigidbody2D>().velocity = default;
        instantiatedProjectile.GetComponent<BoxCollider2D>().enabled = false;
        Destroy(instantiatedProjectile.gameObject, 2f);
    }
}