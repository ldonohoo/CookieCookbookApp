using System;

namespace CookieCookbookApp.RecipesUserInteraction;

using CookieCookbookApp.Recipes;
using CookieCookbookApp.Recipes.Ingredients;

interface IRecipesUserInteraction
{
    void ShowMessage(string message);
    void Exit();
    void PrintExisting(IEnumerable<Recipe> allRecipes);
    void PromptToCreateRecipe();

    List<Ingredient> SelectIngredients();
}
