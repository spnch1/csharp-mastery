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

    public Ingredient GetById(int id) =>
        Enumerable.FirstOrDefault(All, i => i.Id == id);
}