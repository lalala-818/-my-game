using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Crafting Ingredient", menuName = "Inventory/Crafting Ingredient")]
[System.Serializable]
public class CraftingIngredient : ScriptableObject
{
    public Item item;
    public int amount;
}
