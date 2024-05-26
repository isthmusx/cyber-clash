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
            shop.coins -= Item.value;
            InventoryManager.Instance.Add(Item);
            Destroy(gameObject);
        }
        else
        {
            shop.modal.SetActive(true);
        }
    
        
    }
    
}
