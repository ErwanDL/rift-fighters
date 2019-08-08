using UnityEngine;
using UnityEngine.UI;

public class CooldownTimer : MonoBehaviour
{
    private Text cooldownText;

    [SerializeField]
    private Spell spell = null;

    private void Start()
    {
        cooldownText = GetComponent<Text>();
    }

    private void Update()
    {
        cooldownText.text = "E Cooldown : " + Mathf.Ceil(spell.cooldownTimer);
    }
}
