using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats 
{
    public List<BaseStat> stats = new List<BaseStat>();

    public CharacterStats(int stamina, int strength, int agility, int intellect)
    {
        stats = new List<BaseStat>()
        {
            new BaseStat(BaseStat.BaseStatType.Stamina, stamina, "Stamina"),
            new BaseStat(BaseStat.BaseStatType.Strength, strength, "Strength"),
            new BaseStat(BaseStat.BaseStatType.Agility, agility, "Agility"),
            new BaseStat(BaseStat.BaseStatType.Intellect, intellect, "Intellect")
        };
    }

    public BaseStat GetStat(BaseStat.BaseStatType stat) => this.stats.Find(x => x.StatType == stat);

    public void AddStatBonus(List<BaseStat> statBonuses)
    {
        foreach (BaseStat statBonus in statBonuses)
        {
            GetStat(statBonus.StatType).AddStatBonus(new StatBonus(statBonus.BaseValue));
        }
    }

    public void RemoveStatBonus(List<BaseStat> statBonuses)
    {
        foreach (BaseStat statBonus in statBonuses)
        {
            GetStat(statBonus.StatType).RemoveStatBonus(new StatBonus(statBonus.BaseValue));
        }
    }
}
