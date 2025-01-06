using CookieCookbookApp.Recipes;
using CookieCookbookApp.App;

namespace CookieCookbookApp.App;
class CookiesCookbook
{
    private readonly IRecipesRepository _recipesRepository;
    private readonly IRecipesUserInteraction _recipesUserInteraction;

    public CookiesCookbook(
        IRecipesRepository recipesRepository,
        IRecipesUserInteraction recipesUserInteraction)
    {
        _recipesRepository = recipesRepository;
        _recipesUserInteraction = recipesUserInteraction;
    }
    
    public void Open(string filePath)
    {
        // read recipes from file     
        var allRecipes = _recipesRepository.Read(filePath);

        // print welcome message
        // print recipes from file
        _recipesUserInteraction.PrintExisting(allRecipes);

        // prompt user for ingredients
       _recipesUserInteraction.PromptToCreateRecipe();

        // select ingredients and create recipe
        var selectedIngredients = _recipesUserInteraction.SelectIngredients();
        if (selectedIngredients.Count() == 0)
        {
            _recipesUserInteraction.ShowMessage("No ingredients selected. Recipe not created.");
        } else
        {
            // save recipe to all recipes
            var recipe = new Recipe(selectedIngredients);
            allRecipes.Add(recipe);

            // write all recipes to file
            _recipesRepository.Write(filePath, allRecipes);

            // print created recipe
            _recipesUserInteraction.ShowMessage("Recipe created:");
            _recipesUserInteraction.ShowMessage(recipe.ToString());
        }
        // exit cookbook
         _recipesUserInteraction.Exit();
    }
}