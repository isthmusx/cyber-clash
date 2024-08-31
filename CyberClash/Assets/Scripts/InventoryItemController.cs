using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryItemController : MonoBehaviour
{ 
    public Button itemButton;
    public TextMeshProUGUI buttonText;
    private Item item;

    public Item GetItem()
    {
        return item;
    }
    
    public void AddItem(Item newItem)
    {
        item = newItem;
        UpdateButtonState();
    }

    public void UseItem()
    {
        if (item == null)
        {
            Debug.LogError("Item is null in UseItem.");
            return;
        }

        Debug.Log("Using item: " + item.nameItem);

        // Change the icon or other properties based on item type
        switch (item.itemType)
        {
            case Item.ItemType.Icon:
                GamePrefs.Instance.ChangeIcon(item.icon.name);
                break;
            case Item.ItemType.Board:
                // Handle board items if needed
                break;
        }

        // Update the equipped item
        SetCurrentEquippedItem(item);
        InventoryManager.Instance.SaveEquippedItem(item); // Save equipped item
    }



    public void UpdateButtonState(bool isClickable = true, string text = "Equip")
    {
        if (itemButton != null)
        {
            itemButton.interactable = isClickable;
            if (buttonText != null)
            {
                buttonText.text = text;
            }
        }
    }


    private static Item currentEquippedItem;

    public static void SetCurrentEquippedItem(Item item)
    {
        Debug.Log("Setting current equipped item: " + item?.nameItem ?? "None");
        currentEquippedItem = item;
        UpdateAllItems(); // Ensure all items have the correct state
    }



    public static void UpdateAllItems()
    {
        foreach (var controller in FindObjectsOfType<InventoryItemController>())
        {
            bool isEquipped = controller.GetItem() == currentEquippedItem;
            controller.UpdateButtonState(!isEquipped, isEquipped ? "Equipped" : "Equip");
        }
    }
}