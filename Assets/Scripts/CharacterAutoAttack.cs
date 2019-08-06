using UnityEngine;

public class CharacterAutoAttack : MonoBehaviour
{
    [SerializeField, Tooltip("Drag&Drop the weapon holder so he can't hit himself")]
    private Collider2D weaponHolderCollider = null;

    [SerializeField, Tooltip("Drag&Drop the GameObject handling the animation")]
    private CharacterAnimation characterAnimation = null;

    void Start()
    {
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), weaponHolderCollider);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("q"))
        {
            UseAutoAttack();
        }
    }

    void UseAutoAttack()
    {
        if (!characterAnimation.anim.GetBool("isJumping") && !characterAnimation.anim.GetBool("isFalling"))
            characterAnimation.anim.SetTrigger("autoAttack");
    }

    void onTriggerEnter(Collider2D col)
    {
        if (col.tag == "Ennemy")
        {
            Debug.Log("Touched");
            col.GetComponent<IEnnemy>().TakeDamage(20);
        }
    }
}
