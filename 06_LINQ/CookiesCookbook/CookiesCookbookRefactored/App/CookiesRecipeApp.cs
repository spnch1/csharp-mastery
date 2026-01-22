using CookiesCookbookRefactored.Recipes;

namespace CookiesCookbookRefactored.App;

public class CookiesRecipeApp(
    IRecipesRepository recipesRepository,
    IRecipesUserInteraction recipesUserInteraction)
{
    public void Run(string filePath)
    {
        var allRecipes = recipesRepository.Read(filePath);
        recipesUserInteraction.PrintExistingRecipes(allRecipes);
        
        recipesUserInteraction.PromptToCreateRecipe();

        var ingredients = recipesUserInteraction.ReadIngredientsFromUser();
        if (ingredients.Count() > 0)
        {
            Recipe recipe = new(ingredients);
            allRecipes.Add(recipe);
            recipesRepository.Write(filePath, allRecipes);
            recipesUserInteraction.ShowMessage(
                $"Recipe added:{Environment.NewLine}{recipe.ToString()}");
        }
        else
        {
            recipesUserInteraction.ShowMessage(
                "No ingredients have been selected. " +
                "Recipe will not be saved.");
        }

        recipesUserInteraction.Exit();
    }
}