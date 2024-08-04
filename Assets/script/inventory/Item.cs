using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;
[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
[System.Serializable]
public class Item :ScriptableObject
{
    public string itemName;
    public int itemId;
    public Sprite itemIcon;
    public string itemDescription;
    public int itemQuantity;
    public override bool Equals(object other)
    {
        if (other == null || GetType() != other.GetType())
        {
            return false;
        }

        Item otherItem = (Item)other;
        return itemId == otherItem.itemId;
    }
    public override int GetHashCode()
    {
        return itemId.GetHashCode();
    }

}


