using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItemController : MonoBehaviour
{ 
    Item item;

    public void AddItem(Item newItem)
    {
        item = newItem;
    }

    public void UseItem()
    {

            Debug.Log("Using item: " + item.name); // Debug log to check the name of the item
            switch (item.itemType)
            {
                case Item.ItemType.Icon:
                    GamePrefs.Instance.ChangeIcon(item.icon.name);
                    break;
                case Item.ItemType.Board:
                    break;
            }

        
    }

}
