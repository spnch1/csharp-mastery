using CookiesCookbook.Recipes;
using CookiesCookbook.Recipes.Ingredients;

namespace CookiesCookbook.App;

public interface IRecipesUserInteraction
{
    void ShowMessage(string message);
    void PrintExistingRecipes(IEnumerable<Recipe> recipes);
    void Exit();
    void PromptToCreateRecipe();
    IEnumerable<Ingredient> ReadIngredientsFromUser();
}