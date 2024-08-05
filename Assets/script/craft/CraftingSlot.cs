using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class CraftingSlot : MonoBehaviour
{
    public GameObject ingredientSlotPrefab;
    public Transform ingredientParent;
    public CraftingRecipe recipe;
    public bool isSelected{ get; set; }
    

    
    public void SetRecipe(CraftingRecipe recipe)
    {
        this.recipe = recipe;
        Debug.Log(recipe.resultItem.itemName);
        foreach (var ingredient in recipe.ingredients)
        {
            GameObject Slot = Instantiate(ingredientSlotPrefab, ingredientParent);
            Text amountText = Slot.transform.Find("Quantity").GetComponent<Text>();
            Debug.Log(ingredient.item.itemName);
            amountText.text = ingredient.amount.ToString(); 
            Text itemText = Slot.transform.Find("Item").GetComponent<Text>();
            itemText.text = ingredient.item.itemName;
            Image icon = Slot.transform.Find("Icon").GetComponent<Image>();
            icon.sprite = ingredient.item.itemIcon;
        }
    }
    public CraftingRecipe GetRecipe()
    {
        return recipe;

    }


}
