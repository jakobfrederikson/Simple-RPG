using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public IWeapon parentWeapon;

    public Vector3 Direction { get; set; }
    public float Range { get; set; }

    private Vector3 spawnPosition;
    private int BaseDamage { get; set; }
    private int StatsDamage { get; set; }

    private void Start()
    {
        Range = 20f;
        BaseDamage = 4;
        spawnPosition = transform.position;
        GetComponent<Rigidbody>().AddForce(Direction * 50f);
    }

    public void ApplyPlayerStatsToDamage(int damage)
    {
        StatsDamage += damage;
    }

    private void Update()
    {
        if (Vector3.Distance(spawnPosition, transform.position) >= Range)
        {
            Extinguish();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {
            collision.transform.GetComponent<IEnemy>().TakeDamage(FinalDamageValue());
            Debug.Log("Hit: " + collision.gameObject + " for " + FinalDamageValue() + " DAMAGE.");
        }
        Extinguish();
    }

    void Extinguish()
    { 
        Destroy(gameObject);
    }

    int FinalDamageValue() => BaseDamage + StatsDamage;
}
