using UnityEngine;
using System.Collections;

public enum SpellState
{
    Ready,
    InCast,
    InCooldown
}
[RequireComponent(typeof(CharacterStatus)), RequireComponent(typeof(CharacterAnimation))]
public abstract class Spell : MonoBehaviour
{
    public float baseCooldown = 3f;

    [SerializeField]
    protected int attackDamage = 10;

    [SerializeField]
    protected float incantationDelay = 0f;

    [HideInInspector]
    public float cooldownTimer = 0f;
    [HideInInspector]
    public SpellState spellState;
    protected CharacterStatus status;
    protected CharacterAnimation anim;
    protected ContactFilter2D contactFilter;
    protected string enemyLayer;

    virtual protected void Start()
    {
        status = GetComponent<CharacterStatus>();
        anim = GetComponent<CharacterAnimation>();
        spellState = SpellState.Ready;
        contactFilter = new ContactFilter2D();
        string parentLayer = LayerMask.LayerToName(gameObject.layer);
        enemyLayer = parentLayer == "Red side" ? "Blue Side" : "Red Side";
        contactFilter.SetLayerMask(LayerMask.GetMask(enemyLayer));
        contactFilter.useTriggers = true;
    }

    virtual protected void Update()
    {
        if (spellState == SpellState.InCooldown)
        {
            cooldownTimer -= Time.deltaTime;
            if (cooldownTimer <= 0)
            {
                cooldownTimer = 0;
                spellState = SpellState.Ready;
            }
        }
    }

    virtual protected void OnIncantationEnd()
    {
    }

    public void CastSpell()
    {
        Invoke("OnIncantationEnd", incantationDelay);
    }

    protected void GoInCooldown()
    {
        cooldownTimer = baseCooldown;
        spellState = SpellState.InCooldown;
    }

    virtual public void OnHitEnemy(CharacterManager hitEnemy)
    {
        hitEnemy.TakeDamage(attackDamage);
    }
}

