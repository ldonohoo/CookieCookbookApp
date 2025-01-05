using System;
using System.Linq.Expressions;
using CookieCookbookApp.Recipes;
using CookieCookbookApp.Recipes.Ingredients;
using CookieCookbookApp.StringsTextRepo;

namespace CookieCookbookApp.RecipesRepository;

interface IRecipesRepository
{
    List<Recipe> Read(string filePath);
    void Write(string filePath, List<Recipe> recipe);
}

class RecipesTextRepository: IRecipesRepository
{
    private readonly StringsTextRepository _stringsTextRepository;

    // this needs to be a list as we add ingredients to the recipe list
    // as the user selects them, so we can't use IEnumerable
    // public List<Recipe> Recipes => [];
    public RecipesTextRepository(StringsTextRepository stringsTextRepository)
    {
        _stringsTextRepository = stringsTextRepository;
    }
    public List<Recipe> Read(string filePath) 
    {
        // create list of recipes
        var recipes= new List<Recipe>();
        // read in list of strings using stringsTextRepository
        List<string> fileOutput = _stringsTextRepository.Read(filePath);
        // for each string line
        foreach (string line in fileOutput)
        {
            // create a new list of ingredients
            List<Ingredient> ingredients = new();
            // create a list of ingredient ints
            // convert to a list of strings(which are numbers)
            List<string> ingredientStringIds = line.Split().ToList();
            // foreach string in list
            foreach (string stringId in ingredientStringIds)
            {
              // convert to an int
                if(int.TryParse(stringId, out int ingredientId))
                {
                    // lookup the ingredient
                    var ingredient = IngredientsRegister.GetById(ingredientId);
                    if (ingredient is not null) {

                    }
                    //  add ingredient to list of ingredients
                    ingredients.Add(ingredient);
                }
            }
            // create and add recipe to list of recipes
            recipes.Add(new Recipe(ingredients));
        }
        return recipes;
    }

    public void Write(string filePath, List<Recipe> recipes)
    {
        List<string> recipeStringList = new();
        foreach (Recipe recipe in recipes)
        {
            List<int> ingredientIdList = new();
            foreach (Ingredient ingredient in recipe.Ingredients)
            {
                ingredientIdList.Add(ingredient.Id);
            }
            recipeStringList.Add(String.Join(",", ingredientIdList));
            System.Console.WriteLine(recipeStringList);
        }
        _stringsTextualRepository.Write(filePath, recipeStringList);
    }
    private readonly StringsJsonRepository _stringsTextualRepository;

    // this needs to be a list as we add ingredients to the recipe list
    // as the user selects them, so we can't use IEnumerable
    // public List<Recipe> Recipes => [];
    public RecipesJsonRepository(StringsTextRepository stringsTextualRepository)
    {
        _stringsTextRepository = stringsTextRepository;
    }
    public List<Recipe> Read(string filePath) 
    {
        var recipesFromFile = new List<Recipe>();
        List<string> fileOutput = _stringsTextRepository.Read(filePath);
        foreach (string line in fileOutput)
        {
            
        }
    }
    public void Write(string filePath, List<Recipe> recipes)
    {
        List<string> recipeStringList = new();
        foreach (Recipe recipe in recipes)
        {
            List<int> ingredientIdList = new();
            foreach (Ingredient ingredient in recipe.Ingredients)
            {
                ingredientIdList.Add(ingredient.Id);
            }
            recipeStringList.Add(String.Join(",", ingredientIdList));
            System.Console.WriteLine(recipeStringList);
        }
        _stringsTextualRepository.Write(filePath, recipeStringList);
    }
}

