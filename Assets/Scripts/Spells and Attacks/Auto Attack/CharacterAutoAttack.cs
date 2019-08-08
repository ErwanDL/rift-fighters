using UnityEngine;

public class CharacterAutoAttack : MonoBehaviour
{
    private CharacterAnimation charAnim;
    public BoxCollider2D weaponCollider;
    public bool canAutoAttack = true;

    [SerializeField]
    private int attackDamage = 10;

    void Start()
    {
        charAnim = GetComponent<CharacterAnimation>();
        weaponCollider.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown("q") && canAutoAttack)
        {
            charAnim.animator.SetTrigger("autoAttack");
        }
    }

    public void OnHitEnemy(Collider2D other)
    {
        Player hitPlayer = other.GetComponent<Player>();
        if (hitPlayer != null)
            hitPlayer.TakeDamage(attackDamage);

    }
}
