using UnityEngine;
using UnityEngine.UI;

public class DisplayName : MonoBehaviour
{

    [SerializeField, Tooltip("Drag & Drop a Champion")]
    private GameObject character = null;

    string champion = null;
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        champion = character.name;
    }

    // Update is called once per frame
    void Update()
    {
        if (champion != null)
        {
            // Debug.Log(character.GetComponent<Player>().currentHealth);
            text.text = " " + champion;
        }
    }

}
