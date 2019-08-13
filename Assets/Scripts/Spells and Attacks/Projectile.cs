using UnityEngine;

public class Projectile : MonoBehaviour
{
    [HideInInspector]
    public ProjectileSpell caster = null;

    [HideInInspector]
    public string enemyLayer;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer(enemyLayer))
        {
            CharacterManager hitEnemy = other.GetComponent<CharacterManager>();
            if (hitEnemy != null)
                caster.OnProjectileHitEnemy(hitEnemy);
            else
                Debug.LogWarning("Warning : what was hit was not an enemy.");

        }
    }
}