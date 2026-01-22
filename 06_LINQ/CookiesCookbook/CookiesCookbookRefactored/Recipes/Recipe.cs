using CookiesCookbookRefactored.Recipes.Ingredients;

namespace CookiesCookbookRefactored.Recipes;

public class Recipe(IEnumerable<Ingredient> ingredients)
{
    public IEnumerable<Ingredient> Ingredients => ingredients;
    
    public override string ToString() =>
        string.Join(Environment.NewLine, Ingredients
            .Select(i => $"{i.Name}. {i.PreparationInstructions}"));
}