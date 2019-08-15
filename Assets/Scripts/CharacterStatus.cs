using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterStatus : MonoBehaviour
{
    [HideInInspector]
    public bool canRun;

    [HideInInspector]
    public bool canJump;

    [HideInInspector]
    public bool canCrouch;

    [HideInInspector]
    public bool canAutoAttack;

    [HideInInspector]
    public bool canUseQ;

    [HideInInspector]
    public bool canUseE;
    private Rigidbody2D rb;
    private float defaultGravity;

    [SerializeField]
    private static float knockupStrength = 10f;

    private void Awake()
    {
        SetAllAbilities(true);
        rb = GetComponent<Rigidbody2D>();
        defaultGravity = rb.gravityScale;
    }

    private IEnumerator KnockupCoroutine(float duration)
    {
        SetAllAbilities(false);
        rb.gravityScale = 0;
        rb.velocity = new Vector3(0, knockupStrength, 0);

        yield return new WaitForSeconds(duration);

        SetAllAbilities(true);
        rb.gravityScale = defaultGravity;

        yield return null;
    }

    public void Knockup(float duration)
    {
        StartCoroutine("KnockupCoroutine", duration);
    }

    private void SetAllAbilities(bool b)
    {
        canRun = b;
        canJump = b;
        canCrouch = b;
        canAutoAttack = b;
        canUseQ = b;
        canUseE = b;
    }
}