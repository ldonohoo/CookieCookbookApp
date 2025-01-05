using System;
using CookieCookbookApp.Recipes;
using CookieCookbookApp.Recipes.Ingredients;

namespace CookieCookbookApp.RecipesRepository;

interface IRecipesRepository
{
    // List<Recipe> Recipes { get; set; }

    List<Recipe> Read(string filePath);
    void Write(string filePath, List<Recipe> recipe);
}

class RecipesTextRepository: IRecipesRepository
{
    // this needs to be a list as we add ingredients to the recipe list
    // as the user selects them, so we can't use IEnumerable
    // public List<Recipe> Recipes => [];

    public List<Recipe> Read(string filePath) 
    {
        return new List<Recipe>
        {
            new Recipe( new List<Ingredient> 
            {       new AllPurposeFlour(),
                    new Salt(),
                    new Eggs()
            }),
            new Recipe(new List<Ingredient>
            {
                        new AllPurposeFlour(),
                        new Salt(),
                        new Eggs(),
                        new Sugar()
            })
        };
    }
    public void Write(string filePath, List<Recipe> recipe)
    {
        Console.WriteLine(filePath);
    }
}
