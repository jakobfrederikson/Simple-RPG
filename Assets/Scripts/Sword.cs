using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour, IWeapon
{
    private Animator _animator;
    public List<BaseStat> Stats { get; set; }

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void PerformAttack()
    {
        _animator.SetTrigger("Base_Attack");
        Debug.Log(this.name + " attack!");
    }

    public void PerformSpecialAttack()
    {
        _animator.SetTrigger("Special_Attack");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<IEnemy>().TakeDamage(Stats[0].GetCalculatedStatValue());
        }
        Debug.Log("Hit: " + other.name);
    }
}
