using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngredientSlot : MonoBehaviour
{
    public Text itemText;
    public Text amountText;

    public void SetIngredient(CraftingIngredient ingredient)
    {
        itemText.text = ingredient.item.itemName;
        amountText.text = ingredient.amount.ToString();
    }

}
