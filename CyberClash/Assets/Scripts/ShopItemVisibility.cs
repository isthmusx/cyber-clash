using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItemVisibility : MonoBehaviour
{
    public GameObject[] shopItems; // Assign the item GameObjects from the scene in the Unity Editor

    private void Start()
    {
        UpdateItemVisibility();
    }

    private void UpdateItemVisibility()
    {
        // Get the list of purchased items
        List<string> purchasedItems = InventoryManager.Instance.GetPurchasedItems();

        foreach (GameObject itemObject in shopItems)
        {
            // Assume each shop item GameObject has an ItemController or similar to identify it
            var itemController = itemObject.GetComponent<ItemController>();
            if (itemController != null)
            {
                bool isPurchased = purchasedItems.Contains(itemController.item.nameItem);

                // Set active/inactive based on whether the item has been purchased
                itemObject.SetActive(!isPurchased);
            }
            else
            {
                Debug.LogWarning("ItemController component missing on item GameObject: " + itemObject.name);
            }
        }
    }
}