using CookieCookbookApp.Recipes;
using CookieCookbookApp.Recipes.Ingredients;

namespace CookieCookbookApp.App;
interface IRecipesUserInteraction
{
    void ShowMessage(string message);
    void Exit();
    void PrintExisting(IEnumerable<Recipe> allRecipes);
    void PromptToCreateRecipe();

    List<Ingredient> SelectIngredients();
}
