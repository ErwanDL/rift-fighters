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

    public bool canMove = true;

    private Vector2 velocity = default;
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private CharacterAnimation characterAnimation = null;

    [HideInInspector]
    public float moveInput;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        characterAnimation.setParameterToTrueAndOthersToFalse("isIdle");
    }

    private void Update()
    {
        if (!canMove)
            return;

        moveInput = Input.GetAxisRaw("Horizontal");
        //Debug.Log(status.ToString());

        if (moveInput != 0 && !characterAnimation.anim.GetBool("isCrouching"))
        {
            rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
            Vector3 currentRot = transform.rotation.eulerAngles;
            float rotY = moveInput > 0 ? 0 : 180;
            Vector3 newRot = new Vector3(0, rotY, 0);
            transform.rotation = Quaternion.Euler(newRot);
            if (characterAnimation.anim.GetBool("isIdle"))
            {
                characterAnimation.setParameterToTrueAndOthersToFalse("isRunning");
            }
        }
        else
        {
            rb.velocity = new Vector2(Mathf.MoveTowards(velocity.x, 0, groundDeceleration * Time.deltaTime), rb.velocity.y);
            if (characterAnimation.anim.GetBool("isRunning"))
            {
                characterAnimation.setParameterToTrueAndOthersToFalse("isIdle");
            }
        }
    }
}