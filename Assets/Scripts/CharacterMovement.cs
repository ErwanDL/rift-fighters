using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

    [SerializeField]
    private float acceleration = 15f;
    [SerializeField]
    private float maxSpeed = 30.0f;

    private float currentSpeed = 0.0f;

    private string lastKeyPressed = null;

    [SerializeField]
    private Rigidbody2D rb;

    private bool lastDir = true;    //true si droite, false si gauche

    private float fallMultiplier = 5.5f;
    private float lowMultiplier = 5.0f;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private float jumpVelocity = 50f;
    void Update()
    {
        if (Input.GetKey("right"))
        {
            if (lastDir == false)
            {
                Vector3 currentRot = transform.rotation.eulerAngles;
                float rotY = currentRot.y + 180;
                Vector3 newRot = new Vector3(currentRot.x, rotY, currentRot.z);
                transform.rotation = Quaternion.Euler(newRot);
            }
            GetCurrentSpeed(lastKeyPressed == "right");
            Vector3 currentPos = transform.position;
            float newX = currentPos.x + currentSpeed * Time.deltaTime;
            transform.position = new Vector3(newX, currentPos.y, currentPos.z);
            lastKeyPressed = "right";
            lastDir = true;
            return;
        }
        if (Input.GetKey("left"))
        {
            if (lastDir == true)
            {
                Vector3 currentRot = transform.rotation.eulerAngles;
                float rotY = currentRot.y + 180;
                Vector3 newRot = new Vector3(currentRot.x, rotY, currentRot.z);
                transform.rotation = Quaternion.Euler(newRot);
            }
            GetCurrentSpeed(lastKeyPressed == "left");
            Vector3 currentPos = transform.position;
            float newX = currentPos.x - currentSpeed * Time.deltaTime;
            transform.position = new Vector3(newX, currentPos.y, currentPos.z);
            lastKeyPressed = "left";
            lastDir = false;
            return;
        }
        lastKeyPressed = null;

        //JUMP
        if (Input.GetKeyDown("space"))
        {
            rb.velocity = Vector2.up * jumpVelocity;
        }

        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * fallMultiplier * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetKeyDown("space"))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * lowMultiplier * Time.deltaTime;
        }
    }
    void GetCurrentSpeed(bool isSameKey)
    {
        if (isSameKey)
        {
            currentSpeed += acceleration * Time.deltaTime;
        }
        else
        {
            currentSpeed = acceleration * Time.deltaTime;
        }
        if (currentSpeed > maxSpeed)
        {
            currentSpeed = maxSpeed;
        }
    }
}