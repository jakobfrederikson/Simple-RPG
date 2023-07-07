using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Quest : MonoBehaviour
{
    private int level;
    public int Level
    {
        get
        {
            return Level;
        }
        set
        {
            Level = value;
        }
    }
    public List<QuestGoal> QuestGoals { get; set; }
    public string QuestName { get; set; }
    public string Description { get; set; }
    public int ExperienceReward { get; set; }
    public Item ItemReward { get; set; }
    public bool Completed { get; set; }

    public void CheckGoals()
    {
        Completed = QuestGoals.All(g => g.Completed);
    }

    public void GiveReward()
    {
        if (ItemReward != null)
        {
            InventoryController.Instance.GiveItem(ItemReward);
        }
    }
}
