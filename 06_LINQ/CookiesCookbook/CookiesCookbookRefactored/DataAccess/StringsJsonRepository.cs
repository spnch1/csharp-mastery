using System.Text.Json;

namespace CookiesCookbookRefactored.DataAccess;

public class StringsJsonRepository : StringsRepository
{
    protected override List<string> TextToStrings(string text) =>
        JsonSerializer.Deserialize<List<string>>(text);

    protected override string StringsToText(List<string> strings) =>
        JsonSerializer.Serialize(strings);
}