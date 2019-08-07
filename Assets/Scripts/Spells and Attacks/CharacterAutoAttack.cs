using UnityEngine;

public class CharacterAutoAttack : MonoBehaviour
{
    [SerializeField]
    private Collider2D weaponHolderCollider = null;
    private CharacterAnimation charAnim;

    void Start()
    {
        charAnim = GetComponentInParent<CharacterAnimation>();
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
        if (!charAnim.animator.GetBool("isJumping") && !charAnim.animator.GetBool("isFalling"))
            charAnim.animator.SetTrigger("autoAttack");
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
