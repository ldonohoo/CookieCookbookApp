using CookieCookbookApp.Recipes;
using CookieCookbookApp.Recipes.Ingredients;

namespace CookieCookbookApp.RecipesUserInteraction;

public class RecipesConsoleUserInteraction : IRecipesUserInteraction
{
    // because i need a list of available ingredients, this should be injected through dependeny
    //  injection!! so create a private readonly field and pass the register in!
    private readonly IngredientsRegister _ingredientsRegister;

    public RecipesConsoleUserInteraction(IngredientsRegister ingredientsRegister)
    {
        _ingredientsRegister = ingredientsRegister;
    }

    public void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }

    public void Exit()
    {
        ShowMessage(Environment.NewLine + "Press any key to exit cookbook.");
        Console.ReadKey();
    }

    public void PrintExisting(IEnumerable<Recipe> allRecipes)
    {
        if (allRecipes.Count() > 0)
        {
            var count = 1;
            foreach (Recipe recipe in allRecipes)
            {
                ShowMessage($"************** {count} ***************");
                ShowMessage(recipe.ToString());
                count++;
            }
        }
        ShowMessage("No recipes in cookbook." + Environment.NewLine);
    }
    
    public void PromptToCreateRecipe()
    {
        ShowMessage("Create a new cookie recipe!");
        ShowMessage("Available ingredients:");
        foreach (Ingredient ingredient in _ingredientsRegister.All)
        {
            ShowMessage(ingredient.ToString());
        }
    }

    public List<Ingredient> SelectIngredients()
    {
        private List<Ingredient> currentIngredients = new();
        bool hasRecipeEnded = false;
        while (!hasRecipeEnded)
        {

            // ShowMessage("Please select an ingredient number to add, or any other key to save recipe:");
            // if (int.TryParse(Console.ReadLine(), out int ingredientId))
            // {
            //     Ingredient selectedIngredient = _availableIngredients.Find(ingredient => ingredient.Id == ingredientId);   
            //     if (selectedIngredient is not null)
            //     {
            //         currentIngredients.Add(selectedIngredient);
            //     } else 
            //     {
            //         ShowMessage("Ingredient not found.");
            //     }  
            // } else 
            // {
            //     didUserEndRecipe = true;
            // }
        } 
        return currentIngredients;
    }
}
