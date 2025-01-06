
using CookieCookbookApp.Recipes.Ingredients;
using CookieCookbookApp.DataAccess;

namespace CookieCookbookApp.Recipes;

class RecipesRepository: IRecipesRepository
{
    private const string Separator = ",";
    private readonly IStringsRepository _stringsRepository;
    private readonly IIngredientsRegister _ingredientsRegister;

    // this needs to be a list as we add ingredients to the recipe list
    // as the user selects them, so we can't use IEnumerable
    // public List<Recipe> Recipes => [];
    public RecipesRepository(
        IStringsRepository stringsRepository,
        IIngredientsRegister ingredientsRegister)
    {
        _stringsRepository = stringsRepository;
        _ingredientsRegister = ingredientsRegister;
    }
    public List<Recipe> Read(string filePath) 
    {
        List<string> recipesFromFile = _stringsRepository.Read(filePath);

        var recipes= new List<Recipe>();
        foreach (string recipeFromFile in recipesFromFile)
        {
            var recipe = RecipeFromString(recipeFromFile);
           
            recipes.Add(recipe);
        }
        return recipes;
    }

    private Recipe RecipeFromString(string recipeFromFile)
    {
        List<string> ingredientIds = recipeFromFile.Split(Separator).ToList();
        List<Ingredient> ingredients = new();
        foreach (string ingredientId in ingredientIds)
        {
            if(int.TryParse(ingredientId, out int id))
            {
                var ingredient = _ingredientsRegister.GetById(id);
                if (ingredient is not null) 
                {
                    ingredients.Add(ingredient);
                }
            }
        }
        return new Recipe(ingredients);
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
            recipeStringList.Add(String.Join(Separator, ingredientIdList));
            System.Console.WriteLine(recipeStringList);
        }
        _stringsRepository.Write(filePath, recipeStringList);
    }
}

