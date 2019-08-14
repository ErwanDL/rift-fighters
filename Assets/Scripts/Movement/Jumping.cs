using UnityEngine;

[RequireComponent(typeof(CharacterStatus))]
public class Jumping : MonoBehaviour
{
    private Rigidbody2D rb;
    private CharacterAnimation anim;
    private CharacterStatus status;

    [SerializeField]
    private float jumpHeight = 50f;
    private int numJumps = 0;
    [SerializeField, Tooltip("Maximum number of jumps the character can perform in a row")]
    private int maxJumps = 2;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<CharacterAnimation>();
        status = GetComponent<CharacterStatus>();
        numJumps = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (status.canJump && Input.GetKeyDown("space") && CanStillJump())
        {
            if (numJumps == 1)
            {
                anim.setParameterToTrueAndOthersToFalse("isDoubleJumping");
            }
            else
                anim.setParameterToTrueAndOthersToFalse("isJumping");
            SetAbilities(false);
            float currentY = rb.velocity.y;
            if (currentY <= 0)
                rb.velocity = new Vector2(0, jumpHeight);
            else
                rb.velocity = new Vector2(0, currentY + jumpHeight);
            ++numJumps;

        }
        if (rb.velocity.y < -0.1 && !anim.animator.GetBool("isCrouching"))
        {
            anim.setParameterToTrueAndOthersToFalse("isFalling");
            SetAbilities(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Ground") && !anim.animator.GetBool("isCrouching"))
        {
            numJumps = 0;
            anim.setParameterToTrueAndOthersToFalse("isIdle");
            SetAbilities(true);
        }

    }
    private bool CanStillJump()
    {
        return numJumps < maxJumps && !anim.animator.GetBool("isCrouching");
    }

    void SetAbilities(bool b)
    {
        status.canCrouch = b;
        status.canAutoAttack = b;
        status.canUseQ = b;
    }
}