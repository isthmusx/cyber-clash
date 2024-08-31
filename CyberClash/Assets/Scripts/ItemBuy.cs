using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBuy : MonoBehaviour
{
    public Item Item;
    public Shop shop;

    public void Buy()
    {
        if (Item == null)
        {
            Debug.LogError("Item is not assigned.");
            return;
        }

        if (shop == null)
        {
            Debug.LogError("Shop is not assigned.");
            return;
        }

        if (shop.coins >= Item.value)
        {
            // Deduct coins
            shop.coins -= Item.value;

            // Add item to inventory
            InventoryManager.Instance.Add(Item);

            // Mark item as purchased
            InventoryManager.Instance.MarkItemAsPurchased(Item.nameItem);

            // Optionally destroy the item from the shop
            Destroy(gameObject);
        }
        else
        {
            shop.modal.SetActive(true); // Show out of stock modal
        }
    }
}