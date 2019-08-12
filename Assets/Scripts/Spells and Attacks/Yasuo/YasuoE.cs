using UnityEngine;

public class YasuoE : Spell
{
    private Rigidbody2D rb;
    private float dashTimer;
    [SerializeField, Tooltip("Duration of the dash")]
    private float dashDuration = 0.5f;
    [SerializeField, Tooltip("Cooldown of the dash")]

    private Vector2 direction = default;
    [SerializeField, Tooltip("Force of the dash")]
    private float dashForce = 150f;
    private float defaultGravity = 0f;


    override protected void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody2D>();
        defaultGravity = rb.gravityScale;
    }
    void Update()
    {
        switch (spellState)
        {
            case SpellState.Ready:
                if (Input.GetKeyDown("e") && status.canUseE)
                {
                    if (Input.GetAxisRaw("Horizontal") != 0)
                        direction = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
                    else
                        direction = new Vector2(transform.rotation.eulerAngles.y < 180 ? 1 : -1, 0);
                    direction.y = Mathf.Clamp(Input.GetAxisRaw("Vertical"), 0, 1) * 0.66f;
                    direction.Normalize();
                    status.canRun = false;
                    rb.gravityScale = 0;
                    rb.velocity = direction * dashForce;
                    spellState = SpellState.InCast;
                    anim.setParameterToTrueAndOthersToFalse("isDashing");
                }
                break;
            case SpellState.InCast:
                rb.velocity = direction * dashForce * (1 - dashTimer / (2 * dashDuration));
                dashTimer += Time.deltaTime;
                if (dashTimer >= dashDuration)
                {
                    dashTimer = 0;
                    cooldownTimer = baseCooldown;
                    rb.velocity = new Vector2(0, 0);
                    spellState = SpellState.InCooldown;
                    status.canRun = true;
                    rb.gravityScale = defaultGravity;
                }
                break;
            case SpellState.InCooldown:
                cooldownTimer -= Time.deltaTime;
                if (cooldownTimer <= 0)
                {
                    cooldownTimer = 0;
                    spellState = SpellState.Ready;
                }
                break;
        }
    }
}

