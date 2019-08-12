using UnityEngine;
using UnityEngine.UI;

public class HealthBarManager : MonoBehaviour
{

    [SerializeField, Tooltip("Image ")]
    private Image content = null;

    public void ChangeHealth(float newFillAmount)
    {
        content.fillAmount = newFillAmount;
    }
}
