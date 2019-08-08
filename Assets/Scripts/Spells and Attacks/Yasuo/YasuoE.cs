using UnityEngine;

public class YasuoE : MonoBehaviour
{
    private CharacterRun charRun;
    private Rigidbody2D rb;
    public DashState dashState;
    private float dashTimer;
    [SerializeField, Tooltip("Duration of the dash")]
    private float dashTime = 0f;
    [SerializeField, Tooltip("Cooldown of the dash")]
    public float dashCooldown = 20f;


    public Vector2 savedVelocity;
    private float lastDirection = 0f;
    [SerializeField, Tooltip("Force of the dash")]
    private float dashForce = 150f;
    private float savedGravityScale = 0f;

    private void Start()
    {
        charRun = GetComponent<CharacterRun>();
        rb = GetComponent<Rigidbody2D>();
        savedGravityScale = rb.gravityScale;
    }
    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") != 0)
            lastDirection = Input.GetAxisRaw("Horizontal");
        switch (dashState)
        {
            case DashState.Ready:
                bool isDashKeyDown = Input.GetKeyDown("e");

                if (isDashKeyDown)
                {
                    charRun.canRun = false;
                    rb.gravityScale = 0;
                    savedVelocity = rb.velocity;
                    rb.velocity = new Vector2(lastDirection * dashForce, 0);
                    dashState = DashState.Dashing;
                }
                break;
            case DashState.Dashing:
                dashTimer += Time.deltaTime;
                if (dashTimer >= dashTime)
                {
                    dashTimer = dashCooldown;
                    rb.velocity = savedVelocity;
                    dashState = DashState.Cooldown;
                    charRun.canRun = true;
                    rb.gravityScale = savedGravityScale;
                }
                break;
            case DashState.Cooldown:
                dashTimer -= Time.deltaTime;
                if (dashTimer <= 0)
                {
                    dashTimer = 0;
                    dashState = DashState.Ready;
                }
                break;
        }
    }
}

public enum DashState
{
    Ready,
    Dashing,
    Cooldown
}

