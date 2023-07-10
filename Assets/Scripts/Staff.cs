using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Staff : MonoBehaviour, IWeapon, IProjectileWeapon
{
    public List<BaseStat> Stats { get; set; }
    public Transform ProjectileSpawn { get; set; }
    public int CurrentDamage { get; set; }

    private Animator animator;
    private Fireball fireball;
    private BaseStat.BaseStatType WeaponStatType = BaseStat.BaseStatType.Intellect;
    private Player player;

    private void Start()
    {
        fireball = Resources.Load<Fireball>("Weapons/Projectiles/fireball");
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
        fireballInstance.parentWeapon = this;
        fireballInstance.ApplyPlayerStatsToDamage(player.characterStats.GetStat(WeaponStatType).GetCalculatedStatValue());
        fireballInstance.Direction = ProjectileSpawn.forward;
    }
}
