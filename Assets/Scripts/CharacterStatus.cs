using UnityEngine;

public class CharacterStatus : MonoBehaviour
{
    [HideInInspector]
    public bool canRun;

    [HideInInspector]
    public bool canJump;

    [HideInInspector]
    public bool canCrouch;

    [HideInInspector]
    public bool canAutoAttack;

    [HideInInspector]
    public bool canUseQ;

    [HideInInspector]
    public bool canUseE;

    private void Awake()
    {
        canRun = true;
        canJump = true;
        canCrouch = true;
        canAutoAttack = true;
        canUseQ = true;
        canUseE = true;
    }
}