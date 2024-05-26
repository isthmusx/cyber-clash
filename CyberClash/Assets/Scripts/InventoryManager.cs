using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<Item> Items = new List<Item>();

    public Transform ItemContent;
    public GameObject InventoryItem;

    public InventoryItemController[] InventoryItems;
    
    private const string PlayerPrefsKey = "InventoryItems";
    private bool itemsLoaded = false;
    
    public void Awake()
    {
        Instance = this;
        LoadItemsFromPlayerPrefs();
    }

    public void Add(Item item)
    {
        Items.Add(item);
        SaveItemsToPlayerPrefs();
    }

    public void ListItems()
    {
        CleanItems();
        foreach (var item in Items)
        {
            GameObject obj = Instantiate(InventoryItem, ItemContent);
            var itemName = obj.transform.Find("ItemName").GetComponent<TextMeshProUGUI>();
            var itemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();

            itemName.text = item.nameItem;
            itemIcon.sprite = item.icon;
            
        }
        SetItemsInventory();
        
    }

    public void SetItemsInventory()
    {
        InventoryItems = ItemContent.GetComponentsInChildren<InventoryItemController>();
        for (int i = 0; i < Items.Count; i++)
        {
            InventoryItems[i].AddItem(Items[i]);
        }
    }

    public void CleanItems()
    {
        foreach (Transform item in ItemContent)
        {
            Destroy(item.gameObject);
        }
    }
    
    // Save items to PlayerPrefs
    private void SaveItemsToPlayerPrefs()
    {
        List<string> itemNames = new List<string>();
        foreach (Item item in Items)
        {
            itemNames.Add(item.nameItem);
        }
        PlayerPrefs.SetString(PlayerPrefsKey, string.Join(",", itemNames.ToArray()));
        PlayerPrefs.Save();
    }

    // Load items from PlayerPrefs
    // Load items from PlayerPrefs
    private void LoadItemsFromPlayerPrefs()
    {
        if (!itemsLoaded && PlayerPrefs.HasKey(PlayerPrefsKey))
        {
            itemsLoaded = true;
            string[] itemNames = PlayerPrefs.GetString(PlayerPrefsKey).Split(',');
            foreach (string itemName in itemNames)
            {
                Debug.Log("Loading item: " + itemName);

                // Search for the item in the existing Items list
                Item item = Items.Find(i => i.nameItem == itemName);

                // If the item is not found in the list, you may need to instantiate it or load it from somewhere else
                if (item == null)
                {
                    Debug.LogWarning("Item not found: " + itemName);
                    // For demonstration, assuming the GetItemByName method loads the item from somewhere else
                    item = GetItemByName(itemName);
                }

                // Add the item to the Items list
                if (item != null)
                {
                    Items.Add(item);
                }
                else
                {
                    Debug.LogError("Failed to load item: " + itemName);
                }
            }

            ListItems(); // Update the UI to reflect the loaded items
        }
    }



    private Item GetItemByName(string itemName)
    {
        foreach (Item item in Items)
        {
            if (item.nameItem == itemName)
            {
                Debug.Log(item);
                return item;
                
            }
        }
        return null;
    }

    private void Update()
    {
        LoadItemsFromPlayerPrefs();
    }
}
