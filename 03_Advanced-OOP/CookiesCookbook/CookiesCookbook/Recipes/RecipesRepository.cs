using CookiesCookbook.DataAccess;
using CookiesCookbook.Recipes.Ingredients;

namespace CookiesCookbook.Recipes;

public class RecipesRepository(
    IStringsRepository stringsRepository,
    IIngredientsRegister ingredientsRegister) : IRecipesRepository
{
    private const string Separator = ",";
        
    public List<Recipe> Read(string filePath)
    {
        var recipesFromFile = stringsRepository.Read(filePath);
        List<Recipe> recipes = [];

        foreach (var recipeFromFile in recipesFromFile)
        {
            var recipe = RecipeFromString(recipeFromFile);
            recipes.Add(recipe);
        }

        return recipes;
    }

    private Recipe RecipeFromString(string recipe)
    {
        var textualIds = recipe.Split(Separator);
        List<Ingredient> ingredients = [];

        foreach (var textualId in textualIds)
        {
            var id = int.Parse(textualId);
            var ingredient = ingredientsRegister.GetById(id);
            ingredients.Add(ingredient);
        }

        return new Recipe(ingredients);
    }

    public void Write(string filePath, List<Recipe> recipes)
    {
        List<string> recipesAsStrings = [];
        foreach (var recipe in recipes)
        {
            List<int> allIds = [];
            foreach (var ingredient in recipe.Ingredients)
            {
                allIds.Add(ingredient.Id);
            }

            recipesAsStrings.Add(string.Join(Separator, allIds));
        }
        stringsRepository.Write(filePath, recipesAsStrings);
    }
}