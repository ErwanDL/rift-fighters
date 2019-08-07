using UnityEngine;


public class CharacterRun : MonoBehaviour
{
    [SerializeField, Tooltip("Max speed that the character reaches when running.")]
    private float speed = 15.0f;

    [SerializeField, Tooltip("Deceleration applied when the character is made to stop running.")]
    private float deceleration = 50.0f;


    public bool canRun = true;

    [HideInInspector]
    public float moveInput;


    private Rigidbody2D rb;
    private CharacterAnimation charAnim;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        charAnim = GetComponent<CharacterAnimation>();
        charAnim.setParameterToTrueAndOthersToFalse("isIdle");
    }

    private void FixedUpdate()
    {
        moveInput = Input.GetAxisRaw("Horizontal");

        if (canRun && moveInput != 0 && !charAnim.animator.GetBool("isCrouching"))
        {
            rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
            Vector3 currentRot = transform.rotation.eulerAngles;
            float rotY = moveInput > 0 ? 90 : 270;
            Vector3 newRot = new Vector3(0, rotY, 0);
            transform.rotation = Quaternion.Euler(newRot);
            if (charAnim.animator.GetBool("isIdle"))
            {
                charAnim.setParameterToTrueAndOthersToFalse("isRunning");
            }
        }
        else
        {
            rb.velocity = new Vector2(Mathf.MoveTowards(rb.velocity.x, 0, deceleration * Time.deltaTime), rb.velocity.y);
            if (charAnim.animator.GetBool("isRunning"))
            {
                charAnim.setParameterToTrueAndOthersToFalse("isIdle");
            }
        }
    }
}