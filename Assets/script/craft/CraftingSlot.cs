using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingSlot : MonoBehaviour
{
    public Text resultItemText;
    public Text resultAmountText;
    public Transform ingredientParent;
    public GameObject itemSlotPrefab;
    public CraftingRecipe recipe;
    public bool isSelected{ get; set; }
    

    
    public void SetRecipe(CraftingRecipe recipe)
    {
        
        this.recipe = recipe;
        resultItemText.text = recipe.resultItem.itemName;
        resultAmountText.text = recipe.resultAmount.ToString();
        foreach (var ingredient in recipe.ingredients)
        {
            GameObject Slot = Instantiate(itemSlotPrefab, ingredientParent);
            Slot.GetComponent<IngredientSlot>().SetIngredient(ingredient);
        }
    }
    public CraftingRecipe GetRecipe()
    {
        return recipe;

    }


}
