using UnityEngine;

public abstract class Spell : MonoBehaviour
{
    [HideInInspector]
    public float cooldownTimer = 0f;

    [SerializeField]
    protected float baseCooldown = 10f;
}

