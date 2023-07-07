using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillGoal : QuestGoal
{
    public int EnemyID { get; set; }

    public KillGoal(int enemyID, string description, bool completed, int currentAmount, int requiredAmount) 
    {
        this.EnemyID = enemyID;
        this.Description = description;
        this.Completed = completed;
        this.CurrentAmount = currentAmount;
        this.RequiredAmount = requiredAmount;
    }


    public override void Init()
    {
        base.Init();
        CombatEvents.OnEnemyDeath += EnemyDied;
    }

    private void EnemyDied (IEnemy enemy)
    {
        if (enemy.ID == this.EnemyID)
        {
            Debug.Log("Detected enemy death: " + EnemyID);
            this.CurrentAmount++;
            Evaluate();
        }
    }
}
