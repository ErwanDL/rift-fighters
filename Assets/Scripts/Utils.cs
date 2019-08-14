using UnityEngine;

public class Utils
{
    public static Vector3 GetInstantiationPosition(Transform transform, Vector3 posOffset)
    {
        Vector3 startPos = transform.rotation.eulerAngles.y < 180 ? posOffset : new Vector3(-posOffset.x, posOffset.y, -posOffset.z);
        return transform.position + startPos;
    }

    public static Quaternion GetInstantiationRotation(Transform transform, Vector3 rotOffset)
    {
        rotOffset.y += transform.rotation.eulerAngles.y < 180 ? 0 : 180;
        return Quaternion.Euler(rotOffset);
    }
}