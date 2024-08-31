using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<Item> Items = new List<Item>(); // All items loaded from resources
    private List<Item> purchasedItems = new List<Item>(); // Only purchased items

    public Transform ItemContent;
    public GameObject InventoryItem;
    public InventoryItemController[] InventoryItems;

    private const string PlayerPrefsKey = "InventoryItems";
    private const string PurchasedItemsKey = "PurchasedItems";
    private const string EquippedItemKey = "EquippedItem";
    private bool itemsLoaded = false;

    public void Awake()
    {
        Instance = this;
        PopulateItems(); // Load all items from resources
        LoadPurchasedItems(); // Load purchased items from PlayerPrefs
        LoadEquippedItem(); // Load equipped item from PlayerPrefs
        ListItems(); // Display only purchased items
    }


    private void PopulateItems()
    {
        // List of item names you want to load
        string[] itemNames = { "Icon1", "Icon2", "Icon3", "Icon4", "Icon5", "Icon6", "Icon7", "Board1" };

        foreach (string itemName in itemNames)
        {
            Item item = LoadItemFromResources(itemName);
            if (item != null)
            {
                Items.Add(item);
            }
            else
            {
                Debug.LogError("Item not found: " + itemName);
            }
        }
    }

    public void Add(Item item)
    {
        if (!purchasedItems.Contains(item))
        {
            purchasedItems.Add(item);
            SavePurchasedItems(); // Save purchased items to PlayerPrefs
            ListItems(); // Refresh the displayed items
        }
    }

    public void MarkItemAsPurchased(string itemName)
    {
        Item item = GetItemByName(itemName);
        if (item != null && !purchasedItems.Contains(item))
        {
            purchasedItems.Add(item);
            SavePurchasedItems(); // Save purchased items to PlayerPrefs
            ListItems(); // Refresh the displayed items
        }
    }

    public List<string> GetPurchasedItems()
    {
        List<string> purchasedItemsList = new List<string>();
        if (PlayerPrefs.HasKey(PurchasedItemsKey))
        {
            string[] items = PlayerPrefs.GetString(PurchasedItemsKey).Split(',');
            purchasedItemsList.AddRange(items);
        }
        return purchasedItemsList;
    }

    public void ListItems()
    {
        CleanItems(); // Clean up old items first

        List<string> purchasedItemNames = GetPurchasedItems(); // Get the list of purchased items

        HashSet<string> displayedItemNames = new HashSet<string>();

        foreach (var item in Items)
        {
            if (purchasedItemNames.Contains(item.nameItem))
            {
                if (!displayedItemNames.Contains(item.nameItem))
                {
                    GameObject obj = Instantiate(InventoryItem, ItemContent);

                    var itemName = obj.transform.Find("ItemName").GetComponent<TextMeshProUGUI>();
                    var itemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();

                    itemName.text = item.nameItem;
                    itemIcon.sprite = item.icon;

                    var controller = obj.GetComponent<InventoryItemController>();
                    if (controller != null)
                    {
                        controller.AddItem(item);
                    }
                    else
                    {
                        Debug.LogWarning("InventoryItemController component not found on instantiated object.");
                    }

                    displayedItemNames.Add(item.nameItem);
                }
            }
        }

        // Refresh InventoryItems after instantiation
        InventoryItems = ItemContent.GetComponentsInChildren<InventoryItemController>();

        // Update item states (e.g., clickable/unclickable)
        UpdateItemStates();
    }

    private void UpdateItemStates()
    {
        foreach (var controller in InventoryItems)
        {
            if (controller != null)
            {
                controller.UpdateButtonState(); // Update the button state
            }
        }
    }

    public void CleanItems()
    {
        foreach (Transform item in ItemContent)
        {
            Destroy(item.gameObject);
        }
    }

    private void SavePurchasedItems()
    {
        List<string> itemNames = new List<string>();
        foreach (Item item in purchasedItems)
        {
            itemNames.Add(item.nameItem);
        }
        PlayerPrefs.SetString(PurchasedItemsKey, string.Join(",", itemNames.ToArray()));
        PlayerPrefs.Save();
    }

    private void LoadPurchasedItems()
    {
        if (!itemsLoaded && PlayerPrefs.HasKey(PurchasedItemsKey))
        {
            itemsLoaded = true;
            string[] itemNames = PlayerPrefs.GetString(PurchasedItemsKey).Split(',');
            foreach (string itemName in itemNames)
            {
                Debug.Log("Loading purchased item: " + itemName);

                Item item = GetItemByName(itemName);

                if (item != null)
                {
                    purchasedItems.Add(item);
                }
                else
                {
                    Debug.LogWarning("Purchased item not found in Items list: " + itemName);
                }
            }
        }
    }

    private Item GetItemByName(string itemName)
    {
        return Items.Find(item => item.nameItem == itemName);
    }

    private Item LoadItemFromResources(string itemName)
    {
        return Resources.Load<Item>($"Items/{itemName}");
    }
    
    public void SaveEquippedItem(Item item)
    {
        if (item == null)
        {
            Debug.LogError("Cannot save equipped item because it is null.");
            return;
        }

        Debug.Log("Saving equipped item: " + item.nameItem);
        PlayerPrefs.SetString(EquippedItemKey, item.nameItem);
        PlayerPrefs.Save();
    }

    private void LoadEquippedItem()
    {
        string equippedItemName = PlayerPrefs.GetString(EquippedItemKey, string.Empty);
        Debug.Log("Loaded equipped item name from PlayerPrefs: " + equippedItemName);

        Item equippedItem = GetItemByName(equippedItemName);
        if (equippedItem != null)
        {
            Debug.Log("Setting equipped item: " + equippedItem.nameItem);
            InventoryItemController.SetCurrentEquippedItem(equippedItem);
        }
        else
        {
            Debug.LogWarning("Equipped item not found in Items list: " + equippedItemName);
        }
    }




}