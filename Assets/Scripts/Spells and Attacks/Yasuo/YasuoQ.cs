using UnityEngine;

[RequireComponent(typeof(YasuoTornado))]
public class YasuoQ : MeleeAttack
{
    [Header("Basic Q particles parameters")]
    [SerializeField]
    private GameObject basicQParticles = null;

    [SerializeField]
    private Vector3 positionOffset = default;

    [SerializeField]
    private int consecutiveHits = 0;
    private YasuoTornado tornado = null;

    override protected void Start()
    {
        base.Start();
        tornado = GetComponent<YasuoTornado>();
    }

    override protected void Update()
    {
        base.Update();
        if (spellState == SpellState.Ready)
        {
            if (Input.GetKeyDown("a") && status.canUseQ)
            {
                if (consecutiveHits == 2)
                {
                    Vector2 facingDirection = transform.rotation.eulerAngles.y < 180 ? Vector2.right : Vector2.left;
                    anim.animator.SetTrigger("throwTornado");
                    tornado.CastSpell();
                    consecutiveHits = 0;
                    GoInCooldown();
                }
                else
                {
                    anim.animator.SetTrigger("basicQ");
                    Invoke("InstantiateBasicQParticles", incantationDelay);
                    CastSpell();
                }
            }
        }
    }

    override public void OnHitEnemy(CharacterManager hitEnemy)
    {
        base.OnHitEnemy(hitEnemy);
        consecutiveHits += 1;
    }

    void InstantiateBasicQParticles()
    {
        GameObject ins = Instantiate(basicQParticles, Utils.GetInstantiationPosition(transform, positionOffset),
            Utils.GetInstantiationRotation(transform, new Vector3(-90, 0, 0)));
        Destroy(ins, 1.5f);
    }

}

