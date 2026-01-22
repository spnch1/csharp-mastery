using CookiesCookbookRefactored.Recipes;
using CookiesCookbookRefactored.Recipes.Ingredients;

namespace CookiesCookbookRefactored.App;

public class RecipesConsoleUserInteraction(IIngredientsRegister ingredientsRegister)
    : IRecipesUserInteraction
{
    public void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }

    public void PrintExistingRecipes(IEnumerable<Recipe> recipes)
    {
        if (recipes.Any())
        {
            Console.WriteLine($"Existing recipes:{Environment.NewLine}");

            var counter = 1;
            foreach (var recipe in recipes)
            {
                Console.WriteLine($"*****{counter}*****");
                Console.WriteLine(recipe + Environment.NewLine);
                ++counter;
            }
        }
    }

    public void PromptToCreateRecipe()
    {
        Console.WriteLine("Create a new cookie recipe! " +
                          "Available ingredients are:");
        foreach (var ingredient in ingredientsRegister.All)
        {
            Console.WriteLine(ingredient);
        }
    }

    public IEnumerable<Ingredient> ReadIngredientsFromUser()
    {
        bool shallStop = false;
        List <Ingredient> ingredients = [];

        do
        {
            Console.WriteLine("Add an ingredient by its ID, " +
                              "or type anything else if finished.");

            var userInput = Console.ReadLine();
            if (int.TryParse(userInput, out int id))
            {
                var selectedIngredient = ingredientsRegister.GetById(id);
                if (selectedIngredient is not null)
                {
                    ingredients.Add(selectedIngredient);
                }
            }
            else
            {
                shallStop = true;
            }
        } while (!shallStop);

        return ingredients;
    }
    
    public void Exit()
    {
        Console.WriteLine("Press any key to exit");
        Console.ReadKey(true);
    }
}