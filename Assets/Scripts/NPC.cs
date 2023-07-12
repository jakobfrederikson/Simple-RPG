using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : Interactable, INameplate
{
    public string Name { get; set; }
    public string IconSlug { get; set; } = "npc";
    public int MaxHealth { get; set; }
    public int CurrentHealth { get; set; }

    public int MaxIntellect { get; set; }
    public int CurrentIntellect { get; set; }

    public bool IsSelected { get; set; } = false;

    public Image Icon { get; set; }

    public string[] dialogue;
    public new string name;
    public int maxHealth;
    public int maxIntellect;

    private void Start()
    {
        Name = name;
        MaxHealth = maxHealth;
        CurrentHealth = MaxHealth;
        MaxIntellect = maxIntellect;
        CurrentIntellect = MaxIntellect;
    }

    public override void Interact()
    {
        DialogueSystem.Instance.AddNewDialogue(dialogue, name);
        Debug.Log("Interacting with NPC.");
    }
}
