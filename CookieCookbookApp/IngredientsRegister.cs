using System;
using CookieCookbookApp.Recipes.Ingredients;

namespace CookieCookbookApp;

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

}

