using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CharacterStats characterStats;
    public int currentHealth;
    public int maxHealth;
    public int currentIntellect;
    public int maxIntellect;
    public PlayerLevel PlayerLevel { get; set; }

    private int baseMaxHealth;
    private int baseCurrentHealth;
    private int baseMaxIntellect;
    private int baseCurrentIntellect;

    private void Start()
    {
        PlayerLevel = GetComponent<PlayerLevel>();
        characterStats = new CharacterStats(10, 10, 10, 10);
        this.maxHealth += characterStats.GetStat(BaseStat.BaseStatType.Stamina).GetCalculatedStatValue();
        this.maxIntellect += characterStats.GetStat(BaseStat.BaseStatType.Intellect).GetCalculatedStatValue();
        this.currentHealth = this.maxHealth;
        this.currentIntellect = this.maxIntellect;

        baseMaxHealth = this.maxHealth;
        baseCurrentHealth = this.currentHealth;
        baseMaxIntellect = this.maxIntellect;
        baseCurrentIntellect = this.currentIntellect;

        UIEventHandler.OnItemEquipped += ItemEquipped;
        UIEventHandler.OnItemRemoved += ItemRemoved;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0) 
        {
            Die();
        }
        UIEventHandler.HealthChanged(this.currentHealth, this.maxHealth);
    }

    private void Die()
    {
        this.currentHealth = this.maxHealth;
        UIEventHandler.HealthChanged(this.currentHealth, this.maxHealth);
    }

    private void ItemEquipped (Item item)
    {
        maxHealth = (baseMaxHealth + characterStats.GetStat(BaseStat.BaseStatType.Stamina).GetCalculatedStatValue());
        currentHealth = (currentHealth + characterStats.GetStat(BaseStat.BaseStatType.Stamina).GetCalculatedStatValue());
        maxIntellect = (baseMaxIntellect + characterStats.GetStat(BaseStat.BaseStatType.Intellect).GetCalculatedStatValue());
        currentIntellect = (currentIntellect + characterStats.GetStat(BaseStat.BaseStatType.Intellect).GetCalculatedStatValue());
        StatsChanged();
    }

    public void ItemRemoved(Item item)
    {
        maxHealth -= characterStats.GetStat(BaseStat.BaseStatType.Stamina).GetCalculatedStatValue();
        currentHealth -= characterStats.GetStat(BaseStat.BaseStatType.Stamina).GetCalculatedStatValue();
        maxIntellect -= characterStats.GetStat(BaseStat.BaseStatType.Intellect).GetCalculatedStatValue();
        currentIntellect -= characterStats.GetStat(BaseStat.BaseStatType.Intellect).GetCalculatedStatValue();
        StatsChanged();
    }

    private void StatsChanged()
    {
        UIEventHandler.HealthChanged(currentHealth, maxHealth);
        UIEventHandler.IntellectChanged(currentIntellect, maxIntellect);
    }
}
