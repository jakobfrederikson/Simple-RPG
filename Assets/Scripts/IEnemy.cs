using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemy 
{
    Spawner Spawner { get; set; }
    public int Experience { get; set; }
    public int ID { get; set; }
    void Die();
    void TakeDamage(int amount);
    void PerformAttack();
}
