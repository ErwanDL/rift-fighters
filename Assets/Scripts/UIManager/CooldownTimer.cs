using UnityEngine;
using UnityEngine.UI;

public class CooldownTimer : MonoBehaviour
{
    private Image content;

    [SerializeField]
    private Spell spell = null;

    private void Start()
    {
        content = GetComponent<Image>();
    }

    private void Update()
    {
        content.fillAmount = 1 - (spell.cooldownTimer / spell.baseCooldown);
    }
}
