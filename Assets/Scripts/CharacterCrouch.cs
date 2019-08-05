using UnityEngine;

public class CharacterCrouch : MonoBehaviour
{
    // Start is called before the first frame update

    [HideInInspector]
    public bool crouch;
    private BoxCollider2D hitbox;
    [SerializeField]
    private float crouchDiffHeight;
    void Start()
    {
        crouch = false;
        hitbox = GetComponent<BoxCollider2D>();
        crouchDiffHeight = hitbox.size[1] / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("down"))
        {
            crouchOn();
            crouch = true;
        }
        else
        {
            crouchOff();
            crouch = false;
        }
    }
    void crouchOn()
    {
        hitbox.size = new Vector2(hitbox.size[0], crouchDiffHeight);
    }
    void crouchOff()
    {
        hitbox.size = new Vector2(hitbox.size[0], crouchDiffHeight * 2);
    }
}
