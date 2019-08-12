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
    [HideInInspector]
    public float cooldownTimer = 0f;

    public float baseCooldown = 10f;
    protected SpellState spellState;

    protected CharacterStatus status;
    protected CharacterAnimation anim;

    virtual protected void Start()
    {
        status = GetComponent<CharacterStatus>();
        anim = GetComponent<CharacterAnimation>();
        spellState = SpellState.Ready;
    }
}

