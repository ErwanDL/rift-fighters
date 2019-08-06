using UnityEngine;

public class CharacterCrouch : MonoBehaviour
{
    // Start is called before the first frame update

    private CharacterAnimation charAnim;

    public bool canCrouch = true;

    [SerializeField]
    private BoxCollider2D hitbox = null;
    private Vector2 standingHitboxSize;
    private Vector2 standingHitboxOffset;
    private Vector2 crouchingHitboxSize;
    private Vector2 crouchingHitboxOffset;

    void Start()
    {
        charAnim = GetComponent<CharacterAnimation>();
        standingHitboxOffset = hitbox.offset;
        standingHitboxSize = hitbox.size;
        crouchingHitboxOffset = new Vector2(-0.15f, 0.78f);
        crouchingHitboxSize = new Vector2(0.9f, 1.55f);
    }

    // Update is called once per frame
    void Update()
    {
        if (canCrouch && Input.GetKey("down") && (charAnim.animator.GetBool("isIdle") || charAnim.animator.GetBool("isRunning")))
        {
            crouchOn();
            charAnim.setParameterToTrueAndOthersToFalse("isCrouching");
        }
        else if (!Input.GetKey("down") && charAnim.animator.GetBool("isCrouching"))
        {
            crouchOff();
            charAnim.setParameterToTrueAndOthersToFalse("isIdle");
        }
    }
    void crouchOn()
    {
        hitbox.size = crouchingHitboxSize;
        hitbox.offset = crouchingHitboxOffset;
    }
    void crouchOff()
    {
        hitbox.size = standingHitboxSize;
        hitbox.offset = standingHitboxOffset;
    }
}
