using UnityEngine;
using UnityEngine.Events;

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

    [System.Serializable]
    private class MyEvent : UnityEvent<float> { }

    [SerializeField]
    private MyEvent onHealthChange = null;

    void Start()
    {
        currentHealth = maxHealth;
    }
    public void PerformAttack()
    {
        return;
    }
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        onHealthChange.Invoke((float)currentHealth / (float)maxHealth);
        if (currentHealth == 0)
        {
            GameMaster.KillPlayer(this);
        }
    }
}
