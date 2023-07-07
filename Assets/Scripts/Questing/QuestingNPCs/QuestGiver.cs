using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : NPC
{
    public bool AssignedQuest { get; set; }
    public bool Helped { get; set; }

    [SerializeField]
    private GameObject quests;

    [SerializeField]
    private string questType;
    private Quest Quest { get; set; }

    public override void Interact()
    {  
        if (!AssignedQuest && !Helped)
        {
            base.Interact();
            AssignQuest();
        }
        else if (AssignedQuest && !Helped)
        {
            CheckQuest();
        }
        else
        {
            DialogueSystem.Instance.AddNewDialogue(new string[] { "Hello." }, name);
        }
    }

    private void AssignQuest()
    {
        AssignedQuest = true;
        Quest = (Quest)quests.AddComponent(System.Type.GetType(questType));
        DialogueSystem.Instance.AddNewDialogue(Quest.StartQuestDialogue(), name);
    }

    private void CheckQuest()
    {
        if (Quest.Completed)
        {
            Quest.GiveReward();
            Helped = true;
            AssignedQuest = false;
            DialogueSystem.Instance.AddNewDialogue(Quest.EndQuestDialogue(), name);
        }
        else
        {
            DialogueSystem.Instance.AddNewDialogue(Quest.BetweenQuestDialogue(), name);
        }
    }
}
