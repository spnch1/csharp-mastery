using CookiesCookbookRefactored.DataAccess;
using CookiesCookbookRefactored.Recipes.Ingredients;

namespace CookiesCookbookRefactored.Recipes;

public class RecipesRepository(
    IStringsRepository stringsRepository,
    IIngredientsRegister ingredientsRegister) : IRecipesRepository
{
    private const string Separator = ",";
        
    public List<Recipe> Read(string filePath) =>
        stringsRepository
            .Read(filePath)
            .Select(RecipeFromString)
            .ToList();

    private Recipe RecipeFromString(string recipe) =>
        new(recipe
            .Split(Separator)
            .Select(int.Parse)
            .Select(ingredientsRegister.GetById));

    public void Write(string filePath, List<Recipe> recipes) =>
        stringsRepository.Write(filePath, recipes
            .Select(recipe => string.Join(
                Separator,
                recipe.Ingredients
                    .Select(i => i.Id)
            ))
            .ToList());
}