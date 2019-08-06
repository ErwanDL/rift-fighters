using UnityEngine;

public class CharacterCrouch : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private CharacterAnimation characterAnimation = null;
    [SerializeField]
    private float crouchDiffHeight;

    public bool canCrouch = true;

    private BoxCollider2D hitbox;
    private Vector2 standingHitboxSize;
    private Vector2 standingHitboxOffset;
    private Vector2 crouchingHitboxSize;
    private Vector2 crouchingHitboxOffset;

    void Start()
    {
        hitbox = GetComponent<BoxCollider2D>();
        standingHitboxSize = hitbox.size;
        standingHitboxOffset = hitbox.offset;
        crouchingHitboxSize = new Vector2(4.2f, 6.5f);
        crouchingHitboxOffset = new Vector2(0.5f, 3.2f);
    }

    // Update is called once per frame
    void Update()
    {
        if (canCrouch && Input.GetKey("down") && (characterAnimation.anim.GetBool("isIdle") || characterAnimation.anim.GetBool("isRunning")))
        {
            crouchOn();
            characterAnimation.setParameterToTrueAndOthersToFalse("isCrouching");
        }
        else if (!Input.GetKey("down") && characterAnimation.anim.GetBool("isCrouching"))
        {
            crouchOff();
            characterAnimation.setParameterToTrueAndOthersToFalse("isIdle");
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
