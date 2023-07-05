using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Slime : Interactable, IEnemy
{
    public LayerMask aggroLayerMask;
    public float currentHealth;
    public float maxHealth;

    private Player player;
    private NavMeshAgent navAgent;
    private CharacterStats characterStats;
    private Collider[] withinAggroColliders;

    private void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
        characterStats = new CharacterStats(6, 10, 2);
        currentHealth = maxHealth;
    }

    private void FixedUpdate()
    {
        withinAggroColliders = Physics.OverlapSphere(transform.position, 10f, aggroLayerMask);
        if (withinAggroColliders.Length > 0)
        {
            ChasePlayer(withinAggroColliders[0].GetComponent<Player>());
        }
    }

    public void PerformAttack()
    {
        player.TakeDamage(5);
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
            Die();
    }

    private void ChasePlayer(Player player)
    {
        navAgent.SetDestination(player.transform.position);
        this.player = player;        
        if (navAgent.remainingDistance <= navAgent.stoppingDistance)
        {
            if (!IsInvoking("PerformAttack"))
            {
                InvokeRepeating("PerformAttack", .5f, 2f);
            }                
        }
        else
        {
            CancelInvoke("PerformAttack");
        }        
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
