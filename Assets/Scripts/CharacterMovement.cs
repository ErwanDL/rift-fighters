using UnityEngine;

public class CharacterMovement : MonoBehaviour {

    [SerializeField]
    private float movementSpeed = 10f;

    void Update () {
        Vector3 eulerRotation = transform.rotation.eulerAngles;
        transform.rotation = Quaternion.Euler (eulerRotation.x, eulerRotation.y, 0);
        if (Input.GetKey ("right")) {
            Vector3 currentPos = transform.position;
            float newX = currentPos.x + movementSpeed * Time.deltaTime;
            transform.position = new Vector3 (newX, currentPos.y, currentPos.z);
        }
    }
}