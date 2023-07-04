using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumableController : MonoBehaviour
{
    private CharacterStats characterStats;

    // Start is called before the first frame update
    void Start()
    {
        characterStats = GetComponent<Player>().characterStats;
    }

    public void ConsumeItem(Item item)
    {
        GameObject itemToSpawn = Instantiate(Resources.Load<GameObject>("Consumables/" + item.ObjectSlug));
        if (item.ItemModifier)
        {
            itemToSpawn.GetComponent<IConsumable>().Consume(characterStats);
        }
        else
            itemToSpawn.GetComponent <IConsumable>().Consume();
    }
}
