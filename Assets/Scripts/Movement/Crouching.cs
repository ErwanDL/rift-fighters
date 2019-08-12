using UnityEngine;

[RequireComponent(typeof(CharacterStatus))]
public class Crouching : MonoBehaviour
{
    // Start is called before the first frame update

    private CharacterAnimation anim;
    private CharacterStatus status;

    private bool isCrouched = false;

    [SerializeField]
    private BoxCollider2D hitbox = null;
    private Vector2 standingHitboxSize;
    private Vector2 standingHitboxOffset;
    private Vector2 crouchingHitboxSize;
    private Vector2 crouchingHitboxOffset;

    void Start()
    {
        anim = GetComponent<CharacterAnimation>();
        status = GetComponent<CharacterStatus>();
        standingHitboxOffset = hitbox.offset;
        standingHitboxSize = hitbox.size;
        crouchingHitboxOffset = new Vector2(-0.15f, 0.78f);
        crouchingHitboxSize = new Vector2(0.9f, 1.55f);
    }

    // Update is called once per frame
    void Update()
    {
        if (status.canCrouch && Input.GetKeyDown("down"))
        {
            crouchOn();
            anim.setParameterToTrueAndOthersToFalse("isCrouching");
        }
        else if (isCrouched && !(Input.GetKey("down") && status.canCrouch))
        {
            crouchOff();
            anim.setParameterToTrueAndOthersToFalse("isIdle");
        }
    }
    void crouchOn()
    {
        hitbox.size = crouchingHitboxSize;
        hitbox.offset = crouchingHitboxOffset;
        isCrouched = true;
        status.canRun = false;
    }
    void crouchOff()
    {
        hitbox.size = standingHitboxSize;
        hitbox.offset = standingHitboxOffset;
        isCrouched = false;
        status.canRun = true;
    }
}
