using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterJump : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField]
    private CharacterMovement charMovement = null;

    [SerializeField, Tooltip("Max height the character will jump regardless of gravity")]
    private float jumpHeight = 50f;
    [SerializeField, Tooltip("Number of jumps the character has done so far (resets when touching the ground")]
    private int numJumps = 0;
    [SerializeField, Tooltip("Maximum number of jumps the character can perform in a row (always >= numJumps)")]
    private int maxJumps = 2;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        charMovement = GetComponent<CharacterMovement>();
        numJumps = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space") && canJump())
        {
            rb.velocity = new Vector2(0, jumpHeight);
            ++numJumps;
            charMovement.status = Status.jumping;
        }
        if (rb.velocity.y < -0.1 && charMovement.status != Status.crouching)
            charMovement.status = Status.falling;
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Ground"))
        {
            numJumps = 0;
            if (charMovement.status != Status.crouching)
                charMovement.status = Status.idle;
        }
    }
    private bool canJump()
    {
        return numJumps < maxJumps && charMovement.status != Status.crouching;
    }

}
