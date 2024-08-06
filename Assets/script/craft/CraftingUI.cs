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
    void Start()
    {
        foreach (CraftingRecipe recipe in recipeRepository.instance.recipeDictionary.Values)
        {
            Debug.Log(recipe.name);
            GameObject craftingSlot = Instantiate(craftingSlotPrefab, craftingSlotsParent);
            Text nameText = craftingSlot.transform.Find("Item").GetComponent<Text>();
            nameText.text = recipe.name;
            Image iconImage = craftingSlot.transform.Find("Icon").GetComponent<Image>();
            iconImage.sprite = recipe.resultItem.itemIcon;
            Text amountText = craftingSlot.transform.Find("Quantity").GetComponent<Text>();
            amountText.text = recipe.resultAmount.ToString();
            craftingSlot.GetComponent<CraftingSlot>().SetRecipe(recipe);
            craftingSlots.Add(craftingSlot);
            craftButton.onClick.AddListener(CraftItem);
        }

    }

    void CraftItem()
    {
        foreach (var slot in craftingSlots)
        {
            Debug.Log(slot.name);
            CraftingSlot craftingSlot = slot.GetComponent<CraftingSlot>();
            if (craftingSlot.isSelected)
            {
                Debug.Log("isSelected");
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
                        Inventory.instance.RemoveItem(ingredient.item.itemId, ingredient.item, ingredient.amount);
                    }

                    Inventory.instance.AddItem(recipe.resultItem.itemId, recipe.resultItem, recipe.resultAmount);
                }
                else
                {
                    Debug.Log("Not enough materials to craft this item.");
                }
            }
            else
            {
                Debug.Log("not isSelected");
            }
        }
    }
}

  

