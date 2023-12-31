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
    private LightningBall lightningBall;

    private Player player;

    private void Start()
    {
        fireball = Resources.Load<Fireball>("Weapons/Projectiles/fireball");
        lightningBall = Resources.Load<LightningBall>("Weapons/Projectiles/lightningball");
        animator = GetComponent<Animator>();
        player = FindObjectOfType<Player>();
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
        CurrentDamage = player.characterStats.GetStat(WeaponStatType).GetCalculatedStatValue() * 3;
        LightningBall lightningballInstance = (LightningBall)Instantiate(lightningBall, ProjectileSpawn.position, ProjectileSpawn.rotation);
        lightningballInstance.ApplyPlayerStatsToDamage(CurrentDamage);
        lightningballInstance.Direction = ProjectileSpawn.forward;
    }
}
