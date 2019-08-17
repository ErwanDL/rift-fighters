using UnityEngine;

[RequireComponent(typeof(YasuoTornado))]
public class YasuoQ : MeleeAttack
{
    [Header("Basic Q particles")]
    [SerializeField]
    private GameObject basicQParticles = null;

    [SerializeField]
    private Vector3 positionOffset = default;

    [Header("Beyblade Q")]
    [SerializeField]
    private Collider2D beybladeCollider = null;
    private Collider2D defaultCollider = null;

    [SerializeField]
    private int consecutiveHits = 0;
    private YasuoTornado tornado = null;
    private YasuoE dash = null;

    override protected void Start()
    {
        base.Start();
        tornado = GetComponent<YasuoTornado>();
        dash = GetComponent<YasuoE>();
        defaultCollider = associatedCollider;
    }

    override protected void Update()
    {
        base.Update();
        if (spellState == SpellState.Ready)
        {
            if (Input.GetKeyDown("a") && status.canUseQ)
            {
                if (dash.spellState == SpellState.InCast)
                {
                    anim.animator.SetTrigger("beyblade");
                    dash.beyblade = true;
                    return;
                }
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

    public void CastBeyblade()
    {
        Debug.Log("beyblade cast");
    }

    override public void OnHitEnemy(CharacterManager hitEnemy)
    {
        base.OnHitEnemy(hitEnemy);
        consecutiveHits += 1;
    }

    void InstantiateBasicQParticles()
    {
        GameObject ins = Instantiate(basicQParticles, Utils.GetInstantiationPosition(transform, positionOffset),
            Utils.GetInstantiationRotation(transform, Vector3.zero));
        Destroy(ins, 1.5f);
    }

}

