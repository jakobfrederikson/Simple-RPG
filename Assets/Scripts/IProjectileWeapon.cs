using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IProjectileWeapon
{
    public Transform ProjectileSpawn { get; set; }
    void CastProjectile();
}
