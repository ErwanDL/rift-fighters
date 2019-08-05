using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAutoAttack : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField, Tooltip("Drag&Drop the weapon holder so he can't hit himself")]
    private Collider2D weaponHolderCollider = null;
    void Start()
    {
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), weaponHolderCollider);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("q"))
        {

            performAttack();
        }
    }
    void performAttack()
    {
        //animation
        return;
    }

    void onTriggerEnter(Collider2D col)
    {
        if (col.tag == "Ennemy")
        {
            col.GetComponent<IEnnemy>().TakeDamage(20);
        }
    }
}
