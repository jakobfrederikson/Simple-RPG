using System.Collections.Generic;

public interface IWeapon
{
    public List<BaseStat> Stats { get; set; }
    public int CurrentDamage { get; set; }
    void PerformAttack(int damage);
    void PerformSpecialAttack();
}
