using UnityEngine;

public class OnHitTrigger : MonoBehaviour
{
    [SerializeField]
    private MeleeAttack associatedAttack = null;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 8 || other.gameObject.layer == 9)
            associatedAttack.OnHitEnemy(other);
    }
}
