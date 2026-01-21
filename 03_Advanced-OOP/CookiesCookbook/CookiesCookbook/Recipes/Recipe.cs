using CookiesCookbook.Recipes.Ingredients;

namespace CookiesCookbook.Recipes;

public class Recipe(IEnumerable<Ingredient> ingredients)
{
    public IEnumerable<Ingredient> Ingredients => ingredients;
    
    public override string ToString()
    {
        List<string> steps = [];
        foreach (var ingredient in ingredients)
        {
            steps.Add($"{ingredient.Name}. {ingredient.PreparationInstructions}");
        }
        
        return string.Join(Environment.NewLine, steps);
    }
}