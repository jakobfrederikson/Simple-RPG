using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Staff : MonoBehaviour, IWeapon, IProjectileWeapon
{
    private Animator _animator;
    public List<BaseStat> Stats { get; set; }

    public Transform ProjectileSpawn { get; set; }
    private Fireball _fireball;

    private void Start()
    {
        _fireball = Resources.Load<Fireball>("Weapons/Projectiles/fireball");
        _animator = GetComponent<Animator>();
    }

    public void PerformAttack()
    {
        _animator.SetTrigger("Base_Attack");
        Debug.Log(this.name + " attack!");
    }

    public void PerformSpecialAttack()
    {
        _animator.SetTrigger("Special_Attack");
    }

    public void CastProjectile()
    {
        Fireball fireballInstance = (Fireball)Instantiate(_fireball, ProjectileSpawn.position, ProjectileSpawn.rotation);
        fireballInstance.Direction = ProjectileSpawn.forward;
    }
}
