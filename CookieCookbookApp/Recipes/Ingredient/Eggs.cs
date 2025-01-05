namespace CookieCookbookApp.Recipes.Ingredients;

public class Eggs : Ingredient
{
    public override int Id => 7;
    public override string Name => "Eggs";
    public override string Instructions => "Crack eggs." + base.Instructions;
}
