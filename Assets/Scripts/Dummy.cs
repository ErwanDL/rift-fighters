using UnityEngine;

public class Dummy : MonoBehaviour, IEnnemy
{
    public int currentHealth = 100;
    [SerializeField, Tooltip("Dummy's Max Health")]
    private int maxHealth = 100;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            //TakeDamage(10);
        }
    }
    public void PerformAttack()
    {
        return;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        Debug.Log(currentHealth);
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Destroy(gameObject);
    }
}
