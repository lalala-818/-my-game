using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> items = new List<Item>();

    public void AddItem(Item item)
    {
        Item existingItem = items.Find(i => i.itemId == item.itemId);
        if (existingItem != null)
        {
            existingItem.itemQuantity += item.itemQuantity;
        }
        else
        {
            items.Add(item);
        }
    }

    public void RemoveItem(Item item)
    {
        Item existingItem = items.Find(i => i.itemId == item.itemId);
        if (existingItem != null)
        {
            existingItem.itemQuantity -= item.itemQuantity;
            if (existingItem.itemQuantity <= 0)
            {
                items.Remove(existingItem);
            }
        }
    }
}
// Start is called before the first frame update
    // Update is called once per frame


