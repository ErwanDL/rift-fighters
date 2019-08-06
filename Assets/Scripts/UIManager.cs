using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    [SerializeField, Tooltip("Drag&Drop the left Champion")]
    private GameObject character = null;

    string champion = null;
    private int health = 0;
    public Text healthText;
    // Start is called before the first frame update
    void Start()
    {
        champion = character.name;
    }

    // Update is called once per frame
    void Update()
    {
        health = character.GetComponent<Dummy>().currentHealth;
        // Debug.Log(character.GetComponent<Dummy>().currentHealth);
        healthText.text = " " + champion + " : " + health + " ";
    }
}
