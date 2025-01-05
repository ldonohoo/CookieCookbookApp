using System;

namespace CookieCookbookApp.Recipes.Ingredients;

public abstract class Ingredient
{
    public abstract int Id { get; }
    public abstract string Name { get; }
    public virtual string Instructions { get; } = "Add to mixture.";
    public override string ToString()
    {
        return $"{Id}. {Name}";
    }
}
