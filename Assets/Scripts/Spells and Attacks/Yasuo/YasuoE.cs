using UnityEngine;

public class YasuoE : Spell
{
    private CharacterRun charRun;
    private CharacterAnimation charAnim;
    private Rigidbody2D rb;
    public DashState dashState;
    private float dashTimer;
    [SerializeField, Tooltip("Duration of the dash")]
    private float dashDuration = 0.5f;
    [SerializeField, Tooltip("Cooldown of the dash")]

    private Vector2 direction = default;
    [SerializeField, Tooltip("Force of the dash")]
    private float dashForce = 150f;
    private float defaultGravity = 0f;

    public bool canDash;

    private void Start()
    {
        charRun = GetComponent<CharacterRun>();
        charAnim = GetComponent<CharacterAnimation>();
        rb = GetComponent<Rigidbody2D>();
        defaultGravity = rb.gravityScale;
        canDash = true;
    }
    void Update()
    {
        switch (dashState)
        {
            case DashState.Ready:
                if (Input.GetKeyDown("e") && canDash)
                {
                    if (Input.GetAxisRaw("Horizontal") != 0)
                        direction = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
                    else
                        direction = new Vector2(transform.rotation.eulerAngles.y < 180 ? 1 : -1, 0);
                    direction.y = Mathf.Clamp(Input.GetAxisRaw("Vertical"), 0, 1) * 0.66f;
                    direction.Normalize();
                    charRun.canRun = false;
                    rb.gravityScale = 0;
                    rb.velocity = direction * dashForce;
                    dashState = DashState.Dashing;
                    charAnim.setParameterToTrueAndOthersToFalse("isDashing");
                }
                break;
            case DashState.Dashing:
                rb.velocity = direction * dashForce * (1 - dashTimer / (2 * dashDuration));
                dashTimer += Time.deltaTime;
                if (dashTimer >= dashDuration)
                {
                    dashTimer = 0;
                    cooldownTimer = baseCooldown;
                    rb.velocity = new Vector2(0, 0);
                    dashState = DashState.InCooldown;
                    charRun.canRun = true;
                    rb.gravityScale = defaultGravity;
                }
                break;
            case DashState.InCooldown:
                cooldownTimer -= Time.deltaTime;
                if (cooldownTimer <= 0)
                {
                    cooldownTimer = 0;
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
    InCooldown
}

