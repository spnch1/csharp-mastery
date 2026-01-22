namespace CookiesCookbookRefactored.Recipes.Ingredients;

public class IngredientsRegister : IIngredientsRegister
{
    public IEnumerable<Ingredient> All => new List<Ingredient>
    {
        new WheatFlour(),
        new CoconutFlour(),
        new Butter(),
        new Chocolate(),
        new Sugar(),
        new Cardamom(),
        new Cinnamon(),
        new CocoaPowder(),
    };

    public Ingredient GetById(int id)
    {
        var allIngredientsWithGivenId = All
            .Where(i => i.Id == id);

        if (allIngredientsWithGivenId.Count() > 1)
        {
            throw new InvalidOperationException(
                $"More than one ingredients have ID equal to {id}.");
        }

        // breaks SRP but fine enough for this assignment
        if (All.Select(i => i.Id).Distinct().Count() != All.Count())
        {
            throw new InvalidOperationException(
                $"Some ingredients have duplicated IDs.");
        }
        
        return allIngredientsWithGivenId.FirstOrDefault();
    }
}