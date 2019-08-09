using UnityEngine;
using UnityEngine.UI;

public class CooldownTimer : MonoBehaviour
{
    [SerializeField, Tooltip("Icone")]
    private Image content = null;

    [SerializeField]
    private Spell spell = null;

    private void Update()
    {
        content.fillAmount = 1 - (spell.cooldownTimer / spell.baseCooldown);
    }
}
