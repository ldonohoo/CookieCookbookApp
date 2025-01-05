
using CookieCookbookApp.Recipes.Ingredients;

namespace CookieCookbookApp.Recipes;

public class Recipe
{
    // using IEnumerable here signals that we are using a list that we don't want to be modified!
    //  it doesn't prevent it fully but it makes it harder to say clear the whole list
    //          ((List<Ingredient>)recipe.Ingredients).Clear())
    //   later use readonly collections!
    public IEnumerable<Ingredient> Ingredients{ get; set; }
    
    public Recipe(IEnumerable<Ingredient> ingredients)
    {
        Ingredients = ingredients;
    }

    public override string ToString()
    {
        string formattedIngredients = String.Empty;
        foreach (var ingredient in Ingredients)
        {
            formattedIngredients += $"{ingredient.Name}: {ingredient.Instructions}{Environment.NewLine}";
        }
        return formattedIngredients;
    }

}
