using UnityEngine;

public class YasuoQ : MeleeAttack
{
    [Header("Basic Q particles parameters")]
    [SerializeField]
    private GameObject basicQParticles = null;

    [SerializeField]
    private Vector3 positionOffset = default;

    [SerializeField]
    private float instantiationDelay = 0f;
    private int consecutiveHits = 0;


    override protected void Update()
    {
        base.Update();
        if (spellState == SpellState.Ready)
        {
            if (Input.GetKeyDown("a") && status.canUseQ)
            {
                anim.animator.SetTrigger("basicQ");
                Invoke("InstantiateBasicQParticles", instantiationDelay);
                LaunchAttack();
            }
        }
    }

    override protected void OnHitEnemy(CharacterManager hitEnemy)
    {
        base.OnHitEnemy(hitEnemy);
        consecutiveHits += 1;
    }

    void InstantiateBasicQParticles()
    {
        Vector3 startPos = transform.rotation.eulerAngles.y == 90 ? positionOffset : new Vector3(-positionOffset.x, positionOffset.y, -positionOffset.z);
        Vector3 startRot = transform.rotation.eulerAngles.y == 90 ? new Vector3(-90, 0, 0) : new Vector3(-90, 180, 0);
        GameObject ins = Instantiate(basicQParticles, transform.position + startPos, Quaternion.Euler(startRot));
        Destroy(ins, 1.5f);
    }

}

