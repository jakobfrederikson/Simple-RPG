using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUIItem : MonoBehaviour
{
    public Item item;

    public void SetItem(Item item)
    {
        this.item = item;
        SetupItemValues();
    }

    private void SetupItemValues()
    {
        this.transform.Find("Item_Name").GetComponent<TextMeshProUGUI>().text = item.ItemName;
    }

    public void OnSelectItemButton()
    {
        InventoryController.Instance.SetItemDetails(item, GetComponent<Button>());
    }
}
