using System.Collections.Generic;

public interface IWeapon
{
    public List<BaseStat> Stats { get; set; }
    void PerformAttack();
    void PerformSpecialAttack();
}