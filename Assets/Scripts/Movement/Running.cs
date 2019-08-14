using UnityEngine;

[RequireComponent(typeof(CharacterStatus))]
public class Running : MonoBehaviour
{
    [SerializeField, Tooltip("Max speed that the character reaches when running.")]
    private float speed = 30.0f;

    [SerializeField, Tooltip("Deceleration applied when the character is made to stop running.")]
    private float deceleration = 100.0f;


    [HideInInspector]
    public float moveInput;

    private Rigidbody2D rb;
    private CharacterAnimation anim;
    private CharacterStatus status;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<CharacterAnimation>();
        status = GetComponent<CharacterStatus>();
        anim.setParameterToTrueAndOthersToFalse("isIdle");
    }

    private void FixedUpdate()
    {
        moveInput = Input.GetAxisRaw("Horizontal");

        if (status.canRun && moveInput != 0)
        {
            rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
            Vector3 currentRot = transform.rotation.eulerAngles;
            float rotY = moveInput > 0 ? 90 : 270;
            Vector3 newRot = new Vector3(0, rotY, 0);
            transform.rotation = Quaternion.Euler(newRot);
            if (anim.animator.GetBool("isIdle") || anim.animator.GetBool("isDashing"))
            {
                anim.setParameterToTrueAndOthersToFalse("isRunning");
            }
        }
        else
        {
            rb.velocity = new Vector2(Mathf.MoveTowards(rb.velocity.x, 0, deceleration * Time.deltaTime), rb.velocity.y);
            if (anim.animator.GetBool("isRunning"))
            {
                anim.setParameterToTrueAndOthersToFalse("isIdle");
            }
        }
    }
}