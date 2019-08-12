using UnityEngine;

public class CharacterStatus : MonoBehaviour
{
    public bool canRun;
    public bool canJump;
    public bool canCrouch;
    public bool canAutoAttack;
    public bool canUseQ;
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