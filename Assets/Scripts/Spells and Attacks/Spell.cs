using UnityEngine;

public enum SpellState
{
    Ready,
    InCast,
    InCooldown
}
[RequireComponent(typeof(CharacterStatus))]
public abstract class Spell : MonoBehaviour
{
    public float baseCooldown = 3f;

    [HideInInspector]
    public float cooldownTimer = 0f;
    protected SpellState spellState;
    protected CharacterStatus status;
    protected CharacterAnimation anim;

    virtual protected void Start()
    {
        status = GetComponent<CharacterStatus>();
        anim = GetComponent<CharacterAnimation>();
        spellState = SpellState.Ready;
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

    protected void GoInCooldown()
    {
        cooldownTimer = baseCooldown;
        spellState = SpellState.InCooldown;
    }
}

