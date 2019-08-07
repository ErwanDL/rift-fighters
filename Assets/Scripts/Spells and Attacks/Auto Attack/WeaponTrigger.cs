using UnityEngine;
using UnityEngine.Events;

public class WeaponTrigger : MonoBehaviour
{
    [System.Serializable]
    private class MyEvent : UnityEvent<Collider2D> { }

    [SerializeField]
    private MyEvent triggerEvent = null;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 8 || other.gameObject.layer == 9)
            triggerEvent.Invoke(other);
    }
}
