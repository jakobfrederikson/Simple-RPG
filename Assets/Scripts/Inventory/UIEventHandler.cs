using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEventHandler : MonoBehaviour
{
    public delegate void ItemEventHandler(Item item);
    public static event ItemEventHandler OnItemAddedToInventory;
    public static event ItemEventHandler OnItemEquipped;

    public delegate void PlayerHealthEventHandler(int currentHealth, int maxHealth);
    public static event PlayerHealthEventHandler OnPlayerHealthChanged;

    public delegate void PlayerIntellectEventHandler(int currentIntellect, int maxIntellect);
    public static event PlayerIntellectEventHandler OnPlayerIntellectChanged;

    public delegate void StatsEventHandler();
    public static event StatsEventHandler OnStatsChanged;

    public delegate void PlayerLevelEventHandler();
    public static event PlayerLevelEventHandler OnPlayerLevelChange;

    public delegate void SelectedHealthEventHandler(int currentHealth, int maxHealth);
    public static event SelectedHealthEventHandler OnSelectedHealthChanged;

    public delegate void SelectedIntellectEventHandler(int currentIntellect, int maxIntellect);
    public static event SelectedIntellectEventHandler OnSelectedIntellectChanged;

    public static void ItemAddedToInventory(Item item)
    {        
        if (OnItemAddedToInventory != null)
            OnItemAddedToInventory(item);  
    }

    public static void ItemEquipped(Item item)
    {
        if (OnItemEquipped != null)
            OnItemEquipped(item);
    }

    public static void HealthChanged(int currentHealth, int maxHealth)
    {
        if (OnPlayerHealthChanged != null)
            OnPlayerHealthChanged(currentHealth, maxHealth);
    }

    public static void SelectedHealthChanged(int currentHealth, int maxHealth)
    {
        if (OnSelectedHealthChanged != null)
            OnSelectedHealthChanged(currentHealth, maxHealth);
    }

    public static void IntellectChanged(int currentIntellect, int maxIntellect)
    {
        if (OnPlayerIntellectChanged != null)
            OnPlayerIntellectChanged(currentIntellect, maxIntellect);
    }

    public static void SelectedIntellectChanged(int currentIntellect, int maxIntellect)
    {
        if (OnSelectedIntellectChanged != null)
            OnSelectedIntellectChanged(currentIntellect, maxIntellect);
    }

    public static void StatsChanged()
    {
        if (OnStatsChanged != null)
            OnStatsChanged();
    }

    public static void PlayerLevelChanged()
    {
        if (OnPlayerLevelChange != null)
            OnPlayerLevelChange();
    }
}
