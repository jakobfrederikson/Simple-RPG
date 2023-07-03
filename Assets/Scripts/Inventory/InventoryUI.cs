using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public RectTransform inventoryPanel;
    public RectTransform scrollViewContent;

    private InventoryUIItem itemContainer { get; set; }
    private bool menuIsActive { get; set; }
    private Item currentSelectedItem { get; set; }

    void Start()
    {  
        itemContainer = Resources.Load<InventoryUIItem>("UI/Item_Container");
        UIEventHandler.OnItemAddedToInventory += ItemAdded;
        inventoryPanel.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            menuIsActive = !menuIsActive;
            inventoryPanel.gameObject.SetActive(menuIsActive);
        }
    }

    public void ItemAdded(Item item)
    {
        Debug.Log("Item added: " + item.ItemName);
        InventoryUIItem emptyItem = Instantiate(itemContainer);
        emptyItem.SetItem(item);
        emptyItem.transform.SetParent(scrollViewContent, false);
    }
}
