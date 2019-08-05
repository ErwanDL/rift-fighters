using UnityEngine;

public class Dummy : MonoBehaviour, IEnnemy
{
    public float currentHealth = 100f;
    [SerializeField, Tooltip("Dummy's Max Health")]
    private float maxHealth = 100f;

    void Start()
    {
        currentHealth = maxHealth;
    }
    public void PerformAttack()
    {
        throw new System.NotImplementedException();
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
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
