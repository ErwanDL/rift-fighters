using UnityEngine;

public class Player : MonoBehaviour, IEnnemy
{
    private int _currentHealth;
    public int currentHealth
    {
        get { return _currentHealth; }
        set { _currentHealth = Mathf.Clamp(value, 0, maxHealth); }
    }
    [SerializeField, Tooltip("Player's Max Health")]
    public int maxHealth = 100;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            TakeDamage(10);
        }
    }
    public void PerformAttack()
    {
        return;
    }
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            GameMaster.KillPlayer(this);
        }
    }
}
