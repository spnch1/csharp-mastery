using CookiesCookbookRefactored.App;
using CookiesCookbookRefactored.DataAccess;
using CookiesCookbookRefactored.Recipes;
using CookiesCookbookRefactored.FileAccess;
using CookiesCookbookRefactored.Recipes.Ingredients;

const FileFormat Format = FileFormat.Json;

IStringsRepository stringsRepository = Format == FileFormat.Json ?
    new StringsJsonRepository() :
    new StringsTextualRepository();

const string FileName = "recipes";
FileMetadata fileMetadata = new(FileName, Format);
var ingredientsRegister = new IngredientsRegister();

var cookiesRecipeApp = new CookiesRecipeApp(
    new RecipesRepository(
        stringsRepository,
        ingredientsRegister),
    new RecipesConsoleUserInteraction(
        ingredientsRegister));

cookiesRecipeApp.Run(fileMetadata.ToPath());
