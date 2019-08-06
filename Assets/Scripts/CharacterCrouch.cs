﻿using UnityEngine;

public class CharacterCrouch : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private CharacterMovement charMovement;
    [SerializeField]
    private float crouchDiffHeight;

    private BoxCollider2D hitbox;
    private Vector2 standingHitboxSize;
    private Vector2 standingHitboxOffset;
    private Vector2 crouchingHitboxSize;
    private Vector2 crouchingHitboxOffset;

    void Start()
    {
        charMovement = GetComponent<CharacterMovement>();
        hitbox = GetComponent<BoxCollider2D>();
        standingHitboxSize = hitbox.size;
        standingHitboxOffset = hitbox.offset;
        crouchingHitboxSize = new Vector2(4.2f, 6.5f);
        crouchingHitboxOffset = new Vector2(0.5f, 3.2f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("down") && (charMovement.status == Status.idle || charMovement.status == Status.running))
        {
            crouchOn();
            charMovement.status = Status.crouching;
        }
        else if (!Input.GetKey("down") && charMovement.status == Status.crouching)
        {
            crouchOff();
            charMovement.status = Status.idle;
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
