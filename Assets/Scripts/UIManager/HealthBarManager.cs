using UnityEngine;
using UnityEngine.UI;

public class HealthBarManager : MonoBehaviour
{
    [SerializeField, Tooltip("Drag & Drop a Champion")]
    private GameObject character = null;
    [SerializeField, Tooltip("")]
    private float fillAmount;
    [SerializeField, Tooltip("")]
    private Image content = null;
    private int health = 0;
    private int maxHealth = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (character != null)
        {
            health = character.GetComponent<Player>().currentHealth;
            maxHealth = character.GetComponent<Player>().maxHealth;
            fillAmount = (float)health / (float)maxHealth;
            HandleBar();
        }
    }

    private void HandleBar()
    {
        content.fillAmount = fillAmount;
    }
}
