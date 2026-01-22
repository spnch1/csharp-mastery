using CookiesCookbookRefactored.Recipes;
using CookiesCookbookRefactored.Recipes.Ingredients;

namespace CookiesCookbookRefactored.App;

public interface IRecipesUserInteraction
{
    void ShowMessage(string message);
    void PrintExistingRecipes(IEnumerable<Recipe> recipes);
    void Exit();
    void PromptToCreateRecipe();
    IEnumerable<Ingredient> ReadIngredientsFromUser();
}