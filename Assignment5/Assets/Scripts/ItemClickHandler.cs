using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemClickHandler : MonoBehaviour
{
    [SerializeField] private BooleanVariable _inventoryHover;
    public void OnItemClicked()
    {
        // Use the item
        Slot slotScript = gameObject.transform.parent.gameObject.GetComponent<Slot>();
        ItemData item = slotScript.Item;
        if (item != null)
        {
            PlayerPickUp playerPickUp = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerPickUp>();
            playerPickUp.UseItem(item);
            // Remove item from inventory
            Inventory inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
            inventory.RemoveItem(item);
        }
    }
    public void ItemHovered()
    {
        _inventoryHover.Value = true;
    }
    public void ItemUnhovered()
    {
        _inventoryHover.Value = false;
    }
}
