namespace CookieCookbookApp.Recipes.Ingredients;

public abstract class Flour : Ingredient 
{
    public override string Instructions => $"Sift. {base.Instructions}";
}
