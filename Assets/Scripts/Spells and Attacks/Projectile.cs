using UnityEngine;

public class Projectile : MonoBehaviour
{
    [HideInInspector]
    public ProjectileSpell caster = null;

    [SerializeField, Tooltip("Size increase per second of lifetime")]
    private float growthRate = 0f;

    [HideInInspector]
    public string enemyLayer;

    private void Update()
    {
        if (growthRate != 0)
            transform.localScale *= 1 + growthRate * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer(enemyLayer))
        {
            CharacterManager hitEnemy = other.GetComponent<CharacterManager>();
            if (hitEnemy != null)
                caster.OnHitEnemy(hitEnemy);
            else
                Debug.LogWarning("Warning : what was hit was not an enemy.");

        }
    }
}