using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class CharacterMovement : MonoBehaviour
{
    [SerializeField, Tooltip("Max speed that the character reach when running.")]
    private float speed = 15.0f;

    [SerializeField, Tooltip("Acceleration while grounded.")]
    private float walkAcceleration = 20.0f;

    [SerializeField, Tooltip("Acceleration while in the air")]
    private float airAcceleration = 30.0f;
    [SerializeField, Tooltip("Deceleration applied when character is grounded and not attempting to move.")]
    private float groundDeceleration = 50.0f;
    private bool isRunning = false;
    private CharacterJump jumpScript;

    [SerializeField, Tooltip("Apply more gravity")]
    private float addedGravity = 20f;
    private Vector2 velocity = default;
    [SerializeField]
    private Rigidbody2D rb;

    /// <summary>
    /// Set to true when the character intersects a collider beneath
    /// them in the previous frame.
    /// </summary>
    private bool grounded;

    private void Start()
    {
        speed *= 100;
        walkAcceleration *= 100;
        airAcceleration *= 100;

        isRunning = false;
        grounded = true;
        jumpScript = GetComponent<CharacterJump>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Use GetAxisRaw to ensure our input is either 0, 1 or -1.
        float moveInput = Input.GetAxisRaw("Horizontal");

        float acceleration = grounded ? walkAcceleration : airAcceleration;
        float deceleration = grounded ? groundDeceleration : 0;

        if (moveInput != 0)
        {
            rb.velocity = new Vector2(Mathf.MoveTowards(velocity.x, speed * moveInput, acceleration * Time.deltaTime), rb.velocity.y);
            Vector3 currentRot = transform.rotation.eulerAngles;
            float rotY = moveInput > 0 ? 0 : 180;
            Vector3 newRot = new Vector3(0, rotY, 0);
            transform.rotation = Quaternion.Euler(newRot);
            isRunning = true;
        }
        else
        {
            rb.velocity = new Vector2(Mathf.MoveTowards(velocity.x, 0, deceleration * Time.deltaTime), rb.velocity.y);
            isRunning = false;
        }
    }
}