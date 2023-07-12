using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponController : MonoBehaviour
{
    [SerializeField] public GameObject playerHand;
    public GameObject EquippedWeapon { get; set; }

    private Transform spawnProjectile;
    private Item currentlyEquippedItem;
    private IWeapon equippedWeapon;
    private CharacterStats playerStats;
    private Player player;

    private void Start()
    {
        spawnProjectile = transform.Find("ProjectileSpawn");
        playerStats = GetComponent<Player>().characterStats;
        player = GetComponent<Player>();
    }

    public void EquipWeapon(Item itemToEquip)
    {
        if (EquippedWeapon != null)
        {
            UnequipWeapon();
        }

        EquippedWeapon = (GameObject)Instantiate(Resources.Load<GameObject>("Weapons/" + itemToEquip.ObjectSlug), 
            playerHand.transform.position, playerHand.transform.rotation);
        EquippedWeapon.transform.SetParent(playerHand.transform);
        if (EquippedWeapon.GetComponent<IProjectileWeapon>() != null)
            EquippedWeapon.GetComponent<IProjectileWeapon>().ProjectileSpawn = spawnProjectile;

        equippedWeapon = EquippedWeapon.GetComponent<IWeapon>();        
        equippedWeapon.Stats = itemToEquip.Stats;

        currentlyEquippedItem = itemToEquip;
        playerStats.AddStatBonus(itemToEquip.Stats);

        UIEventHandler.ItemEquipped(itemToEquip);        
        UIEventHandler.StatsChanged();
    }

    public void UnequipWeapon()
    {
        InventoryController.Instance.GiveItem(currentlyEquippedItem.ObjectSlug);
        UIEventHandler.ItemRemoved(currentlyEquippedItem);
        currentlyEquippedItem = null;
        playerStats.RemoveStatBonus(equippedWeapon.Stats);
        Destroy(EquippedWeapon.transform.gameObject);
        UIEventHandler.StatsChanged();
    }

    private void Update()
    {
        if (currentlyEquippedItem != null)
        {
            if (Input.GetKeyDown(KeyCode.X))
                PerformWeaponAttack();
            if (Input.GetKeyDown(KeyCode.Y))
                PerformWeaponSpecialAttack();
        }        
    }

    public void PerformWeaponAttack()
    {
        equippedWeapon.PerformAttack(CalculateDamage());
    }

    public void PerformWeaponSpecialAttack()
    {
        equippedWeapon.PerformSpecialAttack();
    }

    private int CalculateDamage()
    {
        // calculate damage based on the weapons primary stat
        int damageToDeal = (GetComponent<Player>().characterStats.GetStat(equippedWeapon.WeaponStatType).GetCalculatedStatValue())
            + Random.Range(2, 8);
        damageToDeal += CalculateCrit(damageToDeal);
        return damageToDeal;
    }

    private int CalculateCrit(int damage)
    {
        if (Random.value <= .10f)
        {
            int critDamage = (int)(damage * Random.Range(.5f, .75f));
            return critDamage;
        }
        return 0;
    }
}
