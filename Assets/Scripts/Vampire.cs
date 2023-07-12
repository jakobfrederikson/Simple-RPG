using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Vampire : Interactable, IEnemy, INameplate
{
    public LayerMask aggroLayerMask;

    public string Name { get; set; } = "Vampire";
    public string IconSlug { get; set; } = "vampire";
    public int MaxHealth { get; set; }
    public int CurrentHealth { get; set; }
    public int MaxIntellect { get; set; }
    public int CurrentIntellect { get; set; }
    public Image Icon { get; set; }
    public bool IsSelected { get; set; } = false;

    public int maxHealth;
    public int maxIntellect;
    public int ID { get; set; }
    public int Experience { get; set; }
    public DropTable DropTable { get; set; }
    public Spawner Spawner { get; set; }
    public PickupItem pickupItem;

    private Player player;
    private NavMeshAgent navAgent;
    private CharacterStats characterStats;
    private Collider[] withinAggroColliders;

    private void Start()
    {
        DropTable = new DropTable();
        DropTable.loot = new List<LootDrop>()
        {
            new LootDrop("sword", 50),
            new LootDrop("staff", 50),
            new LootDrop("potion_log", 10)
        };
        ID = 1;
        Experience = 300;
        navAgent = GetComponent<NavMeshAgent>();
        characterStats = new CharacterStats(8, 10, 2, 10);

        MaxHealth = maxHealth;
        CurrentHealth = MaxHealth;
        MaxIntellect = maxIntellect;
        CurrentIntellect = MaxIntellect;
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
        CurrentHealth -= amount;
        DamagePopupSystem.Instance.DisplayPopupText(this.transform, amount);

        if (IsSelected)
            UIEventHandler.SelectedHealthChanged(CurrentHealth, MaxHealth);
        if (CurrentHealth <= 0)
            Die();
    }

    public void DamagePopup(int amount)
    {
        throw new System.NotImplementedException();
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

    public void Die()
    {
        DropLoot();
        CombatEvents.EnemyDied(this);
        this.Spawner.Respawn();
        if (IsSelected)
            UIEventHandler.SelectedHealthChanged(CurrentHealth, MaxHealth);
        Destroy(gameObject);
    }

    private void DropLoot()
    {
        Item item = DropTable.GetDrop();
        if (item != null)
        {
            PickupItem instance = Instantiate(pickupItem, transform.position, Quaternion.identity);
            instance.ItemDrop = item;
        }
    }
}
