using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingUI : MonoBehaviour
{
    public GameObject craftingSlotPrefab;
    public Transform craftingSlotsParent;
    public Button craftButton;
    private List<GameObject> craftingSlots = new List<GameObject>();
    public List<CraftingRecipe> recipes = new List<CraftingRecipe>();
    void woodenSwordRecipe()
    {
        CraftingRecipe recipe = new CraftingRecipe();
        recipe.resultItem.itemName = "Wooden Sword";
        recipe.resultAmount = 1;
        recipes.Add(recipe);
    }
    void Start()
    {
        foreach (var recipe in recipes)
        {
            GameObject Slot = Instantiate(craftingSlotPrefab, craftingSlotsParent);
            Slot.GetComponent<CraftingSlot>().SetRecipe(recipe);
            craftingSlots.Add(Slot);
        }
        craftButton.onClick.AddListener(CraftItem);
    }

    void CraftItem()
    {
        foreach (var slot in craftingSlots)
        {
            CraftingSlot craftingSlot = slot.GetComponent<CraftingSlot>();
            if (craftingSlot.isSelected)
            {
                CraftingRecipe recipe = craftingSlot.GetRecipe();
                bool canCraft = true;

                foreach (var ingredient in recipe.ingredients)
                {
                    if (!Inventory.instance.HasItem(ingredient.item.itemId, ingredient.amount))
                    {
                        canCraft = false;
                        break;
                    }

                }
                if (canCraft)
                {
                    foreach (var ingredient in recipe.ingredients)
                    {
                        Inventory.instance.RemoveItem(ingredient.item.itemId, ingredient.item,ingredient.amount);
                    }

                    Inventory.instance.AddItem(recipe.resultItem.itemId, recipe.resultItem,recipe.resultAmount);
                }
                else
                {
                    Debug.Log("Not enough materials to craft this item.");
                }
            }
        }
    }
}

  

