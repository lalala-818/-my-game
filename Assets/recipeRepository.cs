using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class recipeRepository : MonoBehaviour
{
    public static recipeRepository instance;
    public Dictionary<string, CraftingRecipe> recipeDictionary = new Dictionary<string, CraftingRecipe>();
    [SerializeField] private CraftingRecipe[] recipes;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        recipes = Resources.LoadAll<CraftingRecipe>("craft recipe");
        InitializeRecipes();
    }

    private void InitializeRecipes()
    {
        foreach (CraftingRecipe recipe in recipes)
        {
            recipeDictionary.Add(recipe.recipeName, recipe);
            Debug.Log(recipe.recipeName);
        }
    }

    public CraftingRecipe GetRecipe(string recipeName)
    {
        if (recipeDictionary.ContainsKey(recipeName))
        {
            return recipeDictionary[recipeName];
        }
        else
        {
            Debug.LogWarning("Recipe not found in repository: " + recipeName);
            return null;
        }
    }

  

}
