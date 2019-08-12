using UnityEngine;

public class YasuoE : Spell
{
    [Header("Dash-specific parameters")]
    [SerializeField, Tooltip("Duration of the dash")]
    private float dashDuration = 0.5f;

    [SerializeField, Tooltip("Force of the dash")]
    private float dashForce = 150f;
    private Vector2 direction = default;
    private float defaultGravity = 0f;
    private Rigidbody2D rb;
    private float dashTimer;


    override protected void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody2D>();
        defaultGravity = rb.gravityScale;
    }
    override protected void Update()
    {
        base.Update();
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
                    GoInCooldown();
                    dashTimer = 0;
                    rb.velocity = new Vector2(0, 0);
                    status.canRun = true;
                    rb.gravityScale = defaultGravity;
                }
                break;
        }
    }
}

