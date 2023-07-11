using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePopupSystem : MonoBehaviour
{
    public static DamagePopupSystem Instance;

    [SerializeField]
    public GameObject damagePopupPrefab;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }

        damagePopupPrefab = Resources.Load<GameObject>("UI/DamagePopupPrefab");
    }

    public void DisplayPopupText(Transform enemyTransform, int amount)
    {
        GameObject popUp = Instantiate(damagePopupPrefab, enemyTransform.position, Quaternion.identity);
        popUp.transform.position += new Vector3(0f, 1f, 0f);
        popUp.GetComponent<DamagePopup>().SetUp(amount);
    }

}
