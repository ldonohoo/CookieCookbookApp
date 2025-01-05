using System;
using System.Security.Cryptography.X509Certificates;
using CookieCookbookApp.Recipes.Ingredients;

namespace CookieCookbookApp.RecipesRepository;

public class IngredientsRegister
{
    public IEnumerable<Ingredient> All { get; } = new List<Ingredient>
    {
            new Salt(),
            new Cinnamon(),
            new Vanilla(),
            new AllPurposeFlour(),
            new BreadFlour(),
            new Butter(),
            new Eggs(),
            new ChocolateChips()
    };

    public Ingredient? GetById(int ingredientId)
    {
        return All.SingleOrDefault(ingredient => ingredientId == ingredient.Id);
    }

}

