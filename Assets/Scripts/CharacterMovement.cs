using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class CharacterMovement : MonoBehaviour
{
    [SerializeField, Tooltip("Max speed that the character reach when running.")]
    private float speed = 30.0f;

    [SerializeField, Tooltip("Acceleration while grounded.")]
    private float walkAcceleration = 75.0f;

    [SerializeField, Tooltip("Acceleration while in the air")]
    private float airAcceleration;
    [SerializeField, Tooltip("Deceleration applied when character is grounded and not attempting to move.")]
    private float groundDeceleration = 70.0f;

    [SerializeField, Tooltip("Max height the character will jump regardless of gravity")]
    private float jumpHeight = 15.0f;

    private int numJumps;
    [SerializeField, Tooltip("The number of jumps the character can perform in a row")]
    private int maxJumps;

    [SerializeField, Tooltip("Apply more gravity")]
    private float addedGravity = 20f;
    private Vector2 velocity;
    [SerializeField]
    private Rigidbody2D rb;

    /// <summary>
    /// Set to true when the character intersects a collider beneath
    /// them in the previous frame.
    /// </summary>
    private bool grounded;

    private void Start()
    {
        grounded = true;
        numJumps = 0;
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
            Debug.Log(rb.velocity);
            Vector3 currentRot = transform.rotation.eulerAngles;
            float rotY = moveInput > 0 ? 0 : 180;
            Vector3 newRot = new Vector3(0, rotY, 0);
            transform.rotation = Quaternion.Euler(newRot);
        }
        else
        {
            rb.velocity = new Vector2(Mathf.MoveTowards(velocity.x, 0, deceleration * Time.deltaTime), rb.velocity.y);
        }

        if (Input.GetKeyDown(KeyCode.Space) && canJump())
        {
            rb.velocity = new Vector2(0, jumpHeight);
            ++numJumps;
        }
    }
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Ground"))
        {
            numJumps = 0;
        }
    }

    private bool canJump()
    {
        return numJumps < maxJumps;
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