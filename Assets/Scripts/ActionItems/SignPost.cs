using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignPost : ActionItem
{
    public override void Interact()
    {
        DialogueSystem.Instance.AddNewDialogue(new string[] { "West" }, "Sign Post");
        Debug.Log("Interacting with sign post.");
    }
}
