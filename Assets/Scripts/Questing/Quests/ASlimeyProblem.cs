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

        QuestGoals = new List<QuestGoal>
        {
            new KillGoal(0, "Kill 3 Slimes", false, 0, 5),
            new KillGoal(1, "Kill 2 Vampires", false, 0, 2)
        };

        QuestGoals.ForEach(g => g.Init());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
