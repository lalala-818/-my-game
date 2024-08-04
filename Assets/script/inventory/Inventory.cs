using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    public Dictionary<int, Item> items = new Dictionary<int, Item>();
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddItem(int itemID, Item item, int amount)
    {

        if (items.ContainsKey(itemID))
        {
            items[itemID].itemQuantity += amount;
            Debug.Log("Added " + amount + " " + item.itemName + " to inventory");

        }
        else
        {
            items.Add(itemID, item);
            items[itemID].itemQuantity = amount;
            Debug.Log("Added " + amount + " " + item.itemName + " to inventory");

        }
        InventoryUI inventoryUI = FindObjectOfType<InventoryUI>();
        if (inventoryUI != null)
        {

            inventoryUI.UpdateUI();
        }
    }

    public void RemoveItem(int itemID, Item item, int amount)
    {
        if (items.ContainsKey(itemID))
        {
            items[itemID].itemQuantity -= amount;
            if (items[itemID].itemQuantity <= 0)
            {
                items.Remove(itemID);
            }
        }
    }
    public bool HasItem(int itemID, int amount)
    {
        return items.ContainsKey(itemID) && items[itemID].itemQuantity >= amount;
    }
    public Dictionary<int, Item> GetAllItems()
    {
        return items;
    }
    public Item GetItem(int itemID)
    {
        if (items.ContainsKey(itemID))
        {
            return items[itemID];
        }
        return null;
    }

}



