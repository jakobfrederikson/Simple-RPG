using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Interactable, IEnemy
{
    public float currentHealth, power, toughness;
    public float _maxHealth;

    private void Start()
    {
        currentHealth = _maxHealth;
    }

    public void PerformAttack()
    {
        throw new System.NotImplementedException();
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
            Die();
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
