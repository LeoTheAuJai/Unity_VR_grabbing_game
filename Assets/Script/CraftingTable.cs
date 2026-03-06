using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CraftingTable : MonoBehaviour
{
    public List<Transform> ingredientSlots; // Slots for placing ingredients (up to 4)
    public List<Recipe> recipes; // List of available recipes (up to 9)

    private List<GameObject> currentIngredients = new List<GameObject>(); // Current ingredients in the slots

    [System.Serializable]
    public class Recipe
    {
        public string[] requiredIngredients; // Names of required ingredients (up to 4)
        public GameObject outputItem; // The crafted object
    }

    void Update()
    {
        // Check for right-click to craft
        if (Input.GetMouseButtonDown(1)) // Right-click
        {
            CraftItem();
        }
    }

    // Add an ingredient to the crafting table
    public void AddIngredient(GameObject ingredient)
    {
        if (currentIngredients.Count < 4)
        {
            // Place the ingredient in the next available slot
            ingredient.transform.position = ingredientSlots[currentIngredients.Count].position;
            ingredient.transform.SetParent(ingredientSlots[currentIngredients.Count]); // Make it a child of the slot
            currentIngredients.Add(ingredient);

            // Disable the ingredient's grabbable component (optional)
            var grabbable = ingredient.GetComponent<XRGrabInteractable>();
            if (grabbable != null)
            {
                grabbable.enabled = false;
            }
        }
    }

    // Check if the current ingredients match any recipe
    void CraftItem()
    {
        foreach (Recipe recipe in recipes)
        {
            if (IsRecipeMatch(recipe))
            {
                // Instantiate the output item
                GameObject outputItem = Instantiate(recipe.outputItem, transform.position, Quaternion.identity);

                // Make the output item grabbable
                var grabbable = outputItem.GetComponent<XRGrabInteractable>();
                if (grabbable == null)
                {
                    grabbable = outputItem.AddComponent<XRGrabInteractable>();
                }

                // Clear the ingredient slots
                ClearIngredientSlots();
                break;
            }
        }
    }

    // Check if the current ingredients match a specific recipe
    bool IsRecipeMatch(Recipe recipe)
    {
        if (currentIngredients.Count != recipe.requiredIngredients.Length)
            return false;

        for (int i = 0; i < recipe.requiredIngredients.Length; i++)
        {
            if (currentIngredients[i].name != recipe.requiredIngredients[i])
                return false;
        }

        return true;
    }

    // Clear the ingredient slots
    void ClearIngredientSlots()
    {
        foreach (var ingredient in currentIngredients)
        {
            Destroy(ingredient); // Destroy the ingredient objects
        }
        currentIngredients.Clear();
    }
}