using UnityEngine;

public class ProjectileSpell : Spell
{
    [SerializeField]
    protected float range = 10f;

    [SerializeField]
    protected float projectileSpeed = 10f;

    [SerializeField]
    protected int attackDamage = 10;

    [SerializeField]
    protected GameObject projectile = null;



}