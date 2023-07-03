using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUIDetails : MonoBehaviour
{
    private Item item;
    private Button selectedItemButton, itemInteractButton;
    private TextMeshProUGUI itemNameText, itemDescriptionText, itemInteractButtonText;

    private void Start()
    {
        itemNameText = transform.Find("Item_Name").GetComponent<TextMeshProUGUI>();
        itemDescriptionText = transform.Find("Item_Description").GetComponent<TextMeshProUGUI>();
        itemInteractButton = transform.GetComponentInChildren<Button>();
        itemInteractButtonText = itemInteractButton.GetComponentInChildren<TextMeshProUGUI>();
        gameObject.SetActive(false);
    }

    public void SetItem(Item item, Button selectedButton)
    {
        itemInteractButton.onClick.RemoveAllListeners();
        gameObject.SetActive(true);
        this.item = item;
        selectedItemButton = selectedButton;
        itemNameText.text = item.ItemName;
        itemDescriptionText.text = item.Description;
        itemInteractButtonText.text = item.ActionName;
        itemInteractButton.onClick.AddListener(OnItemInteract);
    }

    public void OnItemInteract()
    {
        if (item.ItemType == Item.ItemTypes.Consumable)
        {
            InventoryController.Instance.ConsumeItem(item);

        }            
        else if (item.ItemType == Item.ItemTypes.Weapon)
        {
            InventoryController.Instance.EquipItem(item);
        }
        Destroy(selectedItemButton.gameObject);
        item = null;
        gameObject.SetActive(false);
    }
}
