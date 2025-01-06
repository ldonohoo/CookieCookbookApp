

namespace CookieCookbookApp.Recipes;

interface IRecipesRepository
{
    List<Recipe> Read(string filePath);
    void Write(string filePath, List<Recipe> recipe);
}

