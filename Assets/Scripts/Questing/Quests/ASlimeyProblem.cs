using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ASlimeyProblem : Quest
{
    // Start is called before the first frame update
    void Start()
    {
        QuestName = "A Slimey Problem";
        Description = "Get rid of the slimes around Camp Startious.";
        ItemReward = ItemDatabase.Instance.GetItem("potion_log");
        ExperienceReward = 100;

        QuestGoals.Add(new KillGoal(this, 0, "Kill 3 Slimes", false, 0, 3));
        QuestGoals.Add(new CollectionGoal(this, "potion_log", "Collect a log potion", false, 0, 1));

        QuestGoals.ForEach(g => g.Init());
    }

    public override string[] StartQuestDialogue()
    {
        return new string[] { 
            "Hey partner, I've got quite the slimey problem!",
            "Could you clear out these 3 slimes around the Camp?",
            "They're making everything all gross and slimey!"
        };
    }

    public override string[] BetweenQuestDialogue()
    {
        return new string[] { 
            "Hey, you're still helping me! Clear out those 3 slimes around this camp!" 
        };
    }

    public override string[] EndQuestDialogue()
    {
        return new string[] { 
            "Thank you so much, traveller!",
            "Here, take this potion. It doesn't mean much to me!"
        };
    }
}
