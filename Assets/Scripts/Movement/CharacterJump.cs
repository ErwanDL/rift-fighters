using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterJump : MonoBehaviour
{
    private Rigidbody2D rb;

    private CharacterAnimation charAnim;
    private CharacterCrouch charCrouch;

    [SerializeField]
    private float jumpHeight = 50f;
    private int numJumps = 0;
    [SerializeField, Tooltip("Maximum number of jumps the character can perform in a row")]
    private int maxJumps = 2;

    public bool canJump = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        charAnim = GetComponent<CharacterAnimation>();
        charCrouch = GetComponent<CharacterCrouch>();
        numJumps = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (canJump && Input.GetKeyDown("space") && canStillJump())
        {
            rb.velocity = new Vector2(0, jumpHeight);
            ++numJumps;
            charAnim.setParameterToTrueAndOthersToFalse("isJumping");
            charCrouch.canCrouch = false;
        }
        if (rb.velocity.y < -0.1 && !charAnim.animator.GetBool("isCrouching"))
        {
            charAnim.setParameterToTrueAndOthersToFalse("isFalling");
            charCrouch.canCrouch = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Ground") && !charAnim.animator.GetBool("isCrouching"))
        {
            numJumps = 0;
            charAnim.setParameterToTrueAndOthersToFalse("isIdle");
            charCrouch.canCrouch = true;

        }

    }
    private bool canStillJump()
    {
        return numJumps < maxJumps && !charAnim.animator.GetBool("isCrouching");
    }
}