using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class CharacterMovement : MonoBehaviour
{
    [SerializeField, Tooltip("Max speed that the character reach when running.")]
    private float speed = 30.0f;

    [SerializeField, Tooltip("Acceleration while grounded.")]
    private float walkAcceleration = 75.0f;

    [SerializeField, Tooltip("Acceleration while in the air.")]
    private float airAcceleration = 30.0f;

    [SerializeField, Tooltip("Deceleration applied when character is grounded and not attempting to move.")]
    private float groundDeceleration = 70.0f;

    [SerializeField, Tooltip("Max height the character will jump regardless of gravity")]
    private float jumpHeight = 15.0f;

    [SerializeField, Tooltip("Apply more gravity")]
    private float addedGravity = 20f;

    private BoxCollider2D boxCollider;

    private Vector2 velocity;

    [SerializeField]
    private Animation runningAnim = null;

    /// <summary>
    /// Set to true when the character intersects a collider beneath
    /// them in the previous frame.
    /// </summary>
    private bool grounded;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        // Use GetAxisRaw to ensure our input is either 0, 1 or -1.
        float moveInput = Input.GetAxisRaw("Horizontal");

        if (grounded)
        {
            velocity.y = 0;

            if (Input.GetKeyDown("space"))
            {
                // Calculate the velocity required to achieve the target jump height.
                velocity.y = Mathf.Sqrt(2 * jumpHeight * Mathf.Abs(Physics2D.gravity.y));
            }
        }

        float acceleration = grounded ? walkAcceleration : airAcceleration;
        float deceleration = grounded ? groundDeceleration : 0;

        if (moveInput != 0)
        {
            velocity.x = Mathf.MoveTowards(velocity.x, speed * Mathf.Abs(moveInput), acceleration * Time.deltaTime);
            Vector3 currentRot = transform.rotation.eulerAngles;
            float rotY = moveInput > 0 ? 0 : 180;
            Vector3 newRot = new Vector3(0, rotY, 0);
            transform.rotation = Quaternion.Euler(newRot);
        }
        else
        {
            velocity.x = Mathf.MoveTowards(velocity.x, 0, deceleration * Time.deltaTime);
        }

        velocity.y += Physics2D.gravity.y * Time.deltaTime * addedGravity;

        transform.Translate(velocity * Time.deltaTime);

        grounded = false;

        // Retrieve all colliders we have intersected after velocity has been applied.
        Collider2D[] hits = Physics2D.OverlapBoxAll(transform.position, boxCollider.size, 0);

        foreach (Collider2D hit in hits)
        {
            // Ignore our own collider.
            if (hit == boxCollider)
                continue;
            ColliderDistance2D colliderDistance = hit.Distance(boxCollider);
            // Ensure that we are still overlapping this collider.
            // The overlap may no longer exist due to another intersected collider
            // pushing us out of this one.
            if (colliderDistance.isOverlapped && !hit.gameObject.CompareTag("YouShallNotPass"))
            {
                transform.Translate(colliderDistance.pointA - colliderDistance.pointB);
                // If we intersect an object beneath us, set grounded to true. 
                if (Vector2.Angle(colliderDistance.normal, Vector2.up) < 90 && velocity.y < 0)
                {
                    grounded = true;
                }
            }

        }
    }
}



// using UnityEngine;

// public class CharacterMovement : MonoBehaviour
// {

//     [SerializeField]
//     private float acceleration = 15f;
//     [SerializeField]
//     private float maxSpeed = 30.0f;

//     private float currentSpeed = 0.0f;

//     private string lastKeyPressed = null;

//     [SerializeField]
//     private Rigidbody2D rb;
//     [SerializeField]
//     private CharacterController charCtrl;

//     private bool lastDir = true;    //true si droite, false si gauche
//     private float jumpSpeed = 50f;

//     private bool isFalling = true;
//     private bool isJumping = false;
//     private bool isGrounded = false;
//     private float currJump = 0f;
//     private float maxJump = 60f;
//     [SerializeField]
//     private float gravity = 20.0f;

//     private void Start()
//     {
//         rb = GetComponent<Rigidbody2D>();
//         charCtrl = GetComponent<CharacterController>();
//     }

//     void Update()
//     {
//         if (Input.GetKey("right"))
//         {
//             if (lastDir == false)
//             {
//                 Vector3 currentRot = transform.rotation.eulerAngles;
//                 float rotY = currentRot.y + 180;
//                 Vector3 newRot = new Vector3(currentRot.x, rotY, currentRot.z);
//                 transform.rotation = Quaternion.Euler(newRot);
//             }
//             charCtrl.Move(Vector2.right);
//             return;
//         }
//         if (Input.GetKey("left"))
//         {
//             if (lastDir == true)
//             {
//                 Vector3 currentRot = transform.rotation.eulerAngles;
//                 float rotY = currentRot.y + 180;
//                 Vector3 newRot = new Vector3(currentRot.x, rotY, currentRot.z);
//                 transform.rotation = Quaternion.Euler(newRot);
//             }
//             charCtrl.Move(-Vector2.right);
//             return;
//         }
//         lastKeyPressed = null;

//         //JUMP
//         if (Input.GetKeyDown(KeyCode.Space) && isJumping == false && isFalling == false)
//         {
//             isJumping = true;
//             Jump();
//         }

//         if (isJumping == true && isFalling == false)
//         {
//             Jump();
//         }

//         if (isFalling == true && isJumping == false)
//         {
//             Fall();
//         }
//     }


//     public void Jump()
//     {

//         if (currJump < maxJump)
//         {
//             float temp = 0.0f;
//             temp = Mathf.Sin(Time.deltaTime) * jumpSpeed;
//             currJump += temp;
//             charCtrl.Move(Vector2.up * temp * Time.deltaTime * jumpSpeed);
//         }
//         else
//         {
//             isJumping = false;
//             isFalling = true;
//         }
//     }

//     public void Fall()
//     {
//         if (isGrounded == false)
//         {
//             float temp = 0.0f;
//             temp = Mathf.Sin(Time.deltaTime) * jumpSpeed;
//             currJump -= temp;
//             charCtrl.Move(Vector2.up * temp * Time.deltaTime * jumpSpeed * -1);
//         }
//         else
//         {
//             isFalling = false;
//             currJump = 0;
//         }
//     }
//     void GetCurrentSpeed(bool isSameKey)
//     {
//         if (isSameKey)
//         {
//             currentSpeed += acceleration * Time.deltaTime;
//         }
//         else
//         {
//             currentSpeed = acceleration * Time.deltaTime;
//         }
//         if (currentSpeed > maxSpeed)
//         {
//             currentSpeed = maxSpeed;
//         }
//     }
// }