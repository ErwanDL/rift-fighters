using UnityEngine;

public abstract class Spell : MonoBehaviour
{
    [HideInInspector]
    public float cooldownTimer = 0f;

    [SerializeField]
    public float baseCooldown = 10f;

    public bool canUseSpell = true;
}

