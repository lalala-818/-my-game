using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;
[CreateAssetMenu(fileName = "New Crafting Recipe", menuName = "Inventory/Crafting Recipe")]
[System.Serializable]
public class CraftingRecipe :ScriptableObject
{
    public string recipeName;
    public Item resultItem;
    public int resultAmount;
    public List<CraftingIngredient> ingredients;
}

