using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface INameplate
{
    public string Name { get; set; }
    public string IconSlug { get; set; }
    public int MaxHealth { get; set; }
    public int CurrentHealth { get; set; }
    
    public int MaxIntellect { get; set; }
    public int CurrentIntellect { get; set; }
    public bool IsSelected { get; set; }
}
