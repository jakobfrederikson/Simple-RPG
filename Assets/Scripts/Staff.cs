using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Staff : MonoBehaviour, IWeapon, IProjectileWeapon
{
    public List<BaseStat> Stats { get; set; }
    public Transform ProjectileSpawn { get; set; }
    public int CurrentDamage { get; set; }
    public BaseStat.BaseStatType WeaponStatType { get; set; } = BaseStat.BaseStatType.Intellect;

    private Animator animator;
    private Fireball fireball;

    private void Start()
    {
        fireball = Resources.Load<Fireball>("Weapons/Projectiles/fireball");
        animator = GetComponent<Animator>();
    }

    public void PerformAttack(int damage)
    {
        CurrentDamage = damage;
        animator.SetTrigger("Base_Attack");
    }

    public void PerformSpecialAttack()
    {
        animator.SetTrigger("Special_Attack");
    }

    public void CastProjectile()
    {
        Fireball fireballInstance = (Fireball)Instantiate(fireball, ProjectileSpawn.position, ProjectileSpawn.rotation);
        fireballInstance.ApplyPlayerStatsToDamage(CurrentDamage);
        fireballInstance.Direction = ProjectileSpawn.forward;
    }

    public void CastSpecialProjectile()
    {

    }
}
